using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using CombinedTrailsApp.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CombinedTrailsApp.Models;

namespace CombinedTrailsApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private readonly ILogger<HomeController> _logger;
        private readonly UserContext _userContext;

        public HomeController(ILogger<HomeController> logger, UserContext userContext)
        {
            _logger = logger;
            _userContext = userContext;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<ActionResult> ProcessLogin(string email, string password)
        {
            // Store the inputted email and password in variables
            string storedEmail = email;
            string storedPassword = password;

            using (var httpClient = new HttpClient())
            {
                // Define the API endpoint URL
                string apiUrl = "https://web.socem.plymouth.ac.uk/COMP2001/auth/api/users";

                // Create a new User object with the provided email and password
                var user = new Models.User
                {
                    email = storedEmail,
                    password = storedPassword
                };

                // Serialize the User object to JSON
                string jsonData = JsonConvert.SerializeObject(user);

                // Use StringContent to include the JSON data in the request body
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Use HttpClient to post the JSON data to the API endpoint
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseData = await response.Content.ReadAsStringAsync();

                    Console.WriteLine($"API Response: {responseData}");
                    string editval1 = responseData.Replace('"', ' ');
                    string editval2 = editval1.Replace('[', ' ');
                    string editval3 = editval2.Replace(']', ' ');
                    string editval4 = editval3.Replace(',', ' ');
                    string editval5 = editval4.Replace(" ", "");
                    Console.WriteLine(editval5);
                    if (editval5 == "VerifiedTrue")
                    {
                        Console.WriteLine("Switch");
                        return RedirectToAction("UserMain", new { storedEmail = storedEmail });
                    }

                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }

            return RedirectToAction("Index");
        }
        public IActionResult UserMain(string storedEmail)
        {
            // Check if storedEmail is null or empty
            if (string.IsNullOrEmpty(storedEmail))
            {
                // Handle the case where the email is not provided
                return View("UserNotFound");
            }

            // Retrieve the user with the specified email from the database
            var user = _userContext.MyCombinedView.SingleOrDefault(u => u.Email == storedEmail);

            // Check if the user is found
            if (user != null)
            {
                // Pass the user data to the view
                return View(new List<UserVal> { user });
            }
            else
            {
                return View("UserNotFound"); 
            }
        }
    }
}