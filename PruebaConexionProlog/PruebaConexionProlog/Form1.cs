
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SbsSW.SwiPlCs;

namespace PruebaConexionProlog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("Path", @"C:\\Program Files (x86)\\swipl\\bin");
            string[] p = { "-q", "-f", @"grafos.pl" };
            PlEngine.Initialize(p);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string valorObtenido = textBox1.Text;
			string segundoValor = textBox2.Text;
			listBox1.Items.Clear();
            PlQuery cargar = new PlQuery("cargar('grafos.bd')");
            cargar.NextSolution();
            if (checkBox1.Checked == true)
            {
                PlQuery consulta1 = new PlQuery("conectado_con(X,"+valorObtenido+")");
                foreach (PlQueryVariables z in consulta1.SolutionVariables)
                    listBox1.Items.Add(z["X"].ToString());
            }
			if (checkBox2.Checked == true)
			{
				PlQuery consulta1 = new PlQuery("ruta(" + valorObtenido + "," + segundoValor + ",Lista)");
				foreach (PlQueryVariables p in consulta1.SolutionVariables)
					listBox1.Items.Add(p["Lista"].ToString());
			}

		}
	}
}
