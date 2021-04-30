using System;
using System.Collections.Generic;

namespace Orderby_Thenby_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            var ogrenciler = OgrenciListesi;

            Console.WriteLine("Hello World!");
        }
        public static List<Ogrenci> OgrenciListesi
        {

            {

            }
        }
    }
}



public class Ogrenci
{
    public int ID { get; set; }
    public string Ad { get; set; }
    public string SoyAdi { get; set; }

}
}
