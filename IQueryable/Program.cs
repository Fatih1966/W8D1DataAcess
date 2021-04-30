using System;
using System.Collections.Generic;
using System.Linq;

namespace IQueryable
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //IEnurable önce hafızaya alır sonra where şartlarını uygular
            //IQueryable ise hafızaya almadan önce where şartını uygular

            //LinQ to SQL
            IEnumerable<int> query1 = from i in intList where i > 5 select i;
            IQueryable<int> query2 = from i in intList.AsQueryable() where i > 5 select i;

            //Metot Yöntemi
            IEnumerable<int> query1Metot = intList.Where(x => x > 5);
            IQueryable<int> query2Metot = intList.AsQueryable().Where(x => x > 5);
            foreach (var item in intList)
            {
                Console.WriteLine(item);
            }

            foreach (var item in query1)
            {
                Console.WriteLine(item);
            }


        }
    }
}
