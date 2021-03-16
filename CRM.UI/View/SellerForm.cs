using CRM.BL.Model;
using System;
using System.Windows.Forms;

namespace CRM.UI
{
    public partial class SellerForm : Form
    {

        public Seller Seller { get; set; }
        public SellerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Seller = new Seller()
            {
                Name = textBox1.Text
            };

            Close();
        }
    }
}
