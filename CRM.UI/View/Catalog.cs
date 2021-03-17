using System;
using CRM.BL.Model;
using System.Data.Entity;
using System.Windows.Forms;

namespace CRM.UI
{
    public partial class Catalog<T> : Form
        where T : class
    {
        CrmContext db;
        DbSet<T> set;
        public Catalog(DbSet<T> set, CrmContext db)
        {
            InitializeComponent();
            this.db = db;
            this.set = set;
            set.Load();
            dataGridView1.DataSource = set.Local.ToBindingList();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (typeof(T) == typeof(Product))
            {

            }
            else if (typeof(T) == typeof(Seller))
            {

            }
            else if (typeof(T) == typeof(Customer))
            {

            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            var id = dataGridView1.SelectedRows[0].Cells[0].Value;
            if (typeof(T) == typeof(Product))
            {
                var product = set.Find(id) as Product;
                if (product != null)
                {
                    var form = new ProductForm(product);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        product = form.Product;
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
                }
            } else if (typeof(T) == typeof(Seller))
            {
                var seller = set.Find(id) as Seller;
                if (seller != null)
                {
                    var form = new SellerForm(seller);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        seller = form.Seller;
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
                }
            } else if (typeof(T) == typeof(Customer))
            {
                var customer = set.Find(id) as Customer;
                if (customer != null)
                {
                    var form = new CustomerForm(customer);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        customer = form.Customer;
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
                }
            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {

        }

    } 
}
