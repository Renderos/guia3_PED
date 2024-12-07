using System.Drawing;
using System.Windows.Forms;

namespace Grafos
{
    partial class Simulador
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Pizarra = new System.Windows.Forms.Panel();
            this.CMSCrearVertice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoVeérticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblarco = new System.Windows.Forms.Label();
            this.CBVertice = new System.Windows.Forms.ComboBox();
            this.CBArco = new System.Windows.Forms.ComboBox();
            this.btnEliminarVertice = new System.Windows.Forms.Button();
            this.btnEliminarArco = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAnchura = new System.Windows.Forms.Button();
            this.btnProfundidad = new System.Windows.Forms.Button();
            this.CBNodoPartida = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscarVertice = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDistancia = new System.Windows.Forms.Button();
            this.gbxDistancia = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CBFinal = new System.Windows.Forms.ComboBox();
            this.CBInicio = new System.Windows.Forms.ComboBox();
            this.CalcularRuta = new System.Windows.Forms.Button();
            this.CBInicioNodo = new System.Windows.Forms.ComboBox();
            this.lblRutaMasCorta = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblRuta = new System.Windows.Forms.Label();
            this.lblRespuesta = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CMSCrearVertice.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxDistancia.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(406, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "SIMULADOR DE GRAFOS";
            // 
            // Pizarra
            // 
            this.Pizarra.BackColor = System.Drawing.SystemColors.Control;
            this.Pizarra.Location = new System.Drawing.Point(13, 53);
            this.Pizarra.Name = "Pizarra";
            this.Pizarra.Size = new System.Drawing.Size(790, 789);
            this.Pizarra.TabIndex = 1;
            this.Pizarra.Paint += new System.Windows.Forms.PaintEventHandler(this.Pizarra_Paint);
            this.Pizarra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseDown);
            this.Pizarra.MouseLeave += new System.EventHandler(this.Pizarra_MouseLeave);
            this.Pizarra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseMove);
            this.Pizarra.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseUp);
            // 
            // CMSCrearVertice
            // 
            this.CMSCrearVertice.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMSCrearVertice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoVeérticeToolStripMenuItem});
            this.CMSCrearVertice.Name = "CMSCrearVertice";
            this.CMSCrearVertice.Size = new System.Drawing.Size(143, 26);
            this.CMSCrearVertice.Click += new System.EventHandler(this.CMSCrearVertice_Click);
            // 
            // nuevoVeérticeToolStripMenuItem
            // 
            this.nuevoVeérticeToolStripMenuItem.Name = "nuevoVeérticeToolStripMenuItem";
            this.nuevoVeérticeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.nuevoVeérticeToolStripMenuItem.Text = "Nuevo Nodo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(809, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vertice:";
            // 
            // lblarco
            // 
            this.lblarco.AutoSize = true;
            this.lblarco.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblarco.Location = new System.Drawing.Point(818, 88);
            this.lblarco.Name = "lblarco";
            this.lblarco.Size = new System.Drawing.Size(43, 19);
            this.lblarco.TabIndex = 1;
            this.lblarco.Text = "Arco";
            // 
            // CBVertice
            // 
            this.CBVertice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBVertice.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBVertice.FormattingEnabled = true;
            this.CBVertice.Location = new System.Drawing.Point(898, 45);
            this.CBVertice.Name = "CBVertice";
            this.CBVertice.Size = new System.Drawing.Size(158, 27);
            this.CBVertice.TabIndex = 2;
            // 
            // CBArco
            // 
            this.CBArco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBArco.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBArco.FormattingEnabled = true;
            this.CBArco.Location = new System.Drawing.Point(898, 80);
            this.CBArco.Name = "CBArco";
            this.CBArco.Size = new System.Drawing.Size(158, 27);
            this.CBArco.TabIndex = 3;
            // 
            // btnEliminarVertice
            // 
            this.btnEliminarVertice.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarVertice.Location = new System.Drawing.Point(1094, 47);
            this.btnEliminarVertice.Name = "btnEliminarVertice";
            this.btnEliminarVertice.Size = new System.Drawing.Size(102, 27);
            this.btnEliminarVertice.TabIndex = 4;
            this.btnEliminarVertice.Text = "Eliminar";
            this.btnEliminarVertice.UseVisualStyleBackColor = true;
            this.btnEliminarVertice.Click += new System.EventHandler(this.btnEliminarVertice_Click);
            // 
            // btnEliminarArco
            // 
            this.btnEliminarArco.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarArco.Location = new System.Drawing.Point(1094, 79);
            this.btnEliminarArco.Name = "btnEliminarArco";
            this.btnEliminarArco.Size = new System.Drawing.Size(102, 27);
            this.btnEliminarArco.TabIndex = 5;
            this.btnEliminarArco.Text = "Eliminar";
            this.btnEliminarArco.UseVisualStyleBackColor = true;
            this.btnEliminarArco.Click += new System.EventHandler(this.btnEliminarArco_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.groupBox1.Controls.Add(this.btnAnchura);
            this.groupBox1.Controls.Add(this.btnProfundidad);
            this.groupBox1.Controls.Add(this.CBNodoPartida);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(851, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 116);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recorridos";
            // 
            // btnAnchura
            // 
            this.btnAnchura.Location = new System.Drawing.Point(189, 58);
            this.btnAnchura.Name = "btnAnchura";
            this.btnAnchura.Size = new System.Drawing.Size(105, 33);
            this.btnAnchura.TabIndex = 3;
            this.btnAnchura.Text = "Anchura";
            this.btnAnchura.UseVisualStyleBackColor = true;
            this.btnAnchura.Click += new System.EventHandler(this.btnAnchura_Click);
            // 
            // btnProfundidad
            // 
            this.btnProfundidad.Location = new System.Drawing.Point(47, 58);
            this.btnProfundidad.Name = "btnProfundidad";
            this.btnProfundidad.Size = new System.Drawing.Size(116, 33);
            this.btnProfundidad.TabIndex = 2;
            this.btnProfundidad.Text = "Profundidad";
            this.btnProfundidad.UseVisualStyleBackColor = true;
            this.btnProfundidad.Click += new System.EventHandler(this.btnProfundidad_Click);
            // 
            // CBNodoPartida
            // 
            this.CBNodoPartida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBNodoPartida.FormattingEnabled = true;
            this.CBNodoPartida.Location = new System.Drawing.Point(149, 18);
            this.CBNodoPartida.Name = "CBNodoPartida";
            this.CBNodoPartida.Size = new System.Drawing.Size(166, 27);
            this.CBNodoPartida.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nodo de partida";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.PeachPuff;
            this.groupBox2.Controls.Add(this.txtBuscar);
            this.groupBox2.Controls.Add(this.btnBuscarVertice);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(851, 436);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 112);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(123, 25);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(171, 26);
            this.txtBuscar.TabIndex = 8;
            // 
            // btnBuscarVertice
            // 
            this.btnBuscarVertice.Location = new System.Drawing.Point(99, 64);
            this.btnBuscarVertice.Name = "btnBuscarVertice";
            this.btnBuscarVertice.Size = new System.Drawing.Size(128, 36);
            this.btnBuscarVertice.TabIndex = 4;
            this.btnBuscarVertice.Text = "Buscar";
            this.btnBuscarVertice.UseVisualStyleBackColor = true;
            this.btnBuscarVertice.Click += new System.EventHandler(this.btnBuscarVertice_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Vértice";
            // 
            // btnDistancia
            // 
            this.btnDistancia.Location = new System.Drawing.Point(100, 80);
            this.btnDistancia.Name = "btnDistancia";
            this.btnDistancia.Size = new System.Drawing.Size(105, 26);
            this.btnDistancia.TabIndex = 5;
            this.btnDistancia.Text = "Distancia";
            this.btnDistancia.UseVisualStyleBackColor = true;
            this.btnDistancia.Click += new System.EventHandler(this.btnDistancia_Click);
            // 
            // gbxDistancia
            // 
            this.gbxDistancia.BackColor = System.Drawing.Color.PeachPuff;
            this.gbxDistancia.Controls.Add(this.label5);
            this.gbxDistancia.Controls.Add(this.label6);
            this.gbxDistancia.Controls.Add(this.CBFinal);
            this.gbxDistancia.Controls.Add(this.CBInicio);
            this.gbxDistancia.Controls.Add(this.btnDistancia);
            this.gbxDistancia.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDistancia.Location = new System.Drawing.Point(851, 294);
            this.gbxDistancia.Name = "gbxDistancia";
            this.gbxDistancia.Size = new System.Drawing.Size(345, 118);
            this.gbxDistancia.TabIndex = 9;
            this.gbxDistancia.TabStop = false;
            this.gbxDistancia.Text = "Distancia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nodo partida";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Nodo destino";
            // 
            // CBFinal
            // 
            this.CBFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFinal.FormattingEnabled = true;
            this.CBFinal.Location = new System.Drawing.Point(171, 47);
            this.CBFinal.Name = "CBFinal";
            this.CBFinal.Size = new System.Drawing.Size(135, 27);
            this.CBFinal.TabIndex = 6;
            this.CBFinal.SelectedIndexChanged += new System.EventHandler(this.CBFinal_SelectedIndexChanged);
            // 
            // CBInicio
            // 
            this.CBInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBInicio.FormattingEnabled = true;
            this.CBInicio.Location = new System.Drawing.Point(9, 47);
            this.CBInicio.Name = "CBInicio";
            this.CBInicio.Size = new System.Drawing.Size(124, 27);
            this.CBInicio.TabIndex = 4;
            this.CBInicio.SelectedIndexChanged += new System.EventHandler(this.CBInicio_SelectedIndexChanged);
            // 
            // CalcularRuta
            // 
            this.CalcularRuta.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalcularRuta.Location = new System.Drawing.Point(228, 29);
            this.CalcularRuta.Margin = new System.Windows.Forms.Padding(2);
            this.CalcularRuta.Name = "CalcularRuta";
            this.CalcularRuta.Size = new System.Drawing.Size(98, 28);
            this.CalcularRuta.TabIndex = 11;
            this.CalcularRuta.Text = "Calcular ruta";
            this.CalcularRuta.UseVisualStyleBackColor = true;
            this.CalcularRuta.Click += new System.EventHandler(this.CalcularRuta_Click_1);
            // 
            // CBInicioNodo
            // 
            this.CBInicioNodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBInicioNodo.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBInicioNodo.FormattingEnabled = true;
            this.CBInicioNodo.Location = new System.Drawing.Point(22, 29);
            this.CBInicioNodo.Name = "CBInicioNodo";
            this.CBInicioNodo.Size = new System.Drawing.Size(181, 28);
            this.CBInicioNodo.TabIndex = 12;
            // 
            // lblRutaMasCorta
            // 
            this.lblRutaMasCorta.AutoSize = true;
            this.lblRutaMasCorta.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRutaMasCorta.Location = new System.Drawing.Point(18, 72);
            this.lblRutaMasCorta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRutaMasCorta.Name = "lblRutaMasCorta";
            this.lblRutaMasCorta.Size = new System.Drawing.Size(98, 20);
            this.lblRutaMasCorta.TabIndex = 13;
            this.lblRutaMasCorta.Text = "Resultado:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.PeachPuff;
            this.groupBox3.Controls.Add(this.CalcularRuta);
            this.groupBox3.Controls.Add(this.lblRutaMasCorta);
            this.groupBox3.Controls.Add(this.CBInicioNodo);
            this.groupBox3.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(851, 563);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(345, 147);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DIJKSTRA";
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(18, 71);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(0, 16);
            this.lblRuta.TabIndex = 15;
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.AutoSize = true;
            this.lblRespuesta.Location = new System.Drawing.Point(18, 30);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Size = new System.Drawing.Size(0, 16);
            this.lblRespuesta.TabIndex = 14;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.PeachPuff;
            this.groupBox4.Controls.Add(this.lblRuta);
            this.groupBox4.Controls.Add(this.lblRespuesta);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(851, 716);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(345, 126);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Resultados";
            // 
            // Simulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1233, 885);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbxDistancia);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblarco);
            this.Controls.Add(this.CBVertice);
            this.Controls.Add(this.CBArco);
            this.Controls.Add(this.btnEliminarVertice);
            this.Controls.Add(this.btnEliminarArco);
            this.Controls.Add(this.Pizarra);
            this.Controls.Add(this.label1);
            this.Name = "Simulador";
            this.Text = "Simulador";
            this.CMSCrearVertice.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxDistancia.ResumeLayout(false);
            this.gbxDistancia.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Panel Pizarra;
        private ContextMenuStrip CMSCrearVertice;
        private Label label2;
        private Label lblarco;
        private ComboBox CBVertice;
        private ComboBox CBArco;
        private Button btnEliminarVertice;
        private Button btnEliminarArco;
        private GroupBox groupBox1;
        private Button btnAnchura;
        private Button btnProfundidad;
        private ComboBox CBNodoPartida;
        private Label label3;
        private GroupBox groupBox2;
        private TextBox txtBuscar;
        private Button btnBuscarVertice;
        private Label label4;
        private Button btnDistancia;
        private GroupBox gbxDistancia;
        private Label label5;
        private Label label6;
        private ComboBox CBFinal;
        private ComboBox CBInicio;
        private ToolStripMenuItem nuevoVeérticeToolStripMenuItem;
        private Button CalcularRuta;
        private ComboBox CBInicioNodo;
        private Label lblRutaMasCorta;
        private GroupBox groupBox3;
        private Label lblRespuesta;
        private Label lblRuta;
        private GroupBox groupBox4;
    }
}