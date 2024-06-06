using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class GuessingGame : Controller
    {
        public ActionResult Index()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 101);
            ViewBag.RandomNumber = randomNumber;



            return View();
        }
    }
}