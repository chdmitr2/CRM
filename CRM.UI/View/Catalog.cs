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
        public Catalog(DbSet<T> set, CrmContext db)
        {
            InitializeComponent();
            this.db = db;
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

        }

        private void Delete_Click(object sender, EventArgs e)
        {

        }

    } 
}
