using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.SqlServer;

namespace EFWSorgular
{
    public partial class Form1 : Form
    {
        NorthwindEntities context = new NorthwindEntities();

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Fiyatı 20 ile 50 arasında olan ürünlerin Id,Üürn adı,Fiyatı,Stok Miktarını ve Kategorisini getiren sorgu.

            //SQL Sorgu olarak aşağıdaki şekilde yazılır.
            //Select ProductID,ProductName,UnitPrice,UnitsinStock,CategoryName
            //from Products as p 
            //inner join Categories as c on p.CategoryID=c.CategoryID
            //where p.UnitPrice>20 and p.UnitPrice<50

            #region LinQ to Sql
            //var result = context.Products
            //    .Where(x => x.UnitPrice > 20 && x.UnitPrice < 50)
            //    .OrderBy(x => x.UnitPrice)
            //    .Select(p => new
            //    {
            //        p.ProductID,
            //        p.ProductName,
            //        p.UnitPrice,
            //        p.UnitsInStock,
            //        p.Category.CategoryName
            //    }).ToList();
            //dataGridView1.DataSource = result;
            #endregion

            #region LinQ Sql Sorgusu

            //var result2 = from p in context.Products
            //              where p.UnitPrice > 20 && p.UnitPrice < 50
            //              orderby p.UnitPrice ascending
            //              select new
            //              {
            //                  p.ProductID,
            //                  p.ProductName,
            //                  p.UnitPrice,
            //                  p.UnitsInStock,
            //                  p.Category.CategoryName
            //              };
            //dataGridView1.DataSource = result2.ToList();
            #endregion

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Siparişler tablosundan Müşteri ŞirketAdı, ÇalışanAdıSoyadı,Sipariş ID, Sipariş Tarihi ve Kargo Şirketi Adı getiren sorgu.

            #region Linq to SQL

            //var result3 = from o in context.Orders
            //              select new
            //              {
            //                  MusteriSirketAdi = o.Customer.CompanyName,
            //                  CalisanAdiSoyAdi = o.Employee.FirstName + " " + o.Employee.LastName,
            //                  SiparisID = o.OrderID,
            //                  SiparisTarihi = o.OrderDate,
            //                  KargoSirketiAdi = o.Shipper.CompanyName
            //              };
            //dataGridView1.DataSource = result3.ToList();

            #endregion


            #region LinQ Method Yontemi

            //var results4 = context.Orders.Select(o => new
            //{
            //    MusteriSirketAdi = o.Customer.CompanyName,
            //    CalisanAdiSoyAdi = o.Employee.FirstName + " " + o.Employee.LastName,
            //    SiparisID = o.OrderID,
            //    SiparisTarihi = o.OrderDate,
            //    KargoSirketiAdi = o.Shipper.CompanyName

            //});

            //dataGridView1.DataSource = results4.ToList();

            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //CompanyName içinde restaurant geçen müşterilerin listelenmesi.
            //LinQ Metod Yöntemi
            //dataGridView1.DataSource = context.Customers.Where(x => x.CompanyName.Contains("restaurant")).ToList();

            //LinQ SQL Yöntemi
            //var result5 = from c in context.Customers
            //             where c.CompanyName.Contains("restaurant")
            //             select c;
            //dataGridView1.DataSource = result5.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Kategorisi Beverages olan ve UrunAdi:Kola,Fiyatı:5.00,StokAdet:500 olan ürün ekleyin.
            //1.Yol
            //Product urun = new Product();
            //urun.ProductName = "Kola1";
            //urun.UnitPrice = 5;
            //urun.UnitsInStock = 500;
            //var cat = context.Categories.FirstOrDefault(x => x.CategoryName == "Beverages");
            //urun.CategoryID = cat.CategoryID;
            //context.Products.Add(urun);
            //context.SaveChanges();

            //2.Yol
            //context.Products.Add(new Product
            //{
            //    ProductName = "Kola2",
            //    UnitPrice = 5,
            //    UnitsInStock = 260,
            //    CategoryID = context.Categories.FirstOrDefault(x => x.CategoryName == "Beverages").CategoryID
            //});
            //context.SaveChanges();

            //3.Yol
            context.Categories.FirstOrDefault(x => x.CategoryName == "Beverages").Products.Add(new Product
            {
                ProductName = "Kola3",
                UnitPrice = 5,
                UnitsInStock = 260,
            });
            context.SaveChanges();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Çalışanların adını , soyadını , doğum tarihini ve yaşını getiren sorgu.
            //1. Yol Linq to SQL
            //Aşağıda SqlFunctions'a da ulaşıyorsun. Yukarıda using ... ekleniyor önce.
            //var result6 = from emp in context.Employees
            //              select new
            //              {
            //                  Isım = emp.FirstName,
            //                  Soyadı = emp.LastName,
            //                  Dogum_Tarihi = emp.BirthDate,
            //                  Yas=SqlFunctions.DateDiff("Year",emp.BirthDate,DateTime.Now)
            //              };
            //dataGridView1.DataSource = result6.ToList();

            ////2. Yol Linq Metod
            dataGridView1.DataSource = context.Employees.Select(x => new
            {
                Isım = x.FirstName,
                Soyadı = x.LastName,
                Dogum_Tarihi = x.BirthDate,
                Yas = SqlFunctions.DateDiff("Year", x.BirthDate, DateTime.Now)
            }).ToList();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Kategorilerine stoktaki ürün sayısını veren sorgu.
            //Bu sorguyu yapmak için gruplama kullanılmalı.
            //Linq Sql
            //var result8 = from p in context.Products
            //              group p by p.Category.CategoryName into g
            //              select new
            //              {
            //                  KategoriAdi = g.Key,
            //                  ToplamStok = g.Sum(p => p.UnitsInStock)
            //              };
            //dataGridView1.DataSource = result8.ToList();

            //Linq Method
            dataGridView1.DataSource = context
                .Products
                .GroupBy(p => p.Category.CategoryName)
                .Select(g => new
                {
                    KategoriAdi = g.Key,
                    ToplamStok = g.Sum(p => p.UnitsInStock)
                }).ToList();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Delete item.

            int idtodelete = Convert.ToInt32(textBox1.Text);
            var itemToRemove = context.Products.SingleOrDefault(x => x.ProductID == idtodelete);
            if (itemToRemove != null)
            {
                context.Products.Remove(itemToRemove);
                context.SaveChanges();
            }
            dataGridView1.DataSource = context.Products.ToList();
        }
    }
}
