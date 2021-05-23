using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JakubSzpakLab4___Zadanie_domowe.Models
{
    public class VinylViewModel
    {
        public VinylViewModel(string title, string author, decimal price, string photo)
        {
            Title = title;
            Author = author;
            Price = price;
            Photo = photo;
        }

        /// <summary>
        /// Tytył albumu
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Autor albumu
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Cena albumu
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Scieżka do zdjęcia albumu
        /// </summary>
        public string Photo { get; set; }
    }
}
