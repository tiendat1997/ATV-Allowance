﻿using System;
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

            if (unit == Unit.None)
            {
                this.CriteriaUnit.Text = "";
            }
            else if (unit == Unit.Point)
            {
                this.CriteriaUnit.Text = "điểm";
            }
            else if (unit == Unit.Percent)
            {
                this.CriteriaUnit.Text = "%";
            }
            else if (unit == Unit.Person)
            {
                this.CriteriaUnit.Text = "người";
            }
            else if (unit == Unit.Vnd)
            {
                this.CriteriaUnit.Text = "đồng";
            }
            else if (unit == Unit.Days)
            {
                this.CriteriaUnit.Text = "ngày";
            }
            else
            {
                this.CriteriaUnit.Text = "";
            }

        }

        public int GetCriteriaId()
        {
            return (int)this.CriteriaName.Tag;
        }

        public double GetValue()
        {
            return Double.Parse(this.CriteriaValue.Text);
        }

    }
}
