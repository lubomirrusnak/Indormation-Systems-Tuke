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
    public partial class HomeForm : Form
    {

        private OracleConnection connection;
        private String uzivatel;
        private String akcia;
        private int idVal = 0;
        private String pozVal = "";
        private String hesVal = "";
        public HomeForm(String user, String poz)
        {
            InitializeComponent();
            uzivatel = user;
            pozVal = poz;

        }



        private void HomeForm_Load(object sender, EventArgs e)
        {
            connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=147.232.25.197)(PORT=1523))(CONNECT_DATA=(SID=mis3)));User Id=lubomir_rusnak; Password=lubomir_rusnak;");
            connection.Open();

            reload_Table();

            //prihlaseny.Text = "Prihlasný: " + uzivatel + "\n\nPozícia: " + pozVal;

            switch (pozVal)
            {
                case "veducí skladu":
                    objednavky.Hide();
                    produkty.Hide();
                    zakaznici.Hide();
                    zamestnanci.Hide();
                    break;
                case "skladník výrobkov":
                    zakaznici.Hide();
                    objednavky.Hide();
                    matSklad.Hide();
                    vyrobPlan.Hide();
                    produkty.Hide();
                    zakaznici.Hide();
                    zamestnanci.Hide();
                    break;
                case "skladník materiálu":
                    zakaznici.Hide();
                    objednavky.Hide();
                    produkty.Hide();
                    vyrobSklad.Hide();
                    vyrobPlan.Hide();
                    produkty.Hide();
                    zakaznici.Hide();
                    zamestnanci.Hide();
                    break;
                case "marketingové oddelenie":
                    matSklad.Hide();
                    vyrobSklad.Hide();
                    vyrobPlan.Hide();
                    break;
                case "obchodné oddelenie":
                    zakaznici.Hide();
                    break;
                case "vedúci výroby":
                    zakaznici.Hide();
                    zamestnanci.Hide();
                    break;
                case "operátor č.1":
                    zakaznici.Hide();
                    objednavky.Hide();
                    vyrobPlan.Hide();
                    zamestnanci.Hide();
                    break;
                case "operátor č.2":
                    zakaznici.Hide();
                    objednavky.Hide();
                    vyrobPlan.Hide();
                    zamestnanci.Hide();
                    break;
                case "riaditeľ":
                    break;
                default:
                    break;
            }

        }

        public void reload_Table()
        {
            //nacitaj zoznam
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT id_zamestnanec,uzivatel,heslo,pozicia FROM zamestnanci ";
            command.CommandType = CommandType.Text;
            OracleDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(reader);

        }



        private Form activeForm = null;
        private void openChild(Form childForm)
        {

            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();


        }


        private void button1_Click(object sender, EventArgs e)

        {

            
           // HomeForm Home = new HomeForm();
            //this.Hide();
            //Home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Material_SkladForm2 vstupny_Sklad = new Material_SkladForm2();
            vstupny_Sklad.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Vyrobny_skladForm2 vystupny_Sklad = new Vyrobny_skladForm2();
            vystupny_Sklad.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            zamestnaniciForm2 zamestnanci = new zamestnaniciForm2();
            zamestnanci.Show();
           

        }

        private void button7_Click(object sender, EventArgs e)
        {
            zakazniciForm2 zakaznici = new zakazniciForm2();
            zakaznici.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ProduktForm2 produkty = new ProduktForm2();
            produkty.Show();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //SurovinyForm suroviny = new SurovinyForm();
            //suroviny.Show();

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void objednavky_Click(object sender, EventArgs e)
        {

            ObjednavkyForm2 objednavky = new ObjednavkyForm2();
            objednavky.Show();
        }

        private void vyrobPlan_Click(object sender, EventArgs e)
        {
            PlanForm plan = new PlanForm();
            plan.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
