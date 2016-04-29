using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PreyectoEsfera_Lair_
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Admin = new Form1();
            Admin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Ventas = new Ventas();
            Ventas.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form imp = new Impresion();
            imp.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            MessageBox.Show(" Bienvenido ");
        }
    }
}
