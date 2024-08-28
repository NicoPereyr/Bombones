using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using Bombones.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Bombones.Windows.Formularios
{
    public partial class frmProveedores : Form
    {
        private readonly IServiciosProveedores? _servicio;
        private List<Proveedor>? lista;
        public frmProveedores(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _servicio = serviceProvider?.GetService<IServiciosProveedores>()
                ?? throw new ApplicationException("Dependencias no cargadas!!!");
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmProveedoresAE frm = new frmProveedoresAE() { Text = "Agregar Proveedor" };
            DialogResult dr = frm.ShowDialog(this);
            try
            {
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                Proveedor? prov = frm.GetProveedor();
                if (prov is not null)
                {
                    if (!_servicio!.Existe(prov))
                    {
                        _servicio!.Guardar(prov);
                        DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                        GridHelper.SetearFila(r, prov);
                        GridHelper.AgregarFila(r, dgvDatos);
                        MessageBox.Show("Registro agregado",
                            "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Proveedor Duplicado!!!",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Proveedor prov = (r.Tag as Proveedor) ?? new Proveedor();

            try
            {
                DialogResult dr = MessageBox.Show($@"¿Desea dar de baja el proveedor {prov.Descripcion}?",
                        "Confirmar Baja",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Proveedor? prov = (r.Tag as Proveedor) ?? new Proveedor();
            frmProveedoresAE frm = new frmProveedoresAE() { Text = "Editar Proveedor" };
            frm.SetProveedor(prov);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                prov = frm.GetProveedor();
                if (prov is null) return;
                if (!_servicio!.Existe(prov))
                {
                    _servicio!.Guardar(prov);

                    GridHelper.SetearFila(r, prov);
                    MessageBox.Show("Registro modificado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Proveedor Duplicado!!!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

            }
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicio!.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            if (lista is not null)
            {
                foreach (var item in lista)
                {
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, item);
                    GridHelper.AgregarFila(r, dgvDatos);
                }

            }
        }
    }
}
