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
    public partial class Form1 : Form
    {
        Registros reg = new Registros();
        public Form1()
        {
            InitializeComponent();
        }

        private void vendedorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.vendedorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.eliarome35436DBDataSet1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'eliarome35436DBDataSet.Cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter.Fill(this.eliarome35436DBDataSet.Cliente);
            // TODO: esta línea de código carga datos en la tabla 'eliarome35436DBDataSet1.Cliente' Puede moverla o quitarla según sea necesario.

            // TODO: esta línea de código carga datos en la tabla 'eliarome35436DBDataSet1.Esfera' Puede moverla o quitarla según sea necesario.
            this.esferaTableAdapter.Fill(this.eliarome35436DBDataSet1.Esfera);
            // TODO: esta línea de código carga datos en la tabla 'eliarome35436DBDataSet1.Vendedor' Puede moverla o quitarla según sea necesario.
            this.vendedorTableAdapter.Fill(this.eliarome35436DBDataSet1.Vendedor);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            reg.insertaVendedor(textBox1, textBox2, textBox3);
            this.vendedorTableAdapter.Fill(this.eliarome35436DBDataSet1.Vendedor);
            MessageBox.Show("Vendedor Agregado");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reg.insertaCliente(textBox7, textBox8, textBox9, textBox10, textBox11, textBox12);
            this.clienteTableAdapter.Fill(this.eliarome35436DBDataSet.Cliente);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reg.insertaEsferas(txtpin, txtcar, txtgan, txtcantidad, txtcolor, txttamaño);
            this.esferaTableAdapter.Fill(this.eliarome35436DBDataSet1.Esfera);
            txttamaño.Clear();
            txtpin.Clear();
            txtgan.Clear();
            txtcolor.Clear();
            txtcar.Clear();
            txtcantidad.Clear();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void clienteDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
