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
    List<List<String>> AllGrupos = new List<List<String>>(); //
    Button[] boton;

    public Form1()
    { 
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      Environment.SetEnvironmentVariable("Path", @"C:\\Program Files (x86)\\swipl\\bin");
      string[] p = { "-q", "-f", @"grafos.pl" };
      PlEngine.Initialize(p);
      listBox1.Visible = false;
      listBox2.Visible = false;
      listBox3.Visible = false;
      label3.Visible = false;
      label4.Visible = false;
      label5.Visible = false;
      listBox4.Visible = false;
      label5.Visible = false;
      button5.Visible = false;
      button2.Visible = false;
      button3.Visible = false;
       

        }


    /// <summary>
    /// Se insertan en Prolog las conexiones de todos los nodos de la matriz para verificar luego por los grupos vecinos
    /// </summary>
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
            PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x2 + "-" + y + "', false)).");
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
          {   // 1,0 .... 0,0 ....2,0
            var x2 = x - 1;
            var x3 = x + 1;
            var y2 = y + 1;

            PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x2 + "-" + y + "', false)).");
            PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x3 + "-" + y + "', false)).");
            PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x + "-" + y2 + "', false)).");
                        var a = 0;
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
            var y3 = y + 1;    //1,1     .......  1,0  2,1 ...0,1  1,2
            var y2 = y - 1;


            PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x2 + "-" + y + "', false)).");
            PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x + "-" + y3 + "', false)).");
            PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x + "-" + y2 + "', false)).");
            PlQuery.PlCall("assert(conexionMatriz('" + x + "-" + y + "','" + x3 + "-" + y + "', false)).");
                        var ra = 7;
            continue;
          }

        }
      }
      
      solution();
      cargar.Dispose();

    }


    /// <summary>
    /// Se consulta en Prolog las conexiones realizadas
    /// </summary>
    public void solution() {
      PlQuery cargar = new PlQuery("cargar('grafos.bd')");
      cargar.NextSolution();
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
      cargar.Dispose();
    }



    /// <summary>
    /// Al dar click en un boton de la interfaz de matriz (Se colorea y asigna como grupo individual o sino 
    /// se buscan sus adyacentes de grupo)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void clickBoton(object sender, EventArgs e)
    {
      //string texto = (sender as Button).Text;
      string nombre = (sender as Button).Name;
      char fila = nombre[0];
      char columna = nombre[2];
       ReseatearColroesVerdes();

      if ((sender as Button).Text == "")
      {
        ((Button)sender).BackColor = Color.Green;
        ((Button)sender).Text = (sender as Button).Text;

      }

      bool EsGrupo = verificaSiEstaEnGrupo(nombre);
      if (!EsGrupo)
      {
        PlQuery cargar = new PlQuery("cargar('grafos.bd')");
        cargar.NextSolution();
        //Si no esta en grupo , se agrega a Prolog
        PlQuery q = new PlQuery("insertaGrupo('" + nombre + "')");
        foreach (PlQueryVariables p in q.SolutionVariables)
        {
          var Resp = p;
        }
        q.Dispose();
        cargar.Dispose();
            }
            else
            {
        ObtenerGrupoRecursivo(nombre);
        ColorearBotones();
      }

      
    }
