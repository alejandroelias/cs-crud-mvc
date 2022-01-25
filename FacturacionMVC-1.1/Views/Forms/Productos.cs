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
    public partial class Productos : Form
    {
        Controllers.ProductosController productosController = new Controllers.ProductosController();
        Views.Forms.ProductoNuevo productoNuevoForm = new ProductoNuevo();


        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            this.btnEliminarProducto.Enabled = false;
           //dgvProductos.DataSource = productosController.GetProductos();
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            productoNuevoForm = new ProductoNuevo(true);
            productoNuevoForm.ShowDialog();
        }

        private void btnActualizarProducto_Click(object sender, EventArgs e)
        {
            //this.dgvProductos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvProductos.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 
            dgvProductos.DataSource = productosController.GetProductos();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int intT = Convert.ToInt32(this.dgvProductos.SelectedRows[0].Cells[0].Value);
            string descripcionT = this.dgvProductos.SelectedRows[0].Cells[1].Value.ToString();
            int existenciaT = Convert.ToInt32(this.dgvProductos.SelectedRows[0].Cells[2].Value);

            productoNuevoForm = new ProductoNuevo(intT, descripcionT, existenciaT, true);
            productoNuevoForm.ShowDialog();
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            int intT = Convert.ToInt32(this.dgvProductos.SelectedRows[0].Cells[0].Value);

            DialogResult dResult = MessageBox.Show("Confirmar si de desea eliminar registro", "ARTICULOS", MessageBoxButtons.OKCancel);
            if (dResult == DialogResult.OK)
            {
                bool resultDeleteProduct = productosController.DeleteProductos(intT);
                if (resultDeleteProduct)
                    MessageBox.Show("Producto eliminado", "PRODUCTOS");
                else
                    MessageBox.Show("Error", "PRODUCTOS");
            }
            if (dResult == DialogResult.Cancel)
            {
                return;
            }

        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEliminarProducto.Enabled = true;
        }



     }
}
