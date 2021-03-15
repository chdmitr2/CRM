using System;
using System.Windows.Forms;
using CRM.BL.Model; 


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
            var catalogProduct = new Catalog<Product>(db.Products);
            catalogProduct.Show();
        }
    }
}
