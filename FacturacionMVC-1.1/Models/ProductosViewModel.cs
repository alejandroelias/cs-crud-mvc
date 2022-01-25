using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionMVC_1._1.Models
{
    class ProductosViewModel
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public string CodigoDescripcion
        {
            get { return Codigo.ToString() + "-" + Descripcion; }
        }
    }
}
