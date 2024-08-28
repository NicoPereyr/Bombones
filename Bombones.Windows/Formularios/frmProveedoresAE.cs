using Bombones.Entidades.Entidades;

namespace Bombones.Windows.Formularios
{
    public partial class frmProveedoresAE : Form
    {
        private Proveedor? prov;
        public frmProveedoresAE()
        {
            InitializeComponent();
        }

        public Proveedor? GetProveedor()
        {
            return prov;
        }

        public void SetProveedor(Proveedor? prov)
        {
            this.prov = prov;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (prov != null)
            {
                txtProveedor.Text = prov.Descripcion;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (prov == null)
                {
                    prov = new Proveedor();
                }
                prov.Descripcion = txtProveedor.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtProveedor.Text))
            {
                valido = false;
                errorProvider1.SetError(txtProveedor, "El proveedor es requerido");
            }
            return valido;
        }

        private void frmProveedoresAE_Load(object sender, EventArgs e)
        {

        }

        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

