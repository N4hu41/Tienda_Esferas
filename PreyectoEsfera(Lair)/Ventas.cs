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
    public partial class Ventas : Form
    {
        Registros reg = new Registros();
        string descrip = "";
        public Ventas()
        {
            InitializeComponent();
        }

        private void esferaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.esferaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.eliarome35436DBDataSet1);
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'eliarome35436DBDataSet2.Esfera' Puede moverla o quitarla según sea necesario.
            this.esferaTableAdapter1.Fill(this.eliarome35436DBDataSet2.Esfera);
            // TODO: esta línea de código carga datos en la tabla 'eliarome35436DBDataSet.Cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter1.Fill(this.eliarome35436DBDataSet.Cliente);
            // TODO: esta línea de código carga datos en la tabla 'eliarome35436DBDataSet1.Vendedor' Puede moverla o quitarla según sea necesario.
            this.vendedorTableAdapter.Fill(this.eliarome35436DBDataSet1.Vendedor);
            // TODO: esta línea de código carga datos en la tabla 'eliarome35436DBDataSet1.Esfera' Puede moverla o quitarla según sea necesario.
            this.esferaTableAdapter.Fill(this.eliarome35436DBDataSet1.Esfera);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }
        public double canti_vali()
        {
            double cantidad = 0;
            if (radioButton3.Checked == true)
            {
                descrip = "Caja de 6 Esferas Color " + colorLabel1.Text + " Tamaño " + tamLabel1.Text;
                cantidad = Convert.ToDouble(precio_en_cajaLabel1.Text)*(6 * Convert.ToInt32(txtcanti.Text));
            }

            if (radioButton4.Checked == true)
            {
                descrip = "Caja de 12 Esferas Color " + colorLabel1.Text + " Tamaño " + tamLabel1.Text;
                cantidad = Convert.ToDouble(precio_en_cajaLabel1.Text)*(12 * Convert.ToInt32(txtcanti.Text));
            }

            if (radioButton5.Checked == true)
            {
                descrip = "Caja de 24 Esferas Color " + colorLabel1.Text + " Tamaño " + tamLabel1.Text;
                cantidad = Convert.ToDouble(precio_en_cajaLabel1.Text)*(24 * Convert.ToInt32(txtcanti.Text));
            }
            if (radioButton6.Checked == true)
            {
                descrip = "Esferas Color " + colorLabel1.Text + " Tamaño " + tamLabel1.Text;
                cantidad = Convert.ToDouble(costo_esfLabel1.Text) * Convert.ToDouble(txtcanti.Text);
            }
           
            return cantidad;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            double mulcan = canti_vali();
            double subtotal = Convert.ToDouble(costo_esfLabel1.Text) * mulcan;
            reg.insertaCompra(id_esferaLabel1, txtcanti, descrip, subtotal, textBox2);
            dataGridView1.DataSource = compra.carrito(textBox2);
            compra c = new compra();
            c.suma(textBox2, lblsub, lbliva, lbltot);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            compra c = new compra();
            c.Vaciar(textBox2);
            dataGridView1.DataSource = compra.carrito(textBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reg.insertaVenta(textBox2, lblsub, lbltot, id_vendedorLabel1, id_ClienteLabel1, dateTimePicker1);
            MessageBox.Show("Venta Exitosa");
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtcanti_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void id_ClienteLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
