using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class AddRenameFormcs : Form
    {
        Legal LegalDocument = new Legal();
        Administative AdministativeDocument = new Administative();
        public bool isLegal;
        public AddRenameFormcs()
        {
            InitializeComponent();
            comboBox1.Items.Add("Административный");
            comboBox1.Items.Add("Легальный");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuisenesLogic buisenesLogic = new BuisenesLogic();
            Form1 form1 = new Form1();
            if (comboBox1.SelectedItem.Equals("Административный"))
            {
                AdministativeDocument.setName(textBox2.Text);
                AdministativeDocument.setBeginTime(DateTime.Parse(textBox3.Text));
                AdministativeDocument.setEndTime(DateTime.Parse(textBox4.Text));
                AdministativeDocument.setDiscribe(textBox5.Text);
                AdministativeDocument.getType();
                form1.GetAdmin = AdministativeDocument;
                buisenesLogic.addRecord(AdministativeDocument);
            }
            if (comboBox1.SelectedItem.Equals("Легальный"))
            {
                LegalDocument.setName(textBox2.Text);
                LegalDocument.setBeginTime(DateTime.Parse(textBox3.Text));
                LegalDocument.setEndTime(DateTime.Parse(textBox4.Text));
                LegalDocument.setDiscribe(textBox5.Text);
                LegalDocument.getType();
                form1.GetLegal = LegalDocument;
                buisenesLogic.addRecord(LegalDocument);
            }
            

            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
