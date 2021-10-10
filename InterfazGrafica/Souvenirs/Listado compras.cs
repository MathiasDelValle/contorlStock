using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazGrafica.Souvenirs
{
    public partial class Listado_compras : Form
    {
        public Listado_compras()
        {
            InitializeComponent();
        }

        private void Listado_compras_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            nuevaCompra frmNuevaCompra = new nuevaCompra();
            frmNuevaCompra.ShowDialog();
        }
    }
}
