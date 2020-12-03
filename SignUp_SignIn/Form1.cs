using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignUp_SignIn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool Format_email( string a )
        {
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //kiểm tra định dạng gmail
            string s = textBox_email.Text.ToString();
            bool exist_signal = false;
            for(int i=0;i<s.Length;i++)
            {
                if (s[i] == '@')
                    exist_signal = true;
            }
            if (exist_signal == false)
                MessageBox.Show("Email invaid.");

            string path = @"C:\Users\ASUS\Desktop\bibi\Nam_2\Lap_Trinh_truc_quan\SignUp_SignIn\Information_input.txt";
            if (textBox_email.Text == "" || textBox_password.Text == "" || textBox_username.Text == "")
            {
                MessageBox.Show("Please fill out information.");
            }
            else
            {
                //if(File.Exists(path)==false)
                //    File.Create(path);
                StreamWriter test = new StreamWriter(path, true);
                test.WriteLine(textBox_username.Text);
                test.WriteLine(textBox_password.Text);
                test.WriteLine(textBox_email.Text);
                test.Close();

               
            }
        }
        void Auto_Fill_Out()
        {
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            textBox_email.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_email.AutoCompleteSource = AutoCompleteSource.CustomSource;
            string[] arrayname = { textBox_email.Text + "@gmail.com", textBox_email.Text+"@email.com" };
            foreach (string name in arrayname)
            {
                auto1.Add(name);
            }
            textBox_email.AutoCompleteCustomSource = auto1;
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox_email_KeyPress(object sender, KeyPressEventArgs e)
        {
            string a = "@";
            if (e.KeyChar == char.Parse(a))
            {
                Auto_Fill_Out();
            }

        }

        private void textBox_email_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.G)
            //{
            //    AutoFillOut();
            //}
        }
    }
}
