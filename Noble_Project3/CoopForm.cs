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
    public partial class CoopForm : Form
    {
        List<CoopInformation> CoopInfo;
        public CoopForm(List<CoopInformation> tempCoop)
        {
            InitializeComponent();
            CoopInfo = tempCoop;
            PopulateCoopTable();
        }

        public void PopulateCoopTable()
        {
            for (int i = 0; i < CoopInfo.Count; i++)
            {
                coopInformationBindingSource.Add(CoopInfo[i]);
            }
        }
    }
}
