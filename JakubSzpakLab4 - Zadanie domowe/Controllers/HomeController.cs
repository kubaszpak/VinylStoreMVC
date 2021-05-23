using JakubSzpakLab4___Zadanie_domowe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JakubSzpakLab4___Zadanie_domowe.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// Lista przechowująca wszystkie płyty
        /// </summary>
        List<VinylViewModel> allVinyls;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            allVinyls = new List<VinylViewModel>();

            allVinyls.Add(new VinylViewModel("X", "Ed Sheeran", 50, "~/images/x.jpg"));

            allVinyls.Add(new VinylViewModel("The Dark Side of the Moon", "Pink Floyd", 40, "~/images/darkSideOfTheMoon.png"));

            allVinyls.Add(new VinylViewModel("Birds in the Trap Sing McKnight", "Travis Scott", 60, "~/images/birdsInTheTrap.png"));

            allVinyls.Add(new VinylViewModel("Igor", "Tyler the Creator", 40, "~/images/igor.png"));

            allVinyls.Add(new VinylViewModel("Currents", "Tame Impala", 60, "~/images/currents.jpg"));
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Widok wyświetlający listę wszystkich albumów
        /// </summary>
        /// <returns></returns>
        public IActionResult GetAllVinyls()
        {
            return View(allVinyls);
        }

        /// <summary>
        /// Widok wyświetlający szczegóły jednego albumu
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult GetVinylDetails(int id)
        {
            // wyświetlenie odpowiedniego elementu na podstawie pozycji w liście wszystkich albumów
            VinylViewModel model = allVinyls.ElementAt(id);
            return View(model);
        }

        /// <summary>
        /// Widok wyświetlający formularz do zapisania się do newslettera
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult NewsletterForm()
        {
            return View();
        }

        /// <summary>
        /// Widok wyświetlający formularz do zapisania się do newslettera
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult NewsletterForm(NewsletterViewModel userData)
        {
            string fullName = userData.FirstName + " " + userData.LastName;
            ViewBag.FullName = fullName;

            string email = userData.Email;
            ViewBag.Email = email;

            // W tym miejscu logika związana z zapisywaniem użytkownika do Newslettera

            return View("NewsletterFormGreetings");
        }

        /// <summary>
        /// Widok z formularzem do zamówienia
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ShippingInfoForm(string title)
        {
            // wybranie odpowiedniego elementu na podstawie pełnej nazwy albumu
            var vinyl = allVinyls.Where(a => a.Title.ToLower() == title.ToLower()).FirstOrDefault();
            TempData["title"] = vinyl.Title;
            TempData["author"] = vinyl.Author;
            TempData["price"] = vinyl.Price;
            return View();
        }

        /// <summary>
        /// Widok potwierdzający zamówienie
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ShippingInfoForm(ShippingInfoViewModel userData)
        {
            string fullName = userData.FirstName + " " + userData.LastName;
            ViewBag.FullName = fullName;

            string email = userData.Email;
            ViewBag.Email = email;

            // W tym miejscu logika związana z zamówieniem

            return View("ShippingInfoConfirmation");
        }

        /// <summary>
        /// Widok z formularzem do powiadomienia o promocji
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult NotifyForm(string title)
        {
            NotifyViewModel model = new NotifyViewModel();
            model.Title = title;

            return View(model);
        }

        /// <summary>
        /// Widok potwierdzający, że użytkownik będzie powiadomiony o nadchodzącej promocji
        /// </summary>
        /// <param name="notificationData"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult NotifyForm(NotifyViewModel notificationData)
        {
            string fullName = notificationData.ContactData.FirstName + " " + notificationData.ContactData.LastName;
            ViewBag.FullName = fullName;

            string email = notificationData.ContactData.Email;
            ViewBag.Email = email;

            string title = notificationData.Title;
            ViewBag.Album = title;

            // W tym miejscu logika związana z zapisywaniem danych użytkownika do bazy danych

            return View("NotifyFormConfirmation");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
