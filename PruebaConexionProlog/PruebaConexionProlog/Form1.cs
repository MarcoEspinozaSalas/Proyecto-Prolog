
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
		List<string> GrupoAColorear = new List<string>();

		List<string> PosicionesVisitadas = new List<string>();

		List<string> PosicionesMatriz = new List<string>();
		List<string> PosicionesVisitadasMatriz = new List<string>();

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



		private void ConexionesProlog()
		{
			PosicionesMatriz.Clear();
			var tamano = Int32.Parse(inputCantidad.Text);
			PlQuery cargar = new PlQuery("cargar('grafos.bd')");
			cargar.NextSolution();
			

			for (int x = 0; x < tamano; x++)
			{                                       // CONEXION TOTAL DE MATRIZ PARA VERIFICAR EL GRUPO AL QUE PERTENCE  POR CADA (X,Y)
				for (int y = 0; y < tamano; y++)
				{

					PosicionesMatriz.Add(x+"-"+y);

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


						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x2 + "-" + y + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x + "-" + y3 + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x2 + "-" + y + "', false)).");
						PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x3 + "-" + y + "', false)).");
						
						continue;
					}

				}
			}
			//cargar.Dispose();
			solution();
		}


		public void solution() {
			using (PlQuery q = new PlQuery("conexionMatriz(P, C, V), atomic_list_concat([P,C,V], L)"))
			{
				var r = q.SolutionVariables;
				foreach (PlQueryVariables p in q.SolutionVariables)
				{
					var Resp = p["P"].ToString() + " conectado con " + p["C"].ToString();
					listBox2.Items.Add(Resp);
				}
				q.Dispose();
			}
		}



		public void clickBoton(object sender, EventArgs e)
		{
			string texto = (sender as Button).Text;
			string nombre = (sender as Button).Name;
			char fila = nombre[0];
			char columna = nombre[2];

			if ((sender as Button).Text[0] != '.')
			{
				((Button)sender).BackColor = Color.Green;
				((Button)sender).Text = (sender as Button).Text;

			}

			bool EsGrupo = verificaSiEstaEnGrupo(nombre);
			if (!EsGrupo)
			{
				//Si no esta en grupo , se agrega a Prolog
				PlQuery q = new PlQuery("insertaGrupo('" + nombre + "')");
				foreach (PlQueryVariables p in q.SolutionVariables)
				{
					var Resp = p;
				}
				q.Dispose();
            }
            else
            {
				ObtenerGrupoRecursivo(nombre);
			}

			
		}

		public void ObtenerGrupoRecursivo(string nombre)
        {
			listBox1.Items.Clear();
			PosicionesVisitadas.Clear();
			GrupoAColorear.Clear();


				// Averiguar el grupo al que corresponde ese boton y colorearlos
				Console.WriteLine("Colorea");

				List<string> listaVecinos = new List<string>();

				PlQuery q = new PlQuery("conexionMatriz('" + nombre + "', C, V), atomic_list_concat([C,V], L)");
				foreach (PlQueryVariables p in q.SolutionVariables)
				{
					var Resp = p;
					listaVecinos.Add(p["C"].ToString());
				}
				q.Dispose();
				String[] lista = listaVecinos.ToArray();
				EncontrarGrupoDeBoton(lista, nombre);
			
		}



		private void EncontrarGrupoDeBoton(string[] lista, string botonSeleccionado)
        {
			listBox1.Items.Clear();
			//GrupoAColorear.Clear();
			PosicionesVisitadas.Clear();
			PosicionesVisitadas.Add(botonSeleccionado);
			PosicionesVisitadasMatriz.Add(botonSeleccionado);
			

			if (!verificaSiEstaEnGrupo(botonSeleccionado)){
				return;
			}
			GrupoAColorear.Add(botonSeleccionado);
			foreach (var item in lista)
            {
				bool EsGrupo = verificaSiEstaEnGrupo(item);
				if (EsGrupo)
				{
					GrupoAColorear.Add(item.ToString());
					PosicionesVisitadasMatriz.Add(item.ToString());
					//PosicionesVisitadas.Add(item.ToString());
					
					Console.WriteLine("Son del mismo grupo");
				}
				else {
					Console.WriteLine("No es grupo");
				}

			}
            if (GrupoAColorear.Count() == 1 )
            {
				listBox1.Items.Add("Grupo individual :" + botonSeleccionado);
            }
            else
            {
				listBox1.Items.Add("Inicio :" + botonSeleccionado);
                //// RECURSION POR VECINOS
                for (int i = 0; i < GrupoAColorear.Count(); i++)
                {
					PosicionesVisitadas.Add(GrupoAColorear[i]);
					PosicionesVisitadasMatriz.Add(GrupoAColorear[i]);
					listBox1.Items.Add("Grupo Vecinos :" + GrupoAColorear[i]);
					EncuentraVecinosGrupoRecursivo(GrupoAColorear[i]);
				}

			}
			Console.WriteLine(GrupoAColorear);
		}

		private void EncuentraVecinosGrupoRecursivo(string nombre)
        {
			List<string> posiciones = ObtenerListaFiltrada( RetonarVecinosBotonSeleccionado(nombre));
			if(posiciones.Count() == 0)
            {
				return;
            }
            else
            {
				foreach (var item in posiciones)
				{
					bool EsGrupo = verificaSiEstaEnGrupo(item.ToString());
					PosicionesVisitadas.Add(item.ToString());
					PosicionesVisitadasMatriz.Add(item.ToString());
					if (EsGrupo)
                    {
                        if (!GrupoAColorear.Contains(item.ToString()))
                       {
						GrupoAColorear.Add(item.ToString());
					}
						
						listBox1.Items.Add("Grupo vecinos recursivos :" + item.ToString());
						EncuentraVecinosGrupoRecursivo(item.ToString());
					}
					
				}
			}
            
		}

		private List<string> ObtenerListaFiltrada(List<string> lista)
        {
			List<string> filtrada = new List<string>();

			for (int i = 0; i < lista.Count(); i++)
            {

				if (!PosicionesVisitadas.Contains(lista[i].ToString()))
                {
					filtrada.Add(lista[i]);
                }
            }

			return filtrada;
        }

		private List<string> RetonarVecinosBotonSeleccionado(string nombre)
        {
			List<string> lista = new List<string>();
			PlQuery q = new PlQuery("conexionMatriz('" + nombre + "', C, V), atomic_list_concat([C,V], L)");
			foreach (PlQueryVariables p in q.SolutionVariables)
			{
				var Resp = p;
				lista.Add(p["C"].ToString());
			}
			q.Dispose();

			PlQuery r = new PlQuery("conexionMatriz(P, '" + nombre + "', V), atomic_list_concat([P,V], L)");
			foreach (PlQueryVariables p in r.SolutionVariables)
			{
				var Resp = p;
				lista.Add(p["P"].ToString());
			}
			q.Dispose();

			return lista;

		}


		private bool verificaSiEstaEnGrupo(string nombre) {

			PlQuery q = new PlQuery("grupo('" + nombre + "').");
			var cantidadSoluciones = q.SolutionVariables.Count();
			foreach (PlQueryVariables p in q.SolutionVariables)
			{
				var Resp = p;
				var aq = 0;
			}
			PlQuery consulta1 = new PlQuery("existeGrupo(Lista)");
			foreach (PlQueryVariables p in consulta1.SolutionVariables)
				Console.WriteLine("a");
				//listBox1.Items.Add("");
			consulta1.Dispose();
			q.Dispose();
			if (cantidadSoluciones == 0)
			{
				return false;
			}
			else
			{
				return true;
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
					boton[i].Name = j.ToString()+ "-" + i.ToString();
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
			

		}

        private void button2_Click(object sender, EventArgs e)
        {
			EncontrarGruposMatriz();
        }

		private void EncontrarGruposMatriz()
        {
			PosicionesVisitadasMatriz.Clear();  // Lista de posiciones de la matriz
			listBox3.Items.Clear();

			for (int i = 0; i < PosicionesMatriz.Count(); i++)
            {
				string posc = PosicionesMatriz[i];
                if (!PosicionesVisitadasMatriz.Contains(posc))
                {
					PosicionesVisitadasMatriz.Add(posc);
					ObtenerGrupoRecursivo(posc);
					Console.WriteLine(GrupoAColorear);
					if(GrupoAColorear.Count() > 0)
                    {
						listBox3.Items.Add("Grupo hallado de tamaño" + GrupoAColorear.Count());
                    }
				
					GrupoAColorear.Clear();
					//PosicionesVisitadas.Clear();
				}

			}
        }

	}
}
