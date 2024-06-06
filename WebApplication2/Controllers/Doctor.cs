using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class Doctor : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckTemperature(double temperature, string isFahrenheitHidden)
        {
            string message;
            bool isFahrenheit = bool.Parse(isFahrenheitHidden);

            if (isFahrenheit)
            {
                // Fahrenheit
                if (temperature >= 100)
                {
                    message = "You have fever.";
                }
                else if (temperature <= 95)
                {
                    message = "You have hypothermia.";
                }
                else
                {
                    message = "You have a normal temperature.";
                }
            }
            else
            {
                // Celsius
                if (temperature >= 38)
                {
                    message = "You have fever.";
                }
                else if (temperature <= 35)
                {
                    message = "You have hypothermia.";
                }
                else
                {
                    message = "You have a normal temperature.";
                }
            }

            ViewBag.Message = message;
            ViewBag.IsFahrenheit = isFahrenheit;
            return View("Index");
        }
    }
}
