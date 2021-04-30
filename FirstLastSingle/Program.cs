using System;
using System.Linq;

namespace FirstLastSingle
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] isimler = { "Ali", "Veli", "Ahmet", "Mehmet", "Hasan" };
            int[] sayilar = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //First() ilk kaydı alır. Kayıt yoksa hata verir.
            var first = isimler.First();
            var firstsayi = sayilar.First();
            Console.WriteLine(first+firstsayi);

            //FirstOrDefault() : First() ile aynı kayıdı alır. Kayıt yok ise hata vermez. Default değer ne ise onu verir.
            var firstOrDefault = isimler.FirstOrDefault();
            Console.WriteLine(firstOrDefault);

            //Last() : Son kayıdı verir. Bulamaz ise hata verir.
            //LastOrDefault():Last ile aynı işlemi yapar. Bulamaz ise default değeri verir.
            var last = isimler.Last();
            Console.WriteLine(last);
            var lastOrDefault = isimler.LastOrDefault();
            Console.WriteLine(lastOrDefault);


            //Single() anahtar sözcüğü koleksiyonda bulunan bir ögeyi alır. Birden çok değer gelirse hata veriri.
            //SingleOrDefault(),SingleOrDefault() ise Single ile aynısını yapar single değer gelmez ise hata vermez.
            //ElementAt : Bir koleksiyonda bulunan verilerin index değerine göre alınmasını sağlar
            //ElementAtDefault
            var elementAt = isimler.ElementAt(2);
            Console.WriteLine("Element At" + elementAt);
            Console.ReadLine();

        }
    }
}
