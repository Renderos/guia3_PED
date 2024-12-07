using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Grafos
{
    public partial class Arco : Form
    {
        public bool control;
        public int dato;
        public Arco()
        {
            InitializeComponent();
            control = false;
            dato = 0;
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            control = false;
            Hide();
        }


        private void Arco_Load(object sender, EventArgs e)
        {
            txtPeso.Focus();
        }

        private void Arco_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void Arco_Shown(object sender, EventArgs e)
        {
            txtPeso.Clear();
            txtPeso.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                dato = Convert.ToInt16(txtPeso.Text.Trim());

                if (dato <= 0)
                {
                    MessageBox.Show("El peso debe ser mayor a 0", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    control = true;
                    Hide();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("debes ingresar un valor númerico", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void txtPeso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(sender, e);
            }
        }
    }
}
