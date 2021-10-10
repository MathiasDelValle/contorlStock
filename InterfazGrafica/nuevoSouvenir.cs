using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.Dominio;
using Dominio.Servicios;

namespace InterfazGrafica
{
    public partial class nuevoSouvenir : Form
    {

        private int idSouvenir;

        public nuevoSouvenir(int id = 0)
        {
            this.idSouvenir = id;
            InitializeComponent();
        }


        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string desc = txtDescripcion.Text;
                int stock = (int)txtStock.Value;
                decimal precio = Decimal.Parse(txtPrecio.Text);

                if(String.IsNullOrEmpty(nombre) || stock < 0 || precio < 0)
                {
                    MessageBox.Show("Complete los campos requeridos.");
                    return;
                }

                ServicioSouvenirs s = new ServicioSouvenirs();
                if(s.altaSouvenir(this.idSouvenir, nombre, desc, stock, precio))
                {
                    MessageBox.Show("Souvenir cargado en el sistema");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("El souvenir no se pudo cargar");
                }
                

            }catch(Exception ex)
            {
                MessageBox.Show("Error al guardar el souvenir.");
            }
        }

        private void limpiar()
        {
            this.txtNombre.Text = "";
            this.txtDescripcion.Text = "";
            this.txtStock.Value = 0;
            this.txtPrecio.Text = "0";
        }

        private void nuevoSouvenir_Load(object sender, EventArgs e)
        {
            if (this.idSouvenir != 0)
            {
                ServicioSouvenirs s = new ServicioSouvenirs();
                Souvenir souv = s.obtenerSouvenir(idSouvenir);

                txtNombre.Text = souv.Nombre;
                txtDescripcion.Text = souv.Descripcion;
                txtStock.Value = souv.Stock;
                txtPrecio.Text = souv.Precio.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void nuevoSouvenir_FormClosing(object sender, FormClosingEventArgs e)
        {
            limpiar();
        }
    }
}
