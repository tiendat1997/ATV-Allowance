using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Forms.CriteriaForms
{
    public partial class ACriteriaTemplate : UserControl
    {
        public ACriteriaTemplate()
        {
            InitializeComponent();
        }

        public ACriteriaTemplate(int criteriaId, string name, double value, int unit)
        {   
            InitializeComponent();
            this.CriteriaName.Text = name;
            this.CriteriaName.Tag = criteriaId;
            this.CriteriaValue.Text = value.ToString();
            if (unit == Unit.Percent)
            {
                this.CriteriaUnit.Text = "%";
            }else
            if (unit == Unit.Point)
            {
                this.CriteriaUnit.Text = "điểm";
            }
            else
            {
                this.CriteriaUnit.Text = "";
            }
        }

        public int GetCriteriaId() {
            return (int)this.CriteriaName.Tag;
        }

        public double GetValue()
        {
            return Double.Parse(this.CriteriaValue.Text);
        }

    }
}
