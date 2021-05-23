using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JakubSzpakLab4___Zadanie_domowe.Models
{
    public class NotifyViewModel
    {
        /// <summary>
        /// Dane użytkownika
        /// </summary>
        public NewsletterViewModel ContactData { get; set; }

        /// <summary>
        /// Tytuł albumu, o którego promocjach użytkownik chciałby być informowany
        /// </summary>
        public string Title { get; set; }
    }
}
