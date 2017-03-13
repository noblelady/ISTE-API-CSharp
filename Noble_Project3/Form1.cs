using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using restUtil;
using Newtonsoft.Json.Linq;

namespace Noble_Project3
{
    public partial class Form1 : Form
    {
        RestUtil rt = new RestUtil("http://ist.rit.edu/api");
        Degrees degrees;
        Employment employment;
        People people;
        Research research;
        News news;

        Boolean gradInfo = true;
        Boolean researchInfo = true;

        string jsonDegrees;
        string jsonEmp;
        string jsonPeople;
        public Form1()
        {
            InitializeComponent();
            Populate();
            spinner.Visible = false;
        }

        private void Populate()
        {
            //populates the labels at he about information
            string jsonAbout = rt.GET("/about/");
            //Console.WriteLine(jsonAbout);
            //convert to object
            About about = JToken.Parse(jsonAbout).ToObject<About>();
            lblTitle.Text = about.title;
            lblQuote.Text = about.quote;
            lblAuthor.Text = about.quoteAuthor;

            //only populates the degrees first and the undergrad info
            // after as it enters it will populate

            jsonDegrees = rt.GET("/degrees/");
            degrees = JToken.Parse(jsonDegrees).ToObject<Degrees>();
            Console.WriteLine(degrees);
            //parts.Find(x => x.PartName.Contains("seat")));
            //WMC info
            Undergraduate wmc =degrees.undergraduate.Find(x => x.degreeName.Contains("wmc"));
            lblWMCTitle.Text = wmc.title;
            lblWMCDesc.Text = wmc.description;

            ListViewItem item;

           for(int i=0; i<wmc.concentrations.Count; i++)
            {
                item = new ListViewItem(new String[]{wmc.concentrations[i]});
                lvWMC.Items.Add(item); 
            }

            //CIT info
            Undergraduate cit = degrees.undergraduate.Find(x => x.degreeName.Contains("cit"));
            lblCITTitle.Text = cit.title;
            lblCITDesc.Text = cit.description;

            for (int i = 0; i < cit.concentrations.Count; i++)
            {
                item = new ListViewItem(new String[] { cit.concentrations[i] });
                lvCIT.Items.Add(item);
            }

            //HCI info
            Undergraduate hcc = degrees.undergraduate.Find(x => x.degreeName.Contains("hcc"));
            lblHCCTitle.Text = hcc.title;
            lblHCCDesc.Text = hcc.description;

            for (int i = 0; i < hcc.concentrations.Count; i++)
            {
                item = new ListViewItem(new String[] { hcc.concentrations[i] });
                lvHCC.Items.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //set up my listview degrees
            lvWMC.View = View.Details;
            lvWMC.GridLines = true;
            lvWMC.FullRowSelect = true;

            lvCIT.View = View.Details;
            lvCIT.GridLines = true;
            lvCIT.FullRowSelect = true;

            lvHCC.View = View.Details;
            lvHCC.GridLines = true;
            lvHCC.FullRowSelect = true;

            //graduate degree lvs
            lvIST.View = View.Details;
            lvIST.GridLines = true;
            lvIST.FullRowSelect = true;

            lvHCI.View = View.Details;
            lvHCI.GridLines = true;
            lvHCI.FullRowSelect = true;

            lvNSA.View = View.Details;
            lvNSA.GridLines = true;
            lvNSA.FullRowSelect = true;

            //setting up the datagrid views in people
            //load up the objects
            jsonPeople = rt.GET("/people/");
            people = JToken.Parse(jsonPeople).ToObject<People>();

            for (int i = 0; i < people.staff.Count; i++)
            {
                staffBindingSource.Add(people.staff[i]);
            }
            //then hide any unnessary columns
            dgvStaff.Columns[0].Visible = false;
            dgvStaff.Columns[2].Visible = false;
            dgvStaff.Columns[3].Visible = false;
            dgvStaff.Columns[10].Visible = false;
            dgvStaff.Columns[11].Visible = false;

            //same thing but for faculty
            for (int i = 0; i < people.faculty.Count; i++)
            {
                facultyBindingSource.Add(people.faculty[i]);
            }
            //then hide any unnessary columns
            dgvFaculty.Columns[0].Visible = false;
            dgvFaculty.Columns[2].Visible = false;
            dgvFaculty.Columns[3].Visible = false;
            dgvFaculty.Columns[10].Visible = false;
            dgvFaculty.Columns[11].Visible = false;

            //set up research listviews
            lvFacultyR.View = View.Details;
            lvFacultyR.GridLines = true;
            lvFacultyR.FullRowSelect = true;

            lvInterestR.View = View.Details;
            lvInterestR.GridLines = true;
            lvInterestR.FullRowSelect = true;

        }

        // this is for grad info
        private void tcDegrees_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item;
            if (gradInfo)
            {
                //ist
                Graduate ist = degrees.graduate.Find(x => x.degreeName.Contains("ist"));
                lblISTTitle.Text = ist.title;
                lblISTDesc.Text = ist.description;

                for (int i = 0; i < ist.concentrations.Count; i++)
                {
                    item = new ListViewItem(new String[] { ist.concentrations[i] });
                    lvIST.Items.Add(item);
                }

                //hci
                Graduate hci = degrees.graduate.Find(x => x.degreeName.Contains("hci"));
                lblHCITitle.Text = hci.title;
                lblHCIDesc.Text = hci.description;

                for (int i = 0; i < hci.concentrations.Count; i++)
                {
                    item = new ListViewItem(new String[] { hci.concentrations[i] });
                    lvHCI.Items.Add(item);
                }

                //nsa
                Graduate nsa = degrees.graduate.Find(x => x.degreeName.Contains("nsa"));
                lblNSATitle.Text = nsa.title;
                lblNSADesc.Text = nsa.description;

                for (int i = 0; i < nsa.concentrations.Count; i++)
                {
                    item = new ListViewItem(new String[] { nsa.concentrations[i] });
                    lvNSA.Items.Add(item);
                }

                //set boolean to false so that it doesn;t keep adding info.
                gradInfo = false;
            }
            
            
        }

