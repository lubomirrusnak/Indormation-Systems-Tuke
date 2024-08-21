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
    public partial class zamestnaniciForm2 : Form
    {
        private OracleConnection connection;

        public zamestnaniciForm2()
        {
            InitializeComponent();
            connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=147.232.25.197)(PORT=1523))(CONNECT_DATA=(SID=mis3)));User Id=lubomir_rusnak;Password=lubomir_rusnak;");
            connection.Open();
            reload_Table();
        }
       
        
        private void add1_Click(object sender, EventArgs e)
        {


            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "insert into zamestnanci(id_zamestnanec, uzivatel, heslo, pozicia, email, meno,priezvisko) VALUES('" + idzamestnanectext.Text + "','" + uzivateltext.Text + "','" + hesloText.Text + "','" + poziciatext.Text + "','" + emailText.Text + "','" + menoText.Text + "','" + priezviskoText.Text + "')";
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
            command.CommandText = "select * from zamestnanci";
            command.CommandType = CommandType.Text;
            OracleDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(reader);

            DataGridZamestnanec.DataSource = dataTable;

            reader.Dispose();
            command.Dispose();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void edit1_Click(object sender, EventArgs e)
        {
            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "UPDATE zamestnanci set uzivatel = '" + uzivateltext.Text + "', heslo = '" + hesloText.Text + "',pozicia = '" + poziciatext.Text + "', email = '" + emailText.Text + "', meno = '" + menoText.Text + "', priezvisko = '" + priezviskoText.Text + "' where id_zamestnanec = " + idzamestnanectext.Text;
            command1.CommandType = CommandType.Text;
            OracleDataReader reader1 = command1.ExecuteReader();
            reader1.Dispose();
            command1.Dispose();
            reload_Table();
        }

        private void delete1_Click(object sender, EventArgs e)
        {
            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "delete from zamestnanci where id_zamestnanec ='" + idzamestnanectext.Text + "'";
            command1.CommandType = CommandType.Text;
            OracleDataReader reader1 = command1.ExecuteReader();
            reader1.Dispose();
            command1.Dispose();
            reload_Table();
        }

        private void DataGridZamestnanec_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idzamestnanectext.Text = DataGridZamestnanec.SelectedRows[0].Cells[0].Value.ToString();
            uzivateltext.Text = DataGridZamestnanec.SelectedRows[0].Cells[1].Value.ToString();
            hesloText.Text = DataGridZamestnanec.SelectedRows[0].Cells[2].Value.ToString();
            poziciatext.Text = DataGridZamestnanec.SelectedRows[0].Cells[3].Value.ToString();
            emailText.Text = DataGridZamestnanec.SelectedRows[0].Cells[4].Value.ToString();
            menoText.Text = DataGridZamestnanec.SelectedRows[0].Cells[5].Value.ToString();
            priezviskoText.Text = DataGridZamestnanec.SelectedRows[0].Cells[6].Value.ToString();

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idzamestnanectext.Text = DataGridZamestnanec.SelectedRows[0].Cells[0].Value.ToString();
            uzivateltext.Text = DataGridZamestnanec.SelectedRows[0].Cells[1].Value.ToString();
            hesloText.Text = DataGridZamestnanec.SelectedRows[0].Cells[2].Value.ToString();
            poziciatext.Text = DataGridZamestnanec.SelectedRows[0].Cells[3].Value.ToString();
            emailText.Text = DataGridZamestnanec.SelectedRows[0].Cells[4].Value.ToString();
            menoText.Text = DataGridZamestnanec.SelectedRows[0].Cells[5].Value.ToString();
            priezviskoText.Text = DataGridZamestnanec.SelectedRows[0].Cells[6].Value.ToString();
        }
    }
}
