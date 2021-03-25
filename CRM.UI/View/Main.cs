using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRM.BL.Controller;
using CRM.BL.Model;
using CRM.UI.View;

namespace CRM.UI
{
    public partial class Main : Form
    {
        CrmContext db;
        Cart cart;
        Customer customer;
        CashDesk cashDesk;

        public Main()
        {
            InitializeComponent();
            db = new CrmContext();

            cart = new Cart(customer);
            cashDesk = new CashDesk(1, db.Sellers.FirstOrDefault(), db)
            {
                IsModel = false
            };
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

        private void Main_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                listBox1.Invoke((Action)delegate
                {
                    listBox1.Items.AddRange(db.Products.ToArray());
                    UpdateLists();
                });
            });
        }

        private void UpdateLists()
        {
            listBox2.Items.Clear();
            listBox2.Items.AddRange(cart.GetAll().ToArray());
            label1.Text = "Total: " + cart.Price;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Product product)
            {
                cart.Add(product);
                listBox2.Items.Add(product);
                UpdateLists();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (customer != null)
            {
                cashDesk.Enqueue(cart);
                var price = cashDesk.Dequeue();
                listBox2.Items.Clear();
                cart = new Cart(customer);

                MessageBox.Show("You Purchase End Succsessful. Sum: " + price,"",  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sign In Please!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new Login();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                var tempCustomer = db.Customers.FirstOrDefault(c => c.Name.Equals(form.Customer.Name));
                if (tempCustomer != null)
                {
                    customer = tempCustomer;
                }
                else
                {
                    db.Customers.Add(form.Customer);
                    db.SaveChanges();
                    customer = form.Customer;
                }

                cart.Customer = customer;
            }

            linkLabel1.Text = $"Hello, {customer.Name}";
        }
    }
}
