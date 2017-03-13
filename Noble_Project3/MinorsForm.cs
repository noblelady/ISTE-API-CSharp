using Newtonsoft.Json.Linq;
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
    public partial class MinorsForm : Form
    {
        Minors minors;

        //holds info of descriptions
        string dbddiDesc;
        string gisDesc;
        string medDesc;
        string mddevDesc;
        string mdevDesc;
        string netDesc;
        string webddDesc;
        string webdDesc;

        public MinorsForm(Minors tempMin)
        {
            InitializeComponent();
            minors = tempMin;
            PopulateMinors();
        }

        public void PopulateMinors()
        {
            ListViewItem item;

            //DBDDI
            UgMinor dbddi = minors.UgMinors.Find(x => x.name.Contains("DBDDI-MN"));
            gbDBBI.Text = dbddi.title;
            dbddiDesc = dbddi.description;

            for (int i = 0; i < dbddi.courses.Count; i++)
            {
                item = new ListViewItem(new String[] { dbddi.courses[i] });
                lvDBBI.Items.Add(item);
            }
            lblDBBINote.Text = dbddi.note;

            //GIS
            UgMinor gis = minors.UgMinors.Find(x => x.name.Contains("GIS-MN"));
            gbGIS.Text = gis.title;
            gisDesc = gis.description;

            for (int i = 0; i < gis.courses.Count; i++)
            {
                item = new ListViewItem(new String[] { gis.courses[i] });
                lvGIS.Items.Add(item);
            }
            lblGISNote.Text = gis.note;

            //MED
            UgMinor med = minors.UgMinors.Find(x => x.name.Contains("MEDINFO-MN"));
            gbMED.Text = med.title;
            medDesc = med.description;

            for (int i = 0; i < med.courses.Count; i++)
            {
                item = new ListViewItem(new String[] { med.courses[i] });
                lvMED.Items.Add(item);
            }
            lblMEDNote.Text = med.note;

            //MDDEV
            UgMinor mddev = minors.UgMinors.Find(x => x.name.Contains("MDDEV-MN"));
            gbMDDEV.Text = mddev.title;
            mddevDesc = mddev.description;

            for (int i = 0; i < mddev.courses.Count; i++)
            {
                item = new ListViewItem(new String[] { mddev.courses[i] });
                lvMDDEV.Items.Add(item);
            }
            lblMDDEVNote.Text = mddev.note;

            //MDEV
            UgMinor mdev = minors.UgMinors.Find(x => x.name.Contains("MDEV-MN"));
            gbMDEV.Text = mdev.title;
            mdevDesc = mdev.description;

            for (int i = 0; i < mdev.courses.Count; i++)
            {
                item = new ListViewItem(new String[] { mdev.courses[i] });
                lvMDEV.Items.Add(item);
            }
            lblMDEVNote.Text = mdev.note;

            //NET-SYS
            UgMinor net = minors.UgMinors.Find(x => x.name.Contains("NETSYS-MN"));
            gbNETSYS.Text = net.title;
            netDesc = net.description;

            for (int i = 0; i < net.courses.Count; i++)
            {
                item = new ListViewItem(new String[] { net.courses[i] });
                lvNETSYS.Items.Add(item);
            }
            lblNETNote.Text = net.note;

            //WEBDD
            UgMinor webdd = minors.UgMinors.Find(x => x.name.Contains("WEBDD-MN"));
            gbWEBDD.Text = webdd.title;
            webddDesc = webdd.description;

            for (int i = 0; i < webdd.courses.Count; i++)
            {
                item = new ListViewItem(new String[] { webdd.courses[i] });
                lvWEBDD.Items.Add(item);
            }
            lblWEBDDNote.Text = webdd.note;

            //WEBD
            UgMinor webd = minors.UgMinors.Find(x => x.name.Contains("WEBD-MN"));
            gbWEBD.Text = webd.title;
            webdDesc = webd.description;

            for (int i = 0; i < webd.courses.Count; i++)
            {
                item = new ListViewItem(new String[] { webd.courses[i] });
                lvWEBD.Items.Add(item);
            }
            lblWEBDNote.Text = webd.note;

        }

        private void btnDBDDI_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dbddiDesc);
        }

        private void btnGIS_Click(object sender, EventArgs e)
        {
            MessageBox.Show(gisDesc);
        }

        private void btnMED_Click(object sender, EventArgs e)
        {
            MessageBox.Show(medDesc);
        }

        private void btnMDDEV_Click(object sender, EventArgs e)
        {
            MessageBox.Show(mddevDesc);
        }

        private void btnMDEV_Click(object sender, EventArgs e)
        {
            MessageBox.Show(mdevDesc);
        }

        private void btnNETSYS_Click(object sender, EventArgs e)
        {
            MessageBox.Show(netDesc);
        }

        private void btnWEBDD_Click(object sender, EventArgs e)
        {
            MessageBox.Show(webddDesc);
        }

        private void btnWEBD_Click(object sender, EventArgs e)
        {
            MessageBox.Show(webdDesc);
        }
    }
}
