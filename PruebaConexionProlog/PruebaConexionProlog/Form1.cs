
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
		private int name = 1;

		public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("Path", @"C:\\Program Files\\swipl\\bin");
            string[] p = { "-q", "-f", @"grafos.pl" };
            PlEngine.Initialize(p);
			listBox1.Visible = false;
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


		// EJEMPLO DE INSERCION DE GRUPOS , LUEGO VERIFICAR POR CADA ESPACIO (X,Y)
		// "assertz(grupo("0_0"))."
		// "assertz(grupo("0_1"))."
		// "assertz(grupo("0_2"))."
		// "assertz(grupo("3_2"))."

		private void ConexionesProlog()
		{
			var tamano = Int32.Parse(inputCantidad.Text);
			PlQuery cargar = new PlQuery("cargar('grafos.bd')");
			cargar.NextSolution();


			for (int x = 0; x < tamano; x++)
			{										// CONEXION TOTAL DE MATRIZ PARA VERIFICAR EL GRUPO AL QUE PERTENCE  POR CADA (X,Y)
				for (int y = 0; y < tamano; y++)
				{
					if (x == 0 && y == 0)
					{

						var sum1 = y + 1;
						var sum2 = x + 1;

						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x + "-" + sum1 + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + sum2 + "-" + y + "', false)).");
						continue;

					}
					else if (x == 0 && y == tamano - 1)
					{
						var y2 = y - 1;
						var x2 = x + 1;

						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x + "-" + y2 + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x2 + "-" + y2 + "', false)).");
						continue;
					}
					else if (x == tamano - 1 && y == 0)
					{
						var x2 = x - 1;
						var y2 = y + 1;

						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x2 + "-" + y + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x + "-" + y2 + "', false)).");
						continue;
					}
					else if (x == tamano - 1 && y == tamano - 1)
					{
						var x2 = x - 1;
						var y2 = y - 1;

						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x2 + "-" + y + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x + "-" + y2 + "', false)).");
						continue;
					}
					else if (x != 0 && y != tamano - 1 && y == 0)
					{
						var x2 = x - 1;
						var x3 = x + 1;
						var y2 = y + 1;

						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x2 + "-" + y + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x3 + "-" + y + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x + "-" + y2 + "', false)).");
						continue;
					}
					else if (x != 0 && x != tamano - 1 && y == tamano - 1)
					{
						var x2 = x - 1;
						var x3 = x + 1;
						var y2 = y - 1;

						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x2 + "-" + y + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x3 + "-" + y + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x + "-" + y2 + "', false)).");
						continue;
					}
					else if (x == 0 && y != 0 && y != tamano - 1)
					{
						var x2 = x + 1;
						var y3 = y + 1;
						var y2 = y - 1;

						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x + "-" + y2 + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x + "-" + y3 + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x2 + "-" + y + "', false)).");
						continue;
					}
					else if (y != 0 && y != tamano - 1 && x == tamano - 1)
					{
						var x2 = x - 1;
						var y3 = y + 1;
						var y2 = y - 1;

						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x2 + "-" + y + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x + "-" + y3 + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x2 + "-" + y + "', false)).");
						continue;
					}
					else {   // Rellena la cuadricula central
												// 2,4  .... 2,3   ..... 2,5 .... 1,4   .... 3,4
						var x2 = x - 1;
						var x3 = x + 1;
						var y3 = y + 1;
						var y2 = y - 1;

						//var a = "assert(conexionMatriz(" + x + "_" + y + "," + x + "_" + y2 + ", false)).";
						//var b = "assertz(conexionMatriz(" + x + "_" + y + "," + x + "_" + y3 + ", false)).";
						//var c = "assertz(conexionMatriz(" + x + "_" + y + "," + x2 + "_" + y + ", false)).";
						//var d = "assertz(conexionMatriz(" + x + "_" + y + "," + x3 + "_" + y + ", false)).";

						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x2 + "-" + y + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x + "-" + y3 + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x2 + "-" + y + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x3 + "-" + y + "', false)).");
						continue;
					}

				}
			}
		}


		// Por cada boton , al dar clikc obtner el name , mandarlo por parametro

		public void solution() {
			using (PlQuery q = new PlQuery("conexionMatriz(P, C, V), atomic_list_concat([P,C,V], L)"))
			{
				var r = q.SolutionVariables;
				foreach (PlQueryVariables p in q.SolutionVariables)
				{
					var Resp = p["P"].ToString() +" conectado con "+ p["C"].ToString();
					var rer = 0;
				}
			}


		}

		public void clickBoton(object sender, EventArgs e)
        {
			listBox1.Items.Clear();
			string texto = (sender as Button).Text;
			string nombre = (sender as Button).Name;

			char fila = nombre[0];
			char columna = nombre[2];
			listBox1.Items.Add("Boton " + texto  + " fila " + fila + " columna " + columna );

            if ((sender as Button).Text[0] != '.')
            {
				((Button)sender).BackColor = Color.Green;
				((Button)sender).Text = "."+(sender as Button).Text;
			}



        }

		private void BtnCreaMatriz_Click(object sender, EventArgs e)
		{
			pnlCreaMatriz.Visible = false;
			pnlTablero.Visible = true;
			listBox1.Visible = true;
			var tamano = Int32.Parse(inputCantidad.Text);
			var x = 0;
			var y = 0;
			var n = 0;
			Button[] boton;
			boton = new Button[tamano];
			for (int j = 0; j < tamano; j++)
			{
				for (int i = 0; i < tamano; i++)
				{
					boton[i] = new Button();
					boton[i].Name = j.ToString()+ "_" + i.ToString();
					boton[i].Height = 30;
					boton[i].Width = 40;
					boton[i].BackColor = Color.Gray;
					boton[i].Text = name.ToString();
					boton[i].Font = new Font("Arial", 12);
					boton[i].Location = new Point(x, y);
					boton[i].Click += new EventHandler(clickBoton);



					pnlTablero.Controls.Add(boton[i]);
					n++;
					x = x + 30;
					name++;
				}
				x = 0;
				y = y + 30;
			}

			ConexionesProlog();
			solution();

		}

	}
}
