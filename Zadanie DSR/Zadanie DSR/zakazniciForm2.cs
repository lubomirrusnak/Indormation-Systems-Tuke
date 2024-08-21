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
    public partial class zakazniciForm2 : Form
    {
        private OracleConnection connection;

        public zakazniciForm2()
        {
            InitializeComponent();
            connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=147.232.25.197)(PORT=1523))(CONNECT_DATA=(SID=mis3)));User Id=lubomir_rusnak;Password=lubomir_rusnak;");
            connection.Open();
            reload_Table();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add1_Click(object sender, EventArgs e)
        {
            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "insert into zakaznici(idzakaznici,meno, priezvisko, kontakt, adresa, email) VALUES('" + idzakaznik.Text + "','" + menotxt.Text + "','" + priezviskotxt.Text + "','" + kontakttxt.Text + "','" + adresatxt.Text + "','" + emailtxt.Text + "')";
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
            command.CommandText = "select * from zakaznici";
            command.CommandType = CommandType.Text;
            OracleDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(reader);

            DataGridZakaznik.DataSource = dataTable;

            reader.Dispose();
            command.Dispose();
        }

        private void edit1_Click(object sender, EventArgs e)
        {
            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "UPDATE zakaznici set meno = '" + menotxt.Text + "', priezvisko = '" + priezviskotxt.Text + "',kontakt = '" + kontakttxt.Text + "', adresa = '" + adresatxt.Text + "', email = '" + emailtxt.Text +  "' where idzakaznici = " + idzakaznik.Text;
            command1.CommandType = CommandType.Text;
            OracleDataReader reader1 = command1.ExecuteReader();
            reader1.Dispose();
            command1.Dispose();
            reload_Table();
        }

        private void delete1_Click(object sender, EventArgs e)
        {
            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "delete from zakaznici where idzakaznici ='" + idzakaznik.Text + "'";
            command1.CommandType = CommandType.Text;
            OracleDataReader reader1 = command1.ExecuteReader();
            reader1.Dispose();
            command1.Dispose();
            reload_Table();
        }

        private void DataGridZakaznik_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idzakaznik.Text = DataGridZakaznik.SelectedRows[0].Cells[0].Value.ToString();
            menotxt.Text = DataGridZakaznik.SelectedRows[0].Cells[1].Value.ToString();
            priezviskotxt.Text = DataGridZakaznik.SelectedRows[0].Cells[2].Value.ToString();
            kontakttxt.Text = DataGridZakaznik.SelectedRows[0].Cells[3].Value.ToString();
            adresatxt.Text = DataGridZakaznik.SelectedRows[0].Cells[4].Value.ToString();
            emailtxt.Text = DataGridZakaznik.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void idzakaznik_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
