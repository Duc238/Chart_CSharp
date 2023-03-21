using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace Chart
{
    public partial class Form1 : Form
    {
        private ObservableCollection<SalaryOfActor> _List;
        public ObservableCollection<SalaryOfActor> List { get=>_List;set { _List = value; } }
        private ACTOREntities data;
        public Form1()
        {
            InitializeComponent();
        }
        #region ADO.NET
        //void FillChartADO()
        //{
        //    SqlConnection conn=new SqlConnection("Data Source=DESKTOP-460EDHU\\VOTANDUC;Initial Catalog=ACTOR;Integrated Security=True");
        //    DataTable dt=new DataTable();
        //    SqlDataAdapter adapter = new SqlDataAdapter("SELECT NAME, Salary FROM dbo.SalaryOfActor",conn);
        //    adapter.Fill(dt);
        //    chart1.DataSource = dt;
        //    conn.Close();
        //    chart1.Series["Salary"].XValueMember = "NAME";
        //    chart1.Series["Salary"].YValueMembers = "Salary";
        //    chart1.Titles.Add("Salary of actors");
        //}
        #endregion
        #region Entity Famework
        void FillChartEntity()
        {
            data=new ACTOREntities();
            List=new ObservableCollection<SalaryOfActor>(data.SalaryOfActors);
            chart1.DataSource = List;
            chart1.Series["Salary"].XValueMember = "NAME";
            chart1.Series["Salary"].YValueMembers = "Salary";
            chart1.Titles.Add("Salary of actors");
        }
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            FillChartEntity();
        }
    }
}
