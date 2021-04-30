using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W8D1DataAcess
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Ado.Net Giriş

            // SqlConnection Nesnesi : SQL Server'a bağlantıdan sorumlu sınıftır.
            //İçerisine connectionstring ifadesi alır.
            string constr = @"Server = FK-MSI\SQLEXPRESS; Database = Northwind; Trusted_Connection = True";

            //1-Sqlconnection listesinden instance alınması gerekir.
            SqlConnection sqlcon = new SqlConnection(constr);

            //2-Sqlconnection ı açmak lazım.
            sqlcon.Open();
            Console.WriteLine(sqlcon.ServerVersion);

            //3-SqlCommand Nesnesi : Sql Server'a Sql connection üzerinden bağlantı yaparak verdiğimiz
            //Sql komutlarını çalıştırır. Komut çalıştırdığımızda iki türlü durum vardır.
            //a)CRUD (insert,update,delete) işlemlerinde sadece kaç row affected oldu sonucunu integer olarak
            // bildirir.
            //b)Select ifadesinde ise bir result set geri döner. Bu sonuç setini karşılamak için genelde 
            //SqlDataReader denene nesne kullanılabilir.

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandText = "Insert into dbo.Categories (CategoryName) values ('Misir')";
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result.ToString());

            //cmd.CommandText="Update dbo.Categories CategoryName)" (BUNU TAMAMLA)

            //Select işlemi 1. Yaklaşım.
            cmd.CommandText = "Select * from dbo.Categories";
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine($"{rdr["CategoryName"]}");
            }

            rdr.Close();

            //Select işlemi 2. Yaklaşım
            //DataTable kullanmak : Offline kullanmak için.
            DataTable tbl = new DataTable();
            cmd.CommandText = "Select * from dbo.Categories";
            tbl.Load(cmd.ExecuteReader());
            foreach (DataRow item in tbl.Rows)
            {
                Console.WriteLine($"{item["CategoryName"]}");
            }

            //Stored Procedure Kullanma (BUNU TAMAMLA)

           
            //Postgresql için npgsql'i yükledim bu projeye ama kullanmadım.

            //-İşimiz bitince sqlconnectionı kapatalım.
            sqlcon.Close();

            #endregion

        }
    }
}
