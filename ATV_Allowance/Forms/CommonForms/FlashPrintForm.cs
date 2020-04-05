﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATV_Allowance.Forms.CommonForms
{
    public partial class FlashPrintForm : Form
    {
        public FlashPrintForm(string title)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            lblTitle.Text = title;
        }
    }
}