        private void btnAdv_Click(object sender, EventArgs e)
        {
            //on button press you
            Graduate advCert = degrees.graduate.Find(x => x.degreeName.Contains("graduate advanced certificates"));
            AdvCertForm acf = new AdvCertForm(advCert.availableCertificates[0], advCert.availableCertificates[1]);
            acf.ShowDialog();
        }

        //this is for emp info
        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            //setting the title
            jsonEmp = rt.GET("/employment/");
            employment = JToken.Parse(jsonEmp).ToObject<Employment>();

            lblEmpTitle.Text = employment.introduction.title;

            //setting up with the coop info
            Content contentEmp = employment.introduction.content[0];
            Content contentCoop = employment.introduction.content[1];

            lblCoopTitle.Text = contentCoop.title;
            lblEmplTitle.Text = contentEmp.title;

            lblCoopDesc.Text = contentCoop.description;
            lblEmpDesc.Text = contentEmp.description;

            DegreeStatistics dStats = employment.degreeStatistics;
            lblStatTitle.Text = dStats.title;

            lblStat1.Text = dStats.statistics[0].value + "\n" + dStats.statistics[0].description;
            lblStat2.Text = dStats.statistics[1].value + "\n" + dStats.statistics[1].description;
            lblStat3.Text = dStats.statistics[2].value + "\n" + dStats.statistics[2].description;
            lblStat4.Text = dStats.statistics[3].value + "\n" + dStats.statistics[3].description;

            //adding in research info
            ListViewItem item;
            if (researchInfo)
            {
                Console.WriteLine("doind research stuff.");
                string jsonResearch = rt.GET("/research/");
                research = JToken.Parse(jsonResearch).ToObject<Research>();
                for (int i = 0; i < research.byInterestArea.Count; i++)
                {
                    item = new ListViewItem(new String[] { research.byInterestArea[i].areaName });
                    Console.WriteLine(research.byInterestArea[i].areaName);
                    lvInterestR.Items.Add(item);
                }

                for (int i = 0; i < research.byFaculty.Count; i++)
                {
                    item = new ListViewItem(new String[] { research.byFaculty[i].facultyName });
                    lvFacultyR.Items.Add(item);
                }
                researchInfo = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnEmpTable_Click(object sender, EventArgs e)
        {
            EmploymentForm empForm = new EmploymentForm(employment.employmentTable.professionalEmploymentInformation);
            empForm.ShowDialog();
        }

        private void btnCoopTable_Click(object sender, EventArgs e)
        {
            CoopForm coopForm = new CoopForm(employment.coopTable.coopInformation);
            coopForm.ShowDialog();
        }

        private void btnMinors_Click(object sender, EventArgs e)
        {
            string jsonMinors = rt.GET("/minors/");
            Minors minors = JToken.Parse(jsonMinors).ToObject<Minors>();
            MinorsForm minorForm = new MinorsForm(minors);
            minorForm.ShowDialog();
        }

        private void lvFacultyR_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            string facName = lv.SelectedItems[0].Text;
            ByFaculty fac = research.byFaculty.Find(x => x.facultyName.Contains(facName));

            ResearchForm researchForm = new ResearchForm(facName,fac.citations);
            researchForm.ShowDialog();
        }

        private void lvInterestR_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            string areaName = lv.SelectedItems[0].Text;
            ByInterestArea interest = research.byInterestArea.Find(x => x.areaName.Contains(areaName));

            ResearchForm researchForm = new ResearchForm(areaName, interest.citations);
            researchForm.ShowDialog();
        }

        private async void btnLoadNews_Click(object sender, EventArgs e)
        {
            Boolean newsBool = true;
            if (newsBool)
            {
                //turn on visuals
                spinner.Visible = true;
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                string tempYear = "";
                string tempOlder = "";

                await Task.Run(() =>
                {
                    string jsonNews = rt.GET("/news/");
                    news = JToken.Parse(jsonNews).ToObject<News>();

                    for (int i = 0; i < news.year.Count; i++)
                    {
                        tempYear += news.year[i].date + "\n" + news.year[i].title + "\n" + news.year[i].description + "\n\n";
                    }

                    for (int i = 0; i < news.older.Count; i++)
                    {
                        tempOlder += news.older[i].date + "\n" + news.older[i].title + "\n" + news.older[i].description + "\n\n";
                    }
                });

                //change the gui
                lblYear.Text = tempYear;
                lblOlder.Text = tempOlder;

                //turn off visuals
                spinner.Visible = false;

                newsBool = false;
            }
            

        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            MapForm map = new MapForm();
            map.ShowDialog();
        }
    }
}
