﻿using System;
using System.Windows.Forms;
using CRM.BL.Model;
using CRM.UI.View;

namespace CRM.UI
{
    public partial class Main : Form
    {
        CrmContext db;
        public Main()
        {
            InitializeComponent();
            db = new CrmContext();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Product>(db.Products,db);
            catalogProduct.Show();
        }

        private void sellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogSeller = new Catalog<Seller>(db.Sellers,db);
            catalogSeller.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCustomer = new Catalog<Customer>(db.Customers,db);
            catalogCustomer.Show();
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCheck = new Catalog<Check>(db.Checks,db);
            catalogCheck.Show();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var form = new CustomerForm();
            if(form.ShowDialog() == DialogResult.OK){
                db.Customers.Add(form.Customer);
                db.SaveChanges();
            }
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new SellerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Sellers.Add(form.Seller);
                db.SaveChanges();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ProductForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Products.Add(form.Product);
                db.SaveChanges();
            }
        }

        private void modelingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ModelingForm();
            form.Show();
        }
    }
}
