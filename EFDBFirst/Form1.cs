using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDBFirst
{

    public partial class Form1 : Form
    {
        NorthwindEntities db = new NorthwindEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Shipper shipper = new Shipper();
            shipper.CompanyName = "Aras Kargo";
            shipper.Phone = "4444412";
            db.Shippers.Add(shipper);
            db.SaveChanges();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Shipper shipper = new Shipper();
            shipper.ShipperID = 5;
            shipper.CompanyName = "Aras Kargo";
            shipper.Phone = "1123441";
            db.Entry<Shipper>(shipper).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Shipper shipper = new Shipper();
            shipper.ShipperID = 5;
            shipper.CompanyName = "Aras Kargo";
            shipper.Phone = "1123441";
            db.Entry<Shipper>(shipper).State = System.Data.Entity.EntityState.Deleted;
            //db.Shippers.Remove(shipper); Bu çalışmadı.
            db.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var liste = db.Customers.ToList();
            foreach (var item in liste)
            {
                listBox1.Items.Add(item.CompanyName);
            }
        }
    }
}
