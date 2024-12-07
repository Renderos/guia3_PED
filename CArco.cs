using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    class CArco
    {
        public CVertice nDestino;
        public int peso;

        public float grosor_flecha;
        public Color color;

        public CArco(CVertice destino, int peso)
        {
            nDestino = destino;
            this.peso = peso;
            grosor_flecha = 2;
            color = Color.Blue;
        }
        public CArco(CVertice destino) : this(destino, 1)
        {
            nDestino = destino;
        }
    }
}
