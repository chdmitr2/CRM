using CRM.BL.Model;
using System;
using System.Windows.Forms;

namespace CRM.UI
{
    public partial class CustomerForm : Form
    {

        public Customer Customer { get; set; }
        public CustomerForm()
        {
            InitializeComponent();
        }

        public CustomerForm(Customer customer) : this()
        {
            Customer = customer;
            textBox1.Text = Customer.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s = Customer ?? new Customer();
            Name = textBox1.Text;
            Close();
        }
    }
}
