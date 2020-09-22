﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//agregado por my
using System.IO;
using System.Net.Sockets;

namespace practicaLenguajes1
{
    public partial class Form1 : Form
    {
        string archivo;
        public Form1()
        {
            InitializeComponent();
        }

        private void estasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog cuadroDialogo = new OpenFileDialog();
                cuadroDialogo.Filter = "Texto|*.gt";
                if (cuadroDialogo.ShowDialog() == DialogResult.OK)
                {
                    archivo = cuadroDialogo.FileName;
                    using(StreamReader lectura=new StreamReader(archivo))
                    {
                        Area1.Text = lectura.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error de abrir archivo");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
 
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
            SaveFileDialog Guardar = new SaveFileDialog();
            Guardar.Filter = "Texto|*.gt";
                if (archivo != null)
                {
                    using(StreamWriter sobreEscribir=new StreamWriter(archivo))
                    {
                        sobreEscribir.Write(Area1.Text);
                    }
                }
                else
                {
                    if (Guardar.ShowDialog() == DialogResult.OK)
                    {
                        archivo =Guardar.FileName;
                        using(StreamWriter escribir=new StreamWriter(Guardar.FileName))
                        {
                            escribir.Write(Area1.Text);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error al guardar");
            }
        }

        private void comoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Area1.Clear();
            archivo = null;
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Boton_Click(object sender, EventArgs e)
        {
            String resultado = "";
            Analisar llamar = new Analisar();
            resultado = llamar.EstadoInicial(Area1.Text);
            copilado.Text = resultado;
            //PINTA
            String[] palabrasReservada = {"SI","SINO","SINO_SI","MIENTRAS","HASTA","DESDE","INCREMENTO","HACER" };
            for (int i=0;i<=palabrasReservada.Length;i++) {
                int index = Area1.Text.IndexOf(palabrasReservada[i+2]);
                int Length = palabrasReservada[i+2].Length;
                Area1.Select(index, Length);
                Area1.SelectionColor = Color.Green;
            }
            
        }
    }
}
