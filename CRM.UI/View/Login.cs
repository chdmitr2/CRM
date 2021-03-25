using CRM.BL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM.UI.View
{
    public partial class Login : Form
    {
        public Customer Customer { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Customer = new Customer()
            {
                Name = textBox1.Text
            };
            DialogResult = DialogResult.OK;
        }
    }
}
