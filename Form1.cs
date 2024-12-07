using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Threading;

namespace Grafos
{
    public partial class Simulador : Form
    {
        private CGrafo grafo;
        private CVertice nuevoNodo;
        private CVertice NodoOrigen;
        private CVertice NodoDestino;
        private int var_control = 0;

        private Vertice ventanaVertice;
        private Arco ventanaArco;
        List<CVertice> nodosRuta;
        List<CVertice> nodosOrdenados;
        bool buscarRuta = false, nuevoVertice = false, nuevoArco = false;
        private int numeronodos = 0;
        bool profundidad = false, anchra = false, nodoEncontrado = false;
        Queue cola = new Queue();
        private string destino = "", origen = "";
        private int distancia = 0;



        private int[,] matrizDistancias; 
        private List<CVertice> caminoMasCorto;

        private StringBuilder rutaProfundidad;
        private StringBuilder rutaAnchura;
        public Simulador()
        {
            InitializeComponent();
            grafo = new CGrafo(); 
            nuevoNodo = null;
            var_control = 0;
            ventanaVertice = new Vertice();
            ventanaArco = new Arco();
            nodosRuta = new List<CVertice>();
            nodosOrdenados = new List<CVertice>();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            rutaProfundidad = new StringBuilder();
            rutaAnchura = new StringBuilder();
        }
        
        private void Pizarra_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                grafo.DibujarGrafo(e.Graphics);
                if (nuevoVertice)
                {
                    CBVertice.Items.Clear();
                    CBVertice.SelectedIndex = -1;
                    CBNodoPartida.Items.Clear();
                    CBNodoPartida.SelectedIndex = -1;
                    CBInicio.Items.Clear();
                    CBInicioNodo.SelectedIndex = -1;
                    CBInicioNodo.Items.Clear();
                    CBInicio.SelectedIndex = -1;
                    CBFinal.Items.Clear();
                    CBFinal.SelectedIndex = -1;
                    foreach (CVertice vertice in grafo.nodos)
                    {
                        CBVertice.Items.Add(vertice.Valor);
                        CBInicioNodo.Items.Add(vertice.Valor);
                        CBNodoPartida.Items.Add(vertice.Valor);
                        CBInicio.Items.Add(vertice.Valor);
                        CBFinal.Items.Add(vertice.Valor);
                    }
                    nuevoVertice = false;
                }

                if (nuevoArco)
                {
                    CBArco.Items.Clear();
                    CBArco.SelectedIndex = -1;
                    foreach (CVertice nodo in grafo.nodos)
                    {
                        foreach (CArco arco in nodo.ListaAdyacencia)
                            CBArco.Items.Add("(" + nodo.Valor + "," + arco.nDestino.Valor + ") peso: " + arco.peso);
                    }
                    nuevoArco = false;
                }

