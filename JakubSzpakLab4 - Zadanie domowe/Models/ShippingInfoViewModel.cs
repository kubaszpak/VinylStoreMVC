using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JakubSzpakLab4___Zadanie_domowe.Models
{
    /// <summary>
    /// Klasa przechowująca informacje potrzebne do dostarczenia paczki, rozszerza klasę NewsletterViewModel, ponieważ dane z niej się powtarzają
    /// </summary>
    public class ShippingInfoViewModel : NewsletterViewModel
    {
        /// <summary>
        /// Zmienna przechowująca adres
        /// </summary>
        public string Address { get; set; }
    }
}
