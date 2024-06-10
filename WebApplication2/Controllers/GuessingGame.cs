using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class GuessingGameController : Controller
    {
        private const string SessionKeyNumber = "RandomNumber";

        [HttpGet]
        public IActionResult Index()
        {
            // Generate a random number between 1 and 100 and store it in session
            var random = new Random();
            HttpContext.Session.SetInt32(SessionKeyNumber, random.Next(1, 101));

            ViewBag.Message = "Enter a number between 1 and 100.";
            return View();
        }

        [HttpPost]
        public IActionResult Index(int? guess)
        {
            if (!guess.HasValue)
            {
                ViewBag.Message = "Please enter a valid number.";
                return View();
            }

            int randomNumber = HttpContext.Session.GetInt32(SessionKeyNumber) ?? 0;

            if (guess == randomNumber)
            {
                // Correct guess
                ViewBag.Message = "Congratulations! You guessed the correct number!";
                // Generate a new number for the next game
                var random = new Random();
                HttpContext.Session.SetInt32(SessionKeyNumber, random.Next(1, 101));
            }
            else if (guess < randomNumber)
            {
                ViewBag.Message = "Too low! Try again.";
            }
            else
            {
                ViewBag.Message = "Too high! Try again.";
            }

            return View();
        }
    }
}