                if (buscarRuta)
                {
                    foreach (CVertice nodo in nodosRuta)
                    {
                        nodo.colorear(e.Graphics);
                        Thread.Sleep(1000);
                        nodo.DibujarVertice(e.Graphics);
                    }
                    buscarRuta = false;
                }
                if (profundidad)
                {
                    lblRuta.Text += rutaProfundidad.ToString();
                    profundidad = false;
                    //restablecer los valores
                    foreach (CVertice nodo in grafo.nodos)
                        nodo.Visitado = false;
                }
                if (anchra)
                {
                    lblRuta.Text += rutaAnchura.ToString();
                    anchra = false;
                    nodoEncontrado = false;
                    foreach (CVertice nodo in grafo.nodos)
                        nodo.Visitado = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void ordenarNodos()
        {
            nodosOrdenados = new List<CVertice>();
            bool est = false;
            foreach (CVertice nodo in grafo.nodos)
            {
                if (nodo.Valor == origen)
                {
                    nodosOrdenados.Add(nodo);
                    est = true;
                }
                else
                {
                    nodosOrdenados.Add(nodo);
                }
            }
            foreach (CVertice nodo in grafo.nodos)
            {
                if (nodo.Valor == origen)
                {
                    est = false;
                    break;
                }
                else if (est)
                    nodosOrdenados.Add(nodo);
            }
        }
        
        private void Pizarra_MouseLeave(object sender, EventArgs e)
        {
            Pizarra.Refresh();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
      
        private void CMSCrearVertice_Click(object sender, EventArgs e)
        {
            nuevoNodo = new CVertice();
            var_control = 2;
        }
  
        private void Pizarra_MouseUp(object sender, MouseEventArgs e)
        {
            switch (var_control)
            {
                case 1:
                   
                    if ((NodoDestino = grafo.DetectarPunto(e.Location)) != null && NodoOrigen != NodoDestino)
                    {
                        ventanaArco.Visible = false;
                        ventanaArco.control = false;
                        ventanaArco.ShowDialog();
                        if (ventanaArco.control)
                        {
                            if (grafo.AgregarArco(NodoOrigen, NodoDestino))
                            {
                                int distancia = ventanaArco.dato;
                                NodoOrigen.ListaAdyacencia.Find(v => v.nDestino == NodoDestino).peso = distancia;
                            }
                            nuevoArco = true;
                        }
                    }
                    var_control = 0;
                    NodoOrigen = null;
                    NodoDestino = null;
                    Pizarra.Refresh();
                    break;
            }

        }

      
        private void Pizarra_MouseMove(object sender, MouseEventArgs e)
        {
            switch (var_control)
            {
                case 2: 
                    if (nuevoNodo != null)
                    {
                      
                        int posX = e.Location.X;
                        int posY = e.Location.Y;

                        if (posX < nuevoNodo.Dimensiones.Width / 2)
                            posX = nuevoNodo.Dimensiones.Width / 2;

                        else if (posX > Pizarra.Size.Width - nuevoNodo.Dimensiones.Width / 2)
                            posX = Pizarra.Size.Width - nuevoNodo.Dimensiones.Width / 2;

                        if (posY < nuevoNodo.Dimensiones.Height / 2)
                            posY = nuevoNodo.Dimensiones.Height / 2;

                        else if (posY > Pizarra.Size.Height - nuevoNodo.Dimensiones.Height / 2)
                            posY = Pizarra.Size.Height - nuevoNodo.Dimensiones.Height / 2;

                       
                        nuevoNodo.posicion = new Point(posX, posY);
                        Pizarra.Refresh();
                        nuevoNodo.DibujarVertice(Pizarra.CreateGraphics());
                    }
                    break;
                case 1: 
                    
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true);
                    bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle;
                    Pizarra.Refresh();
                    Pizarra.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2)
                    {
                        CustomEndCap = bigArrow
                    },
                    NodoOrigen.posicion, e.Location
                    );
                    break;

            }
        }
     
        private void Pizarra_MouseDown(object sender, MouseEventArgs e)
        {


            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                {
                    var_control = 1;
                }
                if (nuevoNodo != null && NodoOrigen == null)
                {
                    
                    ventanaVertice.Visible = false;
                    ventanaVertice.control = false;
                    
                    ventanaVertice.ShowDialog();

                    if (ventanaVertice.control)
                    {
                        
                        if (grafo.BuscarVertice(ventanaVertice.txtVertice.Text) == null)
                        {
                            grafo.AgregarVertice(nuevoNodo);
                            nuevoNodo.Valor = ventanaVertice.txtVertice.Text;
                        }
                        else
                        {
                            MessageBox.Show("el nodo " + ventanaVertice.txtVertice.Text + " ya existe en el grafo", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    nuevoNodo = null;
                    nuevoVertice = true;
                    var_control = 0;
                    Pizarra.Refresh();
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (var_control == 0)
                {

                    if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                    {
                        CMSCrearVertice.Text = "nodo " + NodoOrigen.Valor;
                    }
                    else
                    {
                        Pizarra.ContextMenuStrip = this.CMSCrearVertice;
                    }
                }
            }



        }
        
        private void CMSEliminarVertice_Click_1(object sender, EventArgs e)
        {
            nuevoNodo = new CVertice();
            var_control = 2;
        }



        private void eliminarArcoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (NodoOrigen != null && NodoDestino != null)
            {
                
                grafo.EliminarArco(NodoOrigen, NodoDestino);

                
                Pizarra.Refresh();
            }
            else
            {
                MessageBox.Show("Selecciona un nodo de origen y uno de destino para eliminar el arco.");
                var_control = 0;
            }
        }



        private void eliminarVérticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NodoOrigen != null)
            {
               
                grafo.nodos.Remove(NodoOrigen);
                foreach (var nodo in grafo.nodos)
                {
                    nodo.ListaAdyacencia.RemoveAll(arco => arco.nDestino == NodoOrigen);
                }
                NodoOrigen = null;
                Pizarra.Refresh();

                
                var_control = 0;
            }
        }

