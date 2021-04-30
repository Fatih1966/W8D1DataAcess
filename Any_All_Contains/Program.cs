using System;
using System.Linq;

namespace Any_All_Contains
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sayilar = { 15, 24, 58, 44, 12, 14 };

            //Any
            var sonuc1 = sayilar.Any();
            var sonuc2 = sayilar.Any(x => x == 10);//False
            var sonuc4 = sayilar.Any(x => x == 44 || x == 78);//

            Console.WriteLine(sonuc1);
            Console.WriteLine(sonuc2);
            Console.WriteLine(sonuc4);

            //Contains
            bool sonuc6 = sayilar.Contains(6);
            Console.WriteLine(sonuc6);
            //All
            string[] diller = { "Almanca", "Fransızca", "İngilizce", "Japonca" };
            var sonuc7 = diller.All(d => d == "Japonca");//Tüm elemanlar Japonca mı diye sorgular
            var sonuc8 = diller.All(d => d.StartsWith("A"));

            Console.ReadLine();
        }
    }
}
