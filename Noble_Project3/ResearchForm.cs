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
    public partial class ResearchForm : Form
    {
        string title;
        List<string> citations;
        public ResearchForm(string tempTitle,List<string> tempCitations)
        {
            InitializeComponent();
            title = tempTitle;
            citations = tempCitations;
            populateResearch();
        }

        public void populateResearch()
        {
            lblTitle.Text = title;
            lblCitations.Text = "";
            for (int i=0;i<citations.Count;i++)
            {
                lblCitations.Text += "\n" + citations[i];
                //Console.WriteLine(lblCitations.Text);
            }
        }
    }
}
