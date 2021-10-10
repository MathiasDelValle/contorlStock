using Dominio.Dominio;
using Dominio.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazGrafica
{
    public partial class nuevaCompra : Form
    {

        private Dominio.Servicios.ServicioSouvenirs servi = new Dominio.Servicios.ServicioSouvenirs();

        public nuevaCompra()
        {
            InitializeComponent();
        }

        private void nuevaCompra_Load(object sender, EventArgs e)
        {
            List<Souvenir> souvenirs = servi.listarSouvenirs(true);

            cmbSouvenir.DataSource = souvenirs;
            cmbSouvenir.DisplayMember = "nombre";
            cmbSouvenir.ValueMember = "id";

        }

        private void btnRealizarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                Souvenir souv = (Souvenir)cmbSouvenir.SelectedItem;
                int cant = Int32.Parse(txtCantidad.Text);

                if(souv == null || cant <= 0)
                {
                    MessageBox.Show("Debe completar los campos requeridos");
                    return;
                }

                if(souv.Stock == 0)
                {
                    MessageBox.Show("No hay stock disponible de " + souv.Nombre);
                    return;
                }

                ServicioCompras serviCompra = new ServicioCompras();

                bool compraRealizada = serviCompra.realizarCompra(ref souv, cant);

                if (compraRealizada)
                {
                    MessageBox.Show("Compra realizada correctamente.");
                }
                else
                {
                    MessageBox.Show("No se pudo realizar la compra");
                }

            }catch(Exception ex)
            {
                MessageBox.Show("Error al realizar la compra.");
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
