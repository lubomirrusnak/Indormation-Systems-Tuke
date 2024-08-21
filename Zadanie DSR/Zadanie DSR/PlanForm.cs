using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Zadanie_DSR
{
    public partial class PlanForm : Form
    {
        private OracleConnection connection;

        public PlanForm()
        {
            InitializeComponent();
            connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=147.232.25.197)(PORT=1523))(CONNECT_DATA=(SID=mis3)));User Id=lubomir_rusnak;Password=lubomir_rusnak;");
            connection.Open();
            reload_Table();
        }




        private void add2_Click(object sender, EventArgs e)
        {
            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "insert into plan_vyroby values('" + idPlanText.Text + "','" + nazovplan.Text + "','" + pocetPlanText.Text + "','" + "bednička" + "')";
            command1.CommandType = CommandType.Text;
            OracleDataReader reader1 = command1.ExecuteReader();
            reader1.Dispose();
            command1.Dispose();
            reload_Table();

        }

        public void reload_Table()
        {
            //nacitaj zoznam
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "select * from plan_vyroby";
            command.CommandType = CommandType.Text;
            OracleDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(reader);

            DataGridPlan.DataSource = dataTable;

            reader.Dispose();
            command.Dispose();
        }





        private void delete2_Click(object sender, EventArgs e)
        {
            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "delete from plan_vyroby where idplan=" + idPlanText.Text + "";
            command1.CommandType = CommandType.Text;
            OracleDataReader reader1 = command1.ExecuteReader();
            reader1.Dispose();
            command1.Dispose();
            reload_Table();                 
        }

        private void PlanForm_Load(object sender, EventArgs e)
        {
            //disp_data();
        }

        private void DataGridPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idPlanText.Text = DataGridPlan.SelectedRows[0].Cells[0].Value.ToString();
            nazovplan.Text = DataGridPlan.SelectedRows[0].Cells[1].Value.ToString();
            pocetPlanText.Text = DataGridPlan.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void edit2_Click(object sender, EventArgs e)
        {
            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "update plan_vyroby set nazov='" + nazovplan.Text + "',pocet='" + pocetPlanText.Text + "'where idplan=" + idPlanText.Text + "";
            OracleDataReader reader1 = command1.ExecuteReader();
            reader1.Dispose();
            command1.Dispose();
            reload_Table();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
