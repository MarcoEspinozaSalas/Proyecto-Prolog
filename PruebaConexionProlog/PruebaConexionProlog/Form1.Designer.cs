
namespace PruebaConexionProlog
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCreaMatriz = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.inputCantidad = new System.Windows.Forms.TextBox();
            this.btnCreaMatriz = new System.Windows.Forms.Button();
            this.pnlTablero = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.pnlCreaMatriz.SuspendLayout();
            this.pnlTablero.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(63, 570);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Conexion Prolog";
            // 
            // pnlCreaMatriz
            // 
            this.pnlCreaMatriz.Controls.Add(this.button4);
            this.pnlCreaMatriz.Controls.Add(this.label2);
            this.pnlCreaMatriz.Controls.Add(this.inputCantidad);
            this.pnlCreaMatriz.Controls.Add(this.btnCreaMatriz);
            this.pnlCreaMatriz.Location = new System.Drawing.Point(209, 15);
            this.pnlCreaMatriz.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlCreaMatriz.Name = "pnlCreaMatriz";
            this.pnlCreaMatriz.Size = new System.Drawing.Size(367, 123);
            this.pnlCreaMatriz.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(183, 76);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(152, 28);
            this.button4.TabIndex = 3;
            this.button4.Text = "Crear aleatorio";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tamaño de tablero";
            // 
            // inputCantidad
            // 
            this.inputCantidad.Location = new System.Drawing.Point(147, 42);
            this.inputCantidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inputCantidad.Name = "inputCantidad";
            this.inputCantidad.Size = new System.Drawing.Size(89, 22);
            this.inputCantidad.TabIndex = 1;
            // 
            // btnCreaMatriz
            // 
            this.btnCreaMatriz.Location = new System.Drawing.Point(23, 76);
            this.btnCreaMatriz.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreaMatriz.Name = "btnCreaMatriz";
            this.btnCreaMatriz.Size = new System.Drawing.Size(152, 28);
            this.btnCreaMatriz.TabIndex = 0;
            this.btnCreaMatriz.Text = "Crear tablero aleatorio";
            this.btnCreaMatriz.UseVisualStyleBackColor = true;
            this.btnCreaMatriz.Click += new System.EventHandler(this.BtnCreaMatriz_Click);
            // 
            // pnlTablero
            // 
            this.pnlTablero.Controls.Add(this.button1);
            this.pnlTablero.Location = new System.Drawing.Point(64, 145);
            this.pnlTablero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTablero.Name = "pnlTablero";
            this.pnlTablero.Size = new System.Drawing.Size(745, 567);
            this.pnlTablero.TabIndex = 9;
            this.pnlTablero.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(831, 133);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(448, 308);
            this.listBox1.TabIndex = 10;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(1320, 133);
            this.listBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(448, 308);
            this.listBox2.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(779, 48);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(260, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "Hallar grupos en matriz";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 16;
            this.listBox3.Location = new System.Drawing.Point(831, 539);
            this.listBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(448, 308);
            this.listBox3.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1076, 48);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(260, 28);
            this.button3.TabIndex = 13;
            this.button3.Text = "Reintentar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1340, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Conexiones Matriz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(844, 518);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Numero y cantidad de grupos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(827, 103);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Grupo Actual del campo";
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.ItemHeight = 16;
            this.listBox4.Location = new System.Drawing.Point(1299, 587);
            this.listBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(291, 260);
            this.listBox4.TabIndex = 17;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1299, 539);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(232, 28);
            this.button5.TabIndex = 18;
            this.button5.Text = "Colorear y mostrar grupos";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1732, 864);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pnlTablero);
            this.Controls.Add(this.pnlCreaMatriz);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlCreaMatriz.ResumeLayout(false);
            this.pnlCreaMatriz.PerformLayout();
            this.pnlTablero.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel pnlCreaMatriz;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox inputCantidad;
		private System.Windows.Forms.Button btnCreaMatriz;
		private System.Windows.Forms.Panel pnlTablero;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.Button button5;
    }
}

