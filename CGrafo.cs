using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    class CGrafo
    {
        
        public List<CVertice> nodos;

        public CGrafo()
        {
            nodos = new List<CVertice>(); 
        }

     
        public CVertice AgregarVertice(string valor)
        {
            CVertice nodo = new CVertice(valor); 
            nodos.Add(nodo); 
            return nodo; 
        }

       
        public void AgregarVertice(CVertice nuevonodo)
        {
            nodos.Add(nuevonodo); 
        }

        
        public CVertice BuscarVertice(string valor)
        {
            return nodos.Find(n => n.Valor == valor); 
        }

       
        public bool AgregarArco(string origen, string nDestino, int peso = 1)
        {
            
            CVertice vOrigen, vnDestino;
            if ((vOrigen = nodos.Find(v => v.Valor == origen)) == null) 
            {
                throw new Exception("El nodo " + origen + " no existe dentro del grafo");
            }
            if ((vnDestino = nodos.Find(v => v.Valor == nDestino)) == null) 
            {
                throw new Exception("El nodo " + nDestino + " no existe dentro del grafo"); 
            }
            return AgregarArco(vOrigen, vnDestino, peso); 
        }


        public bool AgregarArco(CVertice origen, CVertice nDestino, int peso = 1)
        {
            if (origen.ListaAdyacencia.Find(v => v.nDestino == nDestino) == null) 
            {
                origen.ListaAdyacencia.Add(new CArco(nDestino, peso)); 
                return true; 
            }
            return false; 
        }
       
        public void DibujarGrafo(Graphics g)
        {
            foreach (CVertice nodo in nodos)
            {
                nodo.DibujarArcos(g);
            }
            foreach (CVertice nodo in nodos)
            {
                nodo.DibujarVertice(g); 
            }
        }

       
        public CVertice DetectarPunto(Point posicionMouse)
        {
            foreach (CVertice nodoActual in nodos)
            {
                if (nodoActual.DetectarPunto(posicionMouse)) 
                    return nodoActual; 
            }
            return null; 
        }

        public void RestablecerGrafo(Graphics g)
        {
            foreach (CVertice nodo in nodos)
            {
                nodo.Color = Color.White; 
                nodo.FontColor = Color.Black;
                foreach (CArco arco in nodo.ListaAdyacencia)
                {
                    arco.grosor_flecha = 1;
                    arco.color = Color.Black;
                }
            }
            DibujarGrafo(g); 
        }

        public bool EliminarVertice(string valor)
        {
            CVertice vertice = BuscarVertice(valor);
            if (vertice != null)
            {
                
                nodos.Remove(vertice);
               
                foreach (CVertice nodo in nodos)
                {
                    nodo.ListaAdyacencia.RemoveAll(arco => arco.nDestino == vertice);
                }
                return true;
            }
            return false;
        }
        public bool EliminarArco(CVertice origen, CVertice destino)
        {
           
            CVertice verticeOrigen = BuscarVertice(origen.Valor);
            CVertice verticeDestino = BuscarVertice(destino.Valor);

            if (verticeOrigen != null && verticeDestino != null)
            {
                
                return verticeOrigen.ListaAdyacencia.RemoveAll(arco => arco.nDestino == verticeDestino) > 0;
            }
            return false;
        }

        public bool ExisteArco(CVertice origen, CVertice destino)
        {

            CVertice nodoOrigen = nodos.Find(n => n == origen);
            if (nodoOrigen != null)
            {
                
                foreach (CArco arco in nodoOrigen.ListaAdyacencia)
                {
                    if (arco.nDestino == destino)
                    {
                        return true; 
                    }
                }
            }
            return false; 
        }

        internal bool EliminarArco(string valor1, string valor2)
        {
            throw new NotImplementedException();
        }


        public void ColorArista(string o, string d)
        {
            foreach (CVertice nodo in nodos)
            {
                foreach (CArco a in nodo.ListaAdyacencia)
                {
                    if (nodo.ListaAdyacencia != null & nodo.Valor == o && a.nDestino.Valor == d)
                    {
                        a.color = Color.Red;
                        a.grosor_flecha = 4;
                    }
                }
            }
        }
        public void Colorear(CVertice nodo)
        {
            nodo.Color = Color.AliceBlue;
            nodo.FontColor = Color.Black;
        }

        public CVertice nododistanciaminima()
        {
            int min = int.MaxValue;
            CVertice temp = null;
            foreach (CVertice origen in nodos)
            {
                if (origen.Visitado)
                {
                    foreach (CVertice destino in nodos)
                    {
                        if (!destino.Visitado)
                        {
                            foreach (CArco a in origen.ListaAdyacencia)
                            {
                                if (a.nDestino == destino && min > a.peso)
                                {
                                    min = a.peso;
                                    temp = destino;
                                }
                            }
                        }
                    }
                }
            }
            return temp;
        }

        public int posicionNodo(string Nodo)
        {
            for (int i = 0; i < nodos.Count; i++)
            {
                if (string.Compare(nodos[i].Valor, Nodo) == 0)
                    return i;
            }
            return -1;
        }



        public void DibujarEntrantes(CVertice nDestino)
        {
            foreach (CVertice nodo in nodos)
            {
                foreach (CArco a in nodo.ListaAdyacencia)
                {
                    if (nodo.ListaAdyacencia != null && nodo != nDestino)
                    {
                        if (a.nDestino == nDestino)
                        {
                            a.color = Color.Black;
                            a.grosor_flecha = 2;
                            break;
                        }
                    }
                }
            }
        }

        public void Desmarcar()
        {
            foreach (CVertice nodo in nodos)
            {
                nodo.Visitado = false;
                nodo.Padre = null;
                nodo.distancianodo = int.MaxValue;
                nodo.pesoasignados = false;
            }
        }
        public int BuscarIndiceVertice(string valor)
        {
            for (int i = 0; i < nodos.Count; i++)
            {
                if (nodos[i].Valor == valor)
                {
                    return i;
                }
            }
            return -1; 
        }

        public List<CVertice> Dijkstra(string origen)
        {
           
            List<CVertice> nodosNoVisitados = new List<CVertice>(nodos);
            Dictionary<CVertice, int> distancia = new Dictionary<CVertice, int>();
            Dictionary<CVertice, CVertice> padre = new Dictionary<CVertice, CVertice>();

           
            foreach (CVertice nodo in nodos)
            {
                distancia[nodo] = int.MaxValue;
                padre[nodo] = null;
            }
            distancia[BuscarVertice(origen)] = 0;

            while (nodosNoVisitados.Count > 0)
            {
                
                CVertice nodoActual = null;
                int minDistancia = int.MaxValue;
                foreach (CVertice nodo in nodosNoVisitados)
                {
                    if (distancia[nodo] < minDistancia)
                    {
                        minDistancia = distancia[nodo];
                        nodoActual = nodo;
                    }
                }

               
                nodosNoVisitados.Remove(nodoActual);

                
                foreach (CArco arco in nodoActual.ListaAdyacencia)
                {
                    CVertice vecino = arco.nDestino;
                    int peso = arco.peso;
                    int nuevaDistancia = distancia[nodoActual] + peso;
                    if (nuevaDistancia < distancia[vecino])
                    {
                        distancia[vecino] = nuevaDistancia;
                        padre[vecino] = nodoActual;
                    }
                }
            }

      
            List<CVertice> caminoMasCorto = new List<CVertice>();
            foreach (CVertice nodo in nodos)
            {
                if (nodo != BuscarVertice(origen))
                {
                    CVertice nodoActual = nodo;
                    while (nodoActual != null)
                    {
                        caminoMasCorto.Insert(0, nodoActual);
                        nodoActual = padre[nodoActual];
                    }
                    nodo.distancianodo = distancia[nodo];
                }
            }
            return caminoMasCorto;
        }



    }
}
