using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noble_Project3
{
    public partial class AdvCertForm : Form
    {
        public AdvCertForm(string cert1, string cert2)
        {
            InitializeComponent();
            lblAC1.Text = cert1;
            lblAC2.Text = cert2;
        }
    }
}
