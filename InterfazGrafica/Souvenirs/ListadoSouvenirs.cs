using Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.Servicios;

namespace InterfazGrafica.Souvenirs
{
    public partial class ListadoSouvenirs : Form
    {
        public MenuPrincipal padre;

        public ListadoSouvenirs(MenuPrincipal padre)
        {
            this.padre = padre;
            InitializeComponent();
        }

        private void btnNuevoSouvenir_Click(object sender, EventArgs e)
        {
            nuevoSouvenir frmNuevoSouvenir = new nuevoSouvenir();
            frmNuevoSouvenir.Text = "Nuevo Souvenir";
            frmNuevoSouvenir.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.tablaSouvenirs.Rows.Clear();
                ServicioSouvenirs servi = new ServicioSouvenirs();
                List<Souvenir> souvenirs = servi.listarSouvenirs();

                foreach (Souvenir s in souvenirs)
                {
                    string[] newRow = new string[] { s.Id.ToString(), s.Nombre, s.Descripcion, s.Stock.ToString(), s.Precio.ToString(), s.FechaAlta.ToString() };
                    this.tablaSouvenirs.Rows.Add(newRow);
                }
                this.tablaSouvenirs.Refresh();
            }catch(Exception ex)
            {
                MessageBox.Show("Error al actualizar la tabla de souvenirs");
            }
            
        }

        private void ListadoSouvenirs_Load(object sender, EventArgs e)
        {
            
        }

        private void tablaSouvenirs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int idSouvenir = Int32.Parse(tablaSouvenirs.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (e.ColumnIndex == tablaSouvenirs.Columns["editar"].Index && e.RowIndex >= 0)
                {
                    nuevoSouvenir frmNuevoSouvenir = new nuevoSouvenir(idSouvenir);
                    frmNuevoSouvenir.Text = "Editar Souvenir  ID: " + idSouvenir;
                    frmNuevoSouvenir.ShowDialog();
                }
                else if (e.ColumnIndex == tablaSouvenirs.Columns["eliminar"].Index && e.RowIndex >= 0)
                {
                    if (this.padre.serviSouvenirs.bajaSouvenir(idSouvenir))
                    {
                        MessageBox.Show("Souvenir eliminado");
                    }

                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error al eliminar el souvenir");
            }
            
        }
    }
}