/// <summary>
    /// Obtiene los vecinos del boton de manera recursiva
    /// </summary>
    /// <param name="nombre"></param>
    public void ObtenerGrupoRecursivo(string nombre)
        {
      listBox1.Items.Clear();
      PosicionesVisitadas.Clear();
      GrupoAColorear.Clear();


        // Averiguar el grupo al que corresponde ese boton y colorearlos
        Console.WriteLine("Colorea");

        List<string> listaVecinos = new List<string>();
      PlQuery cargar = new PlQuery("cargar('grafos.bd')");
      cargar.NextSolution();
      PlQuery q = new PlQuery("conexionMatriz('" + nombre + "', C, V), atomic_list_concat([C,V], L)");
        foreach (PlQueryVariables p in q.SolutionVariables)
        {
          var Resp = p;
          listaVecinos.Add(p["C"].ToString());
        }
        q.Dispose();
      cargar.Dispose();
        String[] lista = listaVecinos.ToArray();
        EncontrarGrupoDeBoton(lista, nombre);
      
    }


    /// <summary>
    /// Se obtienen los primeros vecinos del boton presionado , sin recursividad. EN caso de ser tipo grupos, se realiza recursividad para 
    /// hallar el resto
    /// </summary>
    /// <param name="nombre"></param>
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


    /// <summary>
    /// Se consulta de manera recursiva al Backend de Prolog para consultar por los vecinos que son grupos
    /// </summary>
    /// <param name="nombre"></param>
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
/// <summary>
    /// Se evitan datos repetidos en lista
    /// </summary>
    /// <param name="lista"></param>
    /// <returns></returns>
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


    /// <summary>
    /// Se consulta  a Prolog por las posiciones adyacentes conectadas a ese boton
    /// </summary>
    /// <param name="nombre"></param>
    /// <returns></returns>
    private List<string> RetonarVecinosBotonSeleccionado(string nombre)
        {
      PlQuery cargar = new PlQuery("cargar('grafos.bd')");
      cargar.NextSolution();

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
      r.Dispose();

      cargar.Dispose();

      return lista;

    }


    /// <summary>
    /// Dado un nombre de boton (0_0 , 2_1), se verifica desde Prolog si este ya es un grupo individual
    /// </summary>
    /// <param name="nombre"></param>
    /// <returns></returns>
    private bool verificaSiEstaEnGrupo(string nombre) {

      PlQuery cargar = new PlQuery("cargar('grafos.bd')");
      cargar.NextSolution();

      PlQuery q = new PlQuery("grupo('" + nombre + "').");
      var cantidadSoluciones = q.SolutionVariables.Count();
      foreach (PlQueryVariables p in q.SolutionVariables)
      {
        var Resp = p;
      }
      PlQuery consulta1 = new PlQuery("existeGrupo(Lista)");
      foreach (PlQueryVariables p in consulta1.SolutionVariables)
        Console.WriteLine("a");
        //listBox1.Items.Add("");
      consulta1.Dispose();
      q.Dispose();
      cargar.Dispose();
      if (cantidadSoluciones == 0)
      {
        return false;
      }
      else
      {
        return true;
      }
    }


   private void FiltrarListaRepetidos()
        {
            List<string> SinRepetir = new List<string>();
            foreach (var item in GrupoAColorear)
            {
                if (!SinRepetir.Contains(item))
                {
                    SinRepetir.Add(item);
                }
            }
            GrupoAColorear = SinRepetir;
        }

    private void ColorearBotones()
        {
      listBox1.Items.Clear();
      FiltrarListaRepetidos();
      listBox1.Items.Add("Pertenece a un grupo de tamaño : " + GrupoAColorear.Count());

      for (int i = 0; i < GrupoAColorear.Count(); i++)
            {
        foreach (var item in boton)
        {
          if(item.Name == GrupoAColorear[i])
                    {
            listBox1.Items.Add(" *** " + GrupoAColorear[i]);
            item.BackColor = Color.Blue;
          }
        }
      }
            
        }



    /// <summary>
    /// Genera la matriz de botones dinamicamente 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnCreaMatriz_Click(object sender, EventArgs e)
    {

      try
      {
        var tamano = Int32.Parse(inputCantidad.Text);
        var x = 0;
        var y = 0;
        var n = 0;

         pnlCreaMatriz.Visible = false;
        pnlTablero.Visible = true;
        listBox1.Visible = true;
        listBox2.Visible = true;
        listBox3.Visible = true;
        label3.Visible = true;
        label4.Visible = true;
        label5.Visible = true;
        listBox4.Visible = true;
        label5.Visible = true;
        button5.Visible = true;
         button2.Visible = true;
        button3.Visible = true;
       //Button[] boton;
        boton = new Button[tamano * tamano];
        for (int j = 0; j < tamano; j++)
        {
          for (int i = 0; i < tamano; i++)
          {
            boton[n] = new Button();
            boton[n].Name = j.ToString() + "-" + i.ToString();
            boton[n].Height = 30;
            boton[n].Width = 40;
            boton[n].BackColor = Color.Gray;
            //boton[n].Text = name.ToString();
            boton[n].Font = new Font("Arial", 12);
            boton[n].Location = new Point(x, y);
            boton[n].Click += new EventHandler(clickBoton);

            pnlTablero.Controls.Add(boton[n]);
            n++;
            x = x + 30;
            //name++;
          }
          x = 0;
          y = y + 30;
        }

        ConexionesProlog();
      }
      catch (Exception)
      {
        MessageBox.Show("Puso letras o espacio en blanco");
        //throw;
      }



    }

    private void ReseatearColroesVerdes()
        {
            foreach (var item in AllGrupos)
            {
                foreach (var pos in item)
                {
                    foreach (var btn in boton)
                    {
                        if (btn.Name == pos)
                        {
                            btn.BackColor = Color.Green;
                        }
                }
                }
                
            }
        }

    private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            EncontrarGruposMatriz();
        }


    /// <summary>
    /// Se recorre cada posicion de boton para hallar grupos formados adyacentes desde Prolog
    /// </summary>
    private void EncontrarGruposMatriz()
        {
      PosicionesVisitadasMatriz.Clear();  // Lista de posiciones de la matriz
      listBox3.Items.Clear();
      AllGrupos.Clear();
      List<int> tamanosGrupos = new List<int>();

      for (int i = 0; i < PosicionesMatriz.Count(); i++)
            {
        string posc = PosicionesMatriz[i];
                if (!PosicionesVisitadasMatriz.Contains(posc))
                {
          PosicionesVisitadasMatriz.Add(posc);
          ObtenerGrupoRecursivo(posc);
          //Console.WriteLine(GrupoAColorear);
          if(GrupoAColorear.Count() > 0)
                    {
            List<string> copiaGrupos = new List<string>();
            foreach (var item in GrupoAColorear)
            {
              copiaGrupos.Add(item);
            }
            AllGrupos.Add(copiaGrupos);
            //listBox3.Items.Add("Grupo hallado de tamaño " + GrupoAColorear.Count());
            tamanosGrupos.Add(GrupoAColorear.Count());
                    }
          
          GrupoAColorear.Clear();
        }

      }
      ImprimirCantidadesGrupos(tamanosGrupos);
    }

    private void ImprimirCantidadesGrupos(List<int> tamanosGrupos)
        {
      listBox3.Items.Clear();
      List<int> repetidos = new List<int>();
      int count = 0;
      foreach (var item in tamanosGrupos)
            {
        int actual = item;
        count = 0;
                foreach (var j in tamanosGrupos)
                {  
          if (!repetidos.Contains(j) && j == item)
                    {
            count++;
                    }
                }
        if(count != 0)
                {
          listBox3.Items.Add("Cantidad de Grupo con tamaño " + item + " : " + count);
        }
        
        repetidos.Add(item);

            }
        }





    /// <summary>
    /// Elimina los grupos creados desde Prolog y setea los botones a color Gris
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {

      foreach (var item in boton)
      {
        item.BackColor = Color.Gray;
      }

      //GrupoAColorear.Clear();
      //PosicionesVisitadas.Clear();
      //PosicionesMatriz.Clear();
      //PosicionesVisitadasMatriz.Clear();

      PlQuery cargar = new PlQuery("cargar('grafos.bd')");
      cargar.NextSolution();

      PlQuery q = new PlQuery("eliminar(X).");
      foreach (PlQueryVariables p in q.SolutionVariables)
      {
        var Resp = p;
      }
      cargar.Dispose();
      q.Dispose();
            //PlQuery cargar = new PlQuery("retractall(grupo(X)).");
            //cargar.NextSolution();
            //cargar.Dispose();
      pnlTablero.Controls.Clear();
      pnlTablero.Controls.Clear();
      listBox1.Items.Clear();
      listBox2.Items.Clear();
      listBox3.Items.Clear();
      listBox4.Items.Clear();
      AllGrupos.Clear();
      GrupoAColorear.Clear();
      PosicionesVisitadas.Clear();
      PosicionesMatriz.Clear();
      PosicionesMatriz.Clear();
      listBox1.Visible = false;       
      listBox2.Visible = false;
      listBox3.Visible = false;
      listBox4.Visible = false;
      label3.Visible = false;
      label4.Visible = false;
      label5.Visible = false;
      button5.Visible = false;
      pnlCreaMatriz.Visible = true;    
      button3.Visible = false;
      button2.Visible = false;
      inputCantidad.Text = "";
      

        }
