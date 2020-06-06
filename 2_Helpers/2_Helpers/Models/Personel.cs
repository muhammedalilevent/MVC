using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2_Helpers.Models
{
    public class Personel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public string Departman { get; set; }
        public bool Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }
        public int SehirID { get; set; }

    }
}