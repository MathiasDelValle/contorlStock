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
using InterfazGrafica.Souvenirs;
using Dominio.Servicios;

namespace InterfazGrafica
{
    public partial class MenuPrincipal : Form
    {

        public Usuario usuLogeado;
        public login frmLogin;
        public ServicioSouvenirs serviSouvenirs;
        public ServicioCompras serviCompras;

        public MenuPrincipal(login frmPadre, Usuario usuLogeado)
        {
            this.frmLogin = frmPadre;
            this.usuLogeado = usuLogeado;
            this.serviSouvenirs = new ServicioSouvenirs();
            this.serviCompras = new ServicioCompras();
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuarioLogeado.Text = usuLogeado.getNombre();
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            timer1.Enabled = true;
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmLogin.Show();
            this.Dispose();
        }

        private void souvenirsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoSouvenirs frmListadoSouvenirs = new ListadoSouvenirs(this);
            frmListadoSouvenirs.TopLevel = false;
            List<Souvenir> souvenirs = serviSouvenirs.listarSouvenirs();

            foreach (Souvenir s in souvenirs)
            {
                string[] newRow = new string[] { s.Id.ToString(), s.Nombre, s.Descripcion, s.Stock.ToString(), s.Precio.ToString(), s.FechaAlta.ToString() };
                frmListadoSouvenirs.tablaSouvenirs.Rows.Add(newRow);
            }

            frmListadoSouvenirs.Parent = this;
            frmListadoSouvenirs.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTiempo.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.frmLogin.Show();
            this.Dispose();
        }
    }
}
