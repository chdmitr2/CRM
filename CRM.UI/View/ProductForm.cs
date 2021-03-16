using CRM.BL.Model;
using System;
using System.Windows.Forms;

namespace CRM.UI
{
    public partial class ProductForm : Form
    {

        public Product Product { get; set; }
        public ProductForm()
        {
            InitializeComponent();
        }

        public ProductForm(Product product) : this()
        {
            Product = product;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product = new Product()
            {
                Name = textBox1.Text,
                Price = numericUpDown1.Value,
                Count = Convert.ToInt32(numericUpDown2.Value)
            };

            Close();
        }

       
    }
}
