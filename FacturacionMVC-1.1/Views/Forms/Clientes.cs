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
    public partial class Clientes : Form
    {
        Controllers.ProductosController productoController = new Controllers.ProductosController();
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            //productoController.GetProductos();
        }
    }
}
