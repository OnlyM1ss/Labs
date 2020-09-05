using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Form1 : Form
    {
        internal Legal GetLegal = new Legal();
        internal Administative GetAdmin = new Administative();
        BuisenesLogic buisenesLogic = new BuisenesLogic();
        public string SelectedItem = "";
        string SelectedDocument = null;
        int minID;
        int maxID;
        bool rename = false;
        public Form1()
        {
            InitializeComponent();
        }

        internal void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SelectedDocument != null)  
            SelectedDocument = listBox1.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tmp = listBox1.SelectedItem.ToString();
            string[] arrayOfString = tmp.Split(' ');
            if(arrayOfString[0].Equals("Административный"))
            {
                buisenesLogic.deleteDocument(int.Parse(arrayOfString[1]),false);
                listBox1.Items.RemoveAt(int.Parse(arrayOfString[1]) -1 );
            }
            if(arrayOfString[0].Equals("Легальный"))
            {
                buisenesLogic.deleteDocument(int.Parse(arrayOfString[1]), true);
                listBox1.Items.RemoveAt(int.Parse(arrayOfString[1]) - 1);
            }
        }
        internal void AddInListBox1(Administative document)
        {
            listBox1.Items.Add(document.getType() + " " + " " + document.getId() + " " + document.getbeginTime() + " " + document.getEndTime() + " " + document.getdiscribe());
        }
        internal void AddInListBox1(Legal document)
        {
            listBox1.Items.Add(document.getType() + " " + " " + document.getId() + " " + document.getbeginTime() + " " + document.getEndTime() + " " + document.getdiscribe());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            rename = true;
            AddRenameFormcs renameFormcs = new AddRenameFormcs();
            renameFormcs.Show();
            Document document = new Document();
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            minID = (int)numericUpDown1.Value;
            maxID = (int)numericUpDown2.Value;
            List<Administative> listForAdmin = new List<Administative>();
            listForAdmin = buisenesLogic.GetAdministatives();
            List<Document> listForLegal = new List<Document>();
            listForLegal = buisenesLogic.GetLegals();
            foreach (Administative document in listForAdmin)
            {
                if(document.getId() >= minID && document.getId() <= maxID)
                    listBox1.Items.Add(document.getType() + " " + document.getId() + " " + document.getName() + " " + document.getbeginTime() + " " + document.getEndTime() +  " " + document.getdiscribe());
            }
            MessageBox.Show(buisenesLogic.GetLegals().Count.ToString());
            MessageBox.Show(listForAdmin.Count.ToString());
            foreach (Legal document in listForLegal)
            {
                if (document.getId() >= minID && document.getId() <= maxID)
                    listBox1.Items.Add(document.getId() + document.getName() + document.getbeginTime() + document.getEndTime());
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Legal document = new Legal();
            AddRenameFormcs addRenameFormcs = new AddRenameFormcs();
            addRenameFormcs.Show();

            //buisenesLogic.addRecord(document);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}