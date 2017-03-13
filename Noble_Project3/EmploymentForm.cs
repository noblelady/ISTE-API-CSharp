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
    public partial class EmploymentForm : Form
    {
        List<ProfessionalEmploymentInformation> EmpInfo;
        public EmploymentForm(List<ProfessionalEmploymentInformation> tempEmp)
        {
            InitializeComponent();
            EmpInfo = tempEmp;
            PopulateEmpTable();
        }

        public void PopulateEmpTable()
        {
            for (int i = 0; i < EmpInfo.Count; i++)
            {
                professionalEmploymentInformationBindingSource.Add(EmpInfo[i]);
            }
        }
    }
}
