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
    public partial class Impresion : Form
    {
        public Impresion()
        {
            InitializeComponent();
        }

        private void ventaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ventaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.eliarome35436DBDataSet1);

        }

        private void Impresion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'eliarome35436DBDataSet1.Venta' Puede moverla o quitarla según sea necesario.
            this.ventaTableAdapter.Fill(this.eliarome35436DBDataSet1.Venta);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String m = "";
            tabControl1.Visible = true;
            dataGridView1.DataSource = compra.carrito(id_ventaTextBox);
            dataGridView2.DataSource = compra.carrito(id_ventaTextBox);
            compra reg = new compra();
            reg.person(id_ClienteTextBox, label1);
            reg.person(id_ClienteTextBox, label5);

            reg.suma(id_ventaTextBox, lblsub, lbliva, lbltot);
            m = lblsub.Text;
            //MessageBox.Show(m);
            label7.Text = m;
           // totalLabel1.Text = lblsub.Text;
          //  reg.suma(id_ventaTextBox, totalLabel1, lbliva, lbltot);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fechaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void totalLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void lblsub_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
