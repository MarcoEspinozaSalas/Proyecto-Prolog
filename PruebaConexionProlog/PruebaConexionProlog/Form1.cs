
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
		private readonly Random _random = new Random();

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
   //         string valorObtenido = textBox1.Text;
			//string segundoValor = textBox2.Text;
			//listBox1.Items.Clear();
   //         PlQuery cargar = new PlQuery("cargar('grafos.bd')");
   //         cargar.NextSolution();
   //         if (checkBox1.Checked == true)
   //         {
   //             PlQuery consulta1 = new PlQuery("conectado_con(X,"+valorObtenido+")");
   //             foreach (PlQueryVariables z in consulta1.SolutionVariables)
   //                 listBox1.Items.Add(z["X"].ToString());
   //         }
			//if (checkBox2.Checked == true)
			//{
			//	PlQuery consulta1 = new PlQuery("ruta(" + valorObtenido + "," + segundoValor + ",Lista)");
			//	foreach (PlQueryVariables p in consulta1.SolutionVariables)
			//		listBox1.Items.Add(p["Lista"].ToString());
			//}

		}

		private void BtnCreaMatriz_Click(object sender, EventArgs e)
		{
			pnlCreaMatriz.Visible = false;
			pnlTablero.Visible = true;
			var tamano = Int32.Parse(inputCantidad.Text);
			var x = 0;
			var y = 0;
			var n = 0;
			CheckBox[] chk;
			chk = new CheckBox[tamano];
			for (int j = 0; j < tamano; j++)
			{
				for (int i = 0; i < tamano; i++)
				{
					int num = _random.Next(4); // [0,1,2,3]  como valores randoms
					chk[i] = new CheckBox();
					chk[i].Location = new Point(x, y);
					chk[i].Visible = true;
					if (num == 0)
					{
						chk[i].Checked = true;
					}

					chk[i].Size = new Size(20, 20);
					chk[i].Name = "chk" + n;  // chk0 , chk1 , chk2 , etc
					
					//chk[i].Click           
					pnlTablero.Controls.Add(chk[i]);
					n++;
					x = x + 30;
				}
				x = 0;
				y = y + 30;
			}
			
			
		}
	}
}
