using DataService.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATV_Allowance.Forms.Employee
{
    public partial class AddEmployeeForm : Form
    {
        public AddEmployeeForm()
        {
            InitializeComponent();
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            List<Organization> list = new List<Organization>
            {
                new Organization
                {
                    Id = 1,
                    Name = "Đài Phát Thanh"
                },
                new Organization
                {
                    Id = 2,
                    Name = "Châu phú"
                },
                new Organization
                {
                    Id = 3,
                    Name = "Châu thành"
                }
            };
            cbOrganization.DisplayMember = "Name";
            cbOrganization.DataSource = list;
            cbOrganization.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbOrganization.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
    }
}