        private void btnEliminarVertice_Click(object sender, EventArgs e)
        {
            if (CBVertice.SelectedIndex > -1)
            {
                foreach (CVertice nodo in grafo.nodos)
                {
                    if (nodo.Valor == CBVertice.SelectedItem.ToString())
                    {
                        grafo.nodos.Remove(nodo);
                        nodo.ListaAdyacencia = new List<CArco>();
                        break;
                    }
                }
                foreach (CVertice nodo in grafo.nodos)
                {
                    foreach (CArco arco in nodo.ListaAdyacencia)
                    {
                        if (arco.nDestino.Valor == CBVertice.SelectedItem.ToString())
                        {
                            nodo.ListaAdyacencia.Remove(arco);
                            break;
                        }
                    }
                }
                nuevoArco = true;
                nuevoVertice = true;
                CBVertice.SelectedIndex = -1;
                Pizarra.Refresh();
            }
            else
            {
                lblRespuesta.Text = "seleccione un nodo";
                lblRespuesta.ForeColor = Color.Red;
            }
        }

        private void btnEliminarArco_Click(object sender, EventArgs e)
        {
            if (CBArco.SelectedIndex > -1)
            {
                foreach (CVertice nodo in grafo.nodos)
                {
                    foreach (CArco arco in nodo.ListaAdyacencia)
                    {
                        if ("(" + nodo.Valor + "," + arco.nDestino.Valor + ") peso:" + arco.peso == CBArco.SelectedItem.ToString())
                        {
                            nodo.ListaAdyacencia.Remove(arco);
                            break;
                        }
                    }
                }
                nuevoVertice = true;
                nuevoArco = true;
                CBArco.SelectedIndex = -1;
                Pizarra.Refresh();
            }
            else
            {
                lblRespuesta.Text = "seleccione un arco";
                lblRespuesta.ForeColor = Color.Red;
            }
        }
        private void reocrridoProfundidad(CVertice vertice, Graphics g)
        {
            vertice.Visitado = true;
            rutaProfundidad.Append(vertice.Valor).Append(" -> ");
            vertice.colorear(g);
            Thread.Sleep(1000);
            vertice.DibujarVertice(g);
            foreach (CArco adya in vertice.ListaAdyacencia)
            {
                if (!adya.nDestino.Visitado) reocrridoProfundidad(adya.nDestino, g);
            }
        }
        private void recorridoAnchura(CVertice vertice, Graphics g, string destino)
        {
            vertice.Visitado = true;
            cola.Enqueue(vertice);
            rutaAnchura.Append(vertice.Valor).Append(" -> ");
            vertice.colorear(g);
            Thread.Sleep(1000);
            vertice.DibujarVertice(g);
            if (vertice.Valor == destino)
            {
                nodoEncontrado = true;
                return;
            }
            while (cola.Count > 0)
            {
                CVertice AUX = (CVertice)cola.Dequeue();
                foreach (CArco adya in AUX.ListaAdyacencia)
                {
                    if (!adya.nDestino.Visitado)
                    {
                        if (!nodoEncontrado)
                        {
                            adya.nDestino.Visitado = true;
                            rutaAnchura.Append(adya.nDestino.Valor).Append(" -> ");
                            adya.nDestino.colorear(g);
                            Thread.Sleep(1000);
                            adya.nDestino.DibujarVertice(g);
                            if (destino != "")
                            {
                                distancia += adya.peso;
                            }
                            cola.Enqueue(adya.nDestino);
                            if (adya.nDestino.Valor == destino)
                            {
                                nodoEncontrado = true;
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void btnProfundidad_Click(object sender, EventArgs e)
        {
            if (CBNodoPartida.SelectedIndex > -1)
            {
                profundidad = true;
                origen = CBNodoPartida.SelectedItem.ToString();
                Pizarra.Refresh();
                CBNodoPartida.SelectedIndex = -1;
                rutaProfundidad.Clear();
                reocrridoProfundidad(grafo.BuscarVertice(origen), Pizarra.CreateGraphics()); 
                lblRuta.Text = "Ruta Profundidad: " + rutaProfundidad.ToString();
            }
            else
            {
                lblRespuesta.Text = "Seleccione un nodo de partida";
                lblRespuesta.ForeColor = Color.Red;
            }
        }

        private void btnAnchura_Click(object sender, EventArgs e)
        {
            if (CBNodoPartida.SelectedIndex > -1)
            {
                anchra = true;
                origen = CBNodoPartida.SelectedItem.ToString();
                Pizarra.Refresh();
                CBNodoPartida.SelectedIndex = -1;
                rutaAnchura.Clear();
                recorridoAnchura(grafo.BuscarVertice(origen), Pizarra.CreateGraphics(), ""); 
                lblRuta.Text = "Ruta Anchura: " + rutaAnchura.ToString();
            }
            else
            {
                lblRespuesta.Text = "Seleccione un nodo de partida";
                lblRespuesta.ForeColor = Color.Red;
            }
        }

        private void btnBuscarVertice_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() != "")
            {
                if (grafo.BuscarVertice(txtBuscar.Text) != null)
                {
                    lblRespuesta.Text = "si se encuentra el vertice " + txtBuscar.Text;
                    lblRespuesta.ForeColor = Color.Red;
                }
                else
                {
                    lblRespuesta.Text = "no se encuentra el vertice " + txtBuscar.Text;
                    lblRespuesta.ForeColor = Color.Red;
                }
            }
        }


        private int totalNodos;
        int[] parents;
        bool[] visitados;

        private void calcularMatricesIniciales()
        {
            nodosRuta = new List<CVertice>();
            totalNodos = grafo.nodos.Count;
            parents = new int[totalNodos];
            visitados = new bool[totalNodos];

            
            for (int i = 0; i < totalNodos; i++)
            {
                List<int> filaDistancia = new List<int>();
                for (int j = 0; j < totalNodos; j++)
                {
                    if (i == j)
                    {
                        filaDistancia.Add(0);

                    }
                    else
                    {
                        int distancia = -1;
                        for (int k = 0; k < grafo.nodos[i].ListaAdyacencia.Count; k++)
                        {
                            if (grafo.nodos[i].ListaAdyacencia[k].nDestino == grafo.nodos[j])
                                distancia = grafo.nodos[i].ListaAdyacencia[k].peso;
                        }
                        filaDistancia.Add(distancia);
                    }
                }
            }
        }

        

        private void btnDistancia_Click(object sender, EventArgs e)
        {
            CalcularDistancia();
        }

        

        private void CalcularDistancia()
        {
            if (CBInicio.SelectedIndex == -1 || CBFinal.SelectedIndex == -1)
            {
                lblRespuesta.Text = "Seleccione un nodo de inicio y uno de final";
                lblRespuesta.ForeColor = Color.Red;
                return;
            }

            string inicio = CBInicio.SelectedItem.ToString();
            string final = CBFinal.SelectedItem.ToString();

            int inicioIndex = grafo.BuscarIndiceVertice(inicio);
            int finalIndex = grafo.BuscarIndiceVertice(final);

            if (inicioIndex == -1 || finalIndex == -1)
            {
                lblRespuesta.Text = "Los nodos seleccionados no existen en el grafo";
                lblRespuesta.ForeColor = Color.Red;
                return;
            }

            if (matrizDistancias == null)
            {
                
                CalcularMatrizDistancias();
            }

            int distancia = matrizDistancias[inicioIndex, finalIndex];
            if (distancia == -1)
            {
                lblRespuesta.Text = "No hay camino entre los nodos seleccionados";
                lblRespuesta.ForeColor = Color.Red;
            }
            else
            {
                lblRespuesta.Text = $"La distancia entre {inicio} y {final} es: {distancia}";
                lblRespuesta.ForeColor = Color.Black;
            }
        }

        private void CalcularMatrizDistancias()
        {
            int totalNodos = grafo.nodos.Count;
            matrizDistancias = new int[totalNodos, totalNodos];

           
            for (int i = 0; i < totalNodos; i++)
            {
                for (int j = 0; j < totalNodos; j++)
                {
                    matrizDistancias[i, j] = -1;
                }
            }

        
            foreach (CVertice nodo in grafo.nodos)
            {
                int origenIndex = grafo.BuscarIndiceVertice(nodo.Valor);
                foreach (CArco arco in nodo.ListaAdyacencia)
                {
                    int destinoIndex = grafo.BuscarIndiceVertice(arco.nDestino.Valor);
                    matrizDistancias[origenIndex, destinoIndex] = arco.peso;
                }
            }

           
            for (int k = 0; k < totalNodos; k++)
            {
                for (int i = 0; i < totalNodos; i++)
                {
                    for (int j = 0; j < totalNodos; j++)
                    {
                        if (matrizDistancias[i, k] != -1 && matrizDistancias[k, j] != -1 &&
                            (matrizDistancias[i, j] == -1 || matrizDistancias[i, j] > matrizDistancias[i, k] + matrizDistancias[k, j]))
                        {
                            matrizDistancias[i, j] = matrizDistancias[i, k] + matrizDistancias[k, j];
                        }
                    }
                }
            }
        }


        

        private void CalcularRuta_Click_1(object sender, EventArgs e)
        {
          
            string origen = CBInicioNodo.SelectedItem.ToString();
            List<CVertice> caminoMasCorto = grafo.Dijkstra(origen);

            
            foreach (CVertice nodo in caminoMasCorto)
            {
                lblRutaMasCorta.Text += nodo.Valor + " -> ";
            }
        }


        
        private void LimpiarDistancias()
        {
            matrizDistancias = null;
            caminoMasCorto = null;
        }
        
        private void CBInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarDistancias();
        }

       
        private void CBFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarDistancias();
        }
    }
}
