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
    public partial class Material_SkladForm2 : Form
    {

        private OracleConnection connection;

        public Material_SkladForm2()
        {
            InitializeComponent();
            connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=147.232.25.197)(PORT=1523))(CONNECT_DATA=(SID=mis3)));User Id=lubomir_rusnak;Password=lubomir_rusnak;");
            connection.Open();
            reload_Table();
        }



        private void add2_Click(object sender, EventArgs e)
        {
            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "update sklad_material set sklad_material.stav=sklad_material.stav + '" + pocetText.Text + "' where nazov = '" + materialText.Text + "'";
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
            command.CommandText = "select * from sklad_material";
            command.CommandType = CommandType.Text;
            OracleDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(reader);

            DataGridMaterialSklad.DataSource = dataTable;

            reader.Dispose();
            command.Dispose();
        }


        private void Material_SkladForm2_Load(object sender, EventArgs e)
        {
           
        }

        private void DataGridMaterialSklad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
