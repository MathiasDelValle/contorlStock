using System;
using System.Windows.Forms;
using Dominio.Dominio;

namespace InterfazGrafica
{
    public partial class login : Form
    {

        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Dominio.Servicios.Autenticacion auth = new Dominio.Servicios.Autenticacion();
                Usuario usuLogeado = auth.login(txtUsuario.Text, txtPass.Text);
                MenuPrincipal frmMenu = new MenuPrincipal(this, usuLogeado);
                this.Hide();
                this.txtUsuario.Text = "";
                this.txtPass.Text = "";
                frmMenu.Show();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