/// <summary>
    /// Creat tablero aleatorio
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button4_Click(object sender, EventArgs e)
    {

      try
      {


        var a = inputCantidad.Text.GetType();
        var tamano = Int32.Parse(inputCantidad.Text);
        var x = 0;
        var y = 0;
        var n = 0;

        pnlCreaMatriz.Visible = false;
        pnlTablero.Visible = true;
        listBox1.Visible = true;
        listBox2.Visible = true;
        listBox3.Visible = true;
        listBox4.Visible = true;
        label5.Visible = true;
        button5.Visible = true;
        button2.Visible = true;
        button3.Visible = true;


                //Button[] boton;
                boton = new Button[tamano * tamano];
        for (int j = 0; j < tamano; j++)
        {
          for (int i = 0; i < tamano; i++)
          {
            boton[n] = new Button();
            boton[n].Name = j.ToString() + "-" + i.ToString();
            boton[n].Height = 30;
            boton[n].Width = 40;
            boton[n].BackColor = Color.Gray;
            //boton[n].Text = name.ToString();
            boton[n].Font = new Font("Arial", 12);
            boton[n].Location = new Point(x, y);
            boton[n].Click += new EventHandler(clickBoton);

            int rnd = _random.Next(0, 5);
            pnlTablero.Controls.Add(boton[n]);
            if (rnd == 1)
            {
              boton[n].BackColor = Color.Green;
              boton[n].PerformClick();
            }
            n++;
            x = x + 30;
            //name++;
          }
          x = 0;
          y = y + 30;
        }

        ConexionesProlog();
      }
      catch (Exception)
      {
        MessageBox.Show("Puso letras o espacio en blanco");
        //throw;
      }


    }

    private void label3_Click(object sender, EventArgs e)
        {

        }

    private void ColorearGruposTamaño(int tamanño)

    {
      List<string> repetidos = new List<string>();
      for (int i = 0; i < AllGrupos.Count(); i++)
      {

        int tam = AllGrupos[i].Count();
        if (tam == tamanño)
        {
          listBox4.Items.Add("***********");
          foreach (var item in AllGrupos[i])
          {
            if (!repetidos.Contains(item.ToString()))
            {
              repetidos.Add(item.ToString());
              for (int j = 0; j < boton.Length; j++)
              {
                if (boton[j].Name == item.ToString())
                {

                  listBox4.Items.Add("- " + item.ToString());
                  if (tamanño == 1)
                  {
                    boton[j].BackColor = Color.Red;
                  }
                  else if (tamanño == 2)
                  {
                    boton[j].BackColor = Color.Black;
                  }
                  else if (tamanño == 3)
                  {
                    boton[j].BackColor = Color.BlueViolet;
                  }
                  else if (tamanño == 4)
                  {
                    boton[j].BackColor = Color.Brown;
                  }
                  else if (tamanño == 5)
                  {
                    boton[j].BackColor = Color.Bisque;
                  }
                  else
                  {
                    boton[j].BackColor = Color.Cornsilk;
                  }

                  break;
                }
              }
            }

          }
        }
      }
    }

    private void button5_Click(object sender, EventArgs e)
        {
            try {
                string selectedItem = "";
                listBox4.Items.Clear();
                if (listBox3.Items.Count > 0)
                {
                    int tamanoSeleccioando = Int32.Parse(listBox3.GetItemText(listBox3.SelectedItem).Split(' ')[5]);
                    ColorearGruposTamaño(tamanoSeleccioando);
                }
            } 
            catch {
                MessageBox.Show("Debe seleccionar un un grupo para que funcione");
            }
     

    }
    }
}