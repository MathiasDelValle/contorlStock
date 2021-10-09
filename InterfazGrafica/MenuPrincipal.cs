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

namespace InterfazGrafica
{
    public partial class MenuPrincipal : Form
    {

        public Usuario usuLogeado;
        public login frmLogin;

        public MenuPrincipal(login frmPadre, Usuario usuLogeado)
        {
            this.frmLogin = frmPadre;
            this.usuLogeado = usuLogeado;
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuarioLogeado.Text = usuLogeado.getNombre();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmLogin.Show();
            this.Dispose();

        }

        private void souvenirsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoSouvenirs listadoSouvenirs = new ListadoSouvenirs();
            listadoSouvenirs.TopLevel = false;
            this.panelForm.Controls.Add(listadoSouvenirs);
            listadoSouvenirs.Show();
        }
    }
}
