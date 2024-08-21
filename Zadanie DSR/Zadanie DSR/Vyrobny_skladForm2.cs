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
    public partial class Vyrobny_skladForm2 : Form
    {
        private OracleConnection connection;

        public Vyrobny_skladForm2()
        {
            InitializeComponent();
             connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=147.232.25.197)(PORT=1523))(CONNECT_DATA=(SID=mis3)));User Id=lubomir_rusnak;Password=lubomir_rusnak;");

            connection.Open();
            reload_Table();
        }

        private void add2_Click(object sender, EventArgs e)
        {


            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "update sklad_material set sklad_material.stav=sklad_material.stav - '" + mukaText.Text + "' *(select pocet from plan_vyroby where idplan = '" + Textidplan.Text + "') where idsklad_material =  11 ";

            command1.CommandType = CommandType.Text;
            OracleDataReader reader1 = command1.ExecuteReader();
            reader1.Dispose();
            command1.Dispose();



            OracleCommand command2 = connection.CreateCommand();
            command2.CommandText = "update sklad_material set sklad_material.stav=sklad_material.stav - '" + textsol.Text + "' *(select pocet from plan_vyroby where idplan = '" + Textidplan.Text + "') where idsklad_material =  12 ";

            command2.CommandType = CommandType.Text;
            OracleDataReader reader2 = command2.ExecuteReader();
            reader2.Dispose();
            command2.Dispose();

            OracleCommand command3 = connection.CreateCommand();
            command3.CommandText = "update sklad_material set sklad_material.stav=sklad_material.stav - '" + textcukor.Text + "' *(select pocet from plan_vyroby where idplan = '" + Textidplan.Text + "') where idsklad_material =  13 ";
            command3.CommandType = CommandType.Text;
            OracleDataReader reader3 = command3.ExecuteReader();
            reader3.Dispose();
            command3.Dispose();

            OracleCommand command4 = connection.CreateCommand();
            command4.CommandText = "update sklad_material set sklad_material.stav=sklad_material.stav - '" + textdzem.Text + "' *(select pocet from plan_vyroby where idplan = '" + Textidplan.Text + "') where idsklad_material =  14 ";
            command4.CommandType = CommandType.Text;
            OracleDataReader reader4 = command4.ExecuteReader();
            reader4.Dispose();
            command4.Dispose();

            OracleCommand command5 = connection.CreateCommand();
            command5.CommandText = "update sklad_material set sklad_material.stav=sklad_material.stav - '" + texttvaroh.Text + "' *(select pocet from plan_vyroby where idplan = '" + Textidplan.Text + "') where idsklad_material =  15 ";
            command5.CommandType = CommandType.Text;
            OracleDataReader reader5 = command5.ExecuteReader();
            reader5.Dispose();
            command5.Dispose();


            OracleCommand command6 = connection.CreateCommand();
            command6.CommandText = "update sklad_material set sklad_material.stav=sklad_material.stav - '" + textvoda.Text + "' *(select pocet from plan_vyroby where idplan = '" + Textidplan.Text + "') where idsklad_material =  16 ";
            command6.CommandType = CommandType.Text;
            OracleDataReader reader6 = command6.ExecuteReader();
            reader6.Dispose();
            command6.Dispose();



            OracleCommand command8 = connection.CreateCommand();
            command8.CommandText = "update sklad_material set sklad_material.stav=sklad_material.stav - '" + textdrozdie.Text + "' *(select pocet from plan_vyroby where idplan = '" + Textidplan.Text + "') where idsklad_material =  17 ";
            command8.CommandType = CommandType.Text;
            OracleDataReader reader8 = command8.ExecuteReader();
            reader8.Dispose();
            command8.Dispose();


            OracleCommand command9 = connection.CreateCommand();
            command9.CommandText = "update sklad_vyroba set sklad_vyroba.pocet=sklad_vyroba.pocet + (select pocet from plan_vyroby where nazov = '" + Textnazov.Text + "') where nazov ='"+ Textnazov.Text+ "'";
            command9.CommandType = CommandType.Text;
            OracleDataReader reader9 = command9.ExecuteReader();
            reader9.Dispose();
            command9.Dispose();

            OracleCommand command10 = connection.CreateCommand();
            command10.CommandText = "delete from plan_vyroby where idplan ='" + Textidplan.Text + "'";
            command10.CommandType = CommandType.Text;
            OracleDataReader reader10 = command10.ExecuteReader();
            reader10.Dispose();
            command10.Dispose();



            reload_Table();



        }

        public void reload_Table()
        {
            //nacitaj zoznam
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "select * from sklad_vyroba";
            command.CommandType = CommandType.Text;
            OracleDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(reader);

            uzivateliaOkno_zam.DataSource = dataTable;

            reader.Dispose();
            command.Dispose();
        }




        private void Vyrobny_skladForm2_Load(object sender, EventArgs e)
        {
            
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
