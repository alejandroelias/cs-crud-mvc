using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionMVC_1._1.Views.Forms
{
    public partial class ProductoNuevo : Form
    {
        Controllers.ProductosController productosController = new Controllers.ProductosController();
        private bool enableBtnModificar;
        private bool enableBtnNuevo;
        public ProductoNuevo()
        {
            InitializeComponent();
        }

        public ProductoNuevo(int ProductoId, string ProductoDescripcion, int ProductoExistencia, bool EnableModificarBtn)
        {
            InitializeComponent();
            txtCodigo.Text = ProductoId.ToString();
            txtDescripcion.Text = ProductoDescripcion;
            txtNExistencia.Value = ProductoExistencia;
            enableBtnModificar = EnableModificarBtn;
        }

        public ProductoNuevo(bool EnableNuevoBtn)
        {
            InitializeComponent();
            enableBtnNuevo = EnableNuevoBtn;
        }

        private void ProductoNuevo_Load(object sender, EventArgs e)
        {
            btnModificar.Enabled = false;

            if (enableBtnModificar == true && enableBtnNuevo ==false)
            {
                btnModificar.Enabled = true;
                btnGuardar.Enabled = false;
            }
            else if (enableBtnModificar == false && enableBtnNuevo ==true)
            {
                btnModificar.Enabled = false;
                btnGuardar.Enabled = true;
            }
        }
 

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.btnGuardar.Enabled = true;
            this.Close();
            this.txtCodigo.Text = "";
            this.txtDescripcion.Text = "";
            this.txtNExistencia.Text = "";
            //TODO: Cerrar actual, ver productos.
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int codigoT = int.Parse(this.txtCodigo.Text.Trim().ToString());
            string descripcionT = txtDescripcion.Text.Trim();
            int existenciaT = int.Parse(txtNExistencia.Text.ToString());

            bool resultUpdateProduct = productosController.PutProductos(codigoT, descripcionT, existenciaT);

            if (resultUpdateProduct)
                MessageBox.Show("Producto modificado", "PRODUCTOS");
            else
                MessageBox.Show("Error", "PRODUCTOS");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string descripcionT = txtDescripcion.Text.Trim();
            int existenciaT = int.Parse(txtNExistencia.Text.ToString());

            bool resultAddProduct = productosController.PostProductos(descripcionT, existenciaT);

            if (resultAddProduct)
                MessageBox.Show("Producto agregado", "PRODUCTOS");
            else
                MessageBox.Show("Error", "PRODUCTOS");
        }



    }
}
