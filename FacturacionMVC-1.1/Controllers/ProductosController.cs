using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionMVC_1._1.Controllers
{
    class ProductosController
    {
        public List<Models.ProductosViewModel> GetProductos()
        {
            //Version IEnumerable
            //using (Models.DemoEntities data = new Models.DemoEntities())
            //{
            //    IEnumerable<Models.ProductosViewModel> productosList = (from tbl in data.ARTICULOS
            //                                                            select new Models.ProductosViewModel
            //                                                            {
            //                                                                Codigo = tbl.id_articulo,
            //                                                                Descripcion = tbl.descripcion,
            //                                                                Existencia = (int)tbl.existencia
            //                                                            }).ToList();
            //    return productosList;
            //}

            //Version IQueryable
            try
            {
                using (Models.DemoEntities dataContext = new Models.DemoEntities())
                {
                    IQueryable<Models.ProductosViewModel> ProductosList = from tbl in dataContext.ARTICULOS
                                                                          select new Models.ProductosViewModel
                                                                          {
                                                                              Codigo = tbl.id_articulo,
                                                                              Descripcion = tbl.descripcion,
                                                                              Existencia = (int)tbl.existencia
                                                                          };
                    return ProductosList.ToList();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<Models.ProductosViewModel> GetProductos(string txtFindCodigoT, string txtFindDescripcionT)
        {

            try
            {
                using (Models.DemoEntities dataContext = new Models.DemoEntities())
                {
                    var productoList = (from tbl in dataContext.ARTICULOS
                                        select new Models.ProductosViewModel
                                        {
                                            Codigo = tbl.id_articulo,
                                            Descripcion = tbl.descripcion,
                                            Existencia = (int)tbl.existencia
                                        }).AsQueryable();

                    if (!txtFindCodigoT.Equals(""))
                    {
                        int txtCodigoFinf = int.Parse(txtFindCodigoT);
                        productoList = productoList.Where(tbl => tbl.Codigo == txtCodigoFinf);
                    }
                    if (!txtFindDescripcionT.Equals(""))
                    {
                        productoList = productoList.Where(tbl => tbl.Descripcion.Contains(txtFindDescripcionT));
                    }

                    return productoList.ToList();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
        public bool PostProductos(string descripcionT, int existenciaT)
        {
            try
            {
                using (Models.DemoEntities dataContext = new Models.DemoEntities())
                {
                    Models.ARTICULOS articulos = new Models.ARTICULOS
                    {
                        //id_articulo
                        descripcion = descripcionT,
                        existencia = existenciaT
                    };
                    dataContext.ARTICULOS.Add(articulos);
                    dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool PutProductos(int idArticulo, string descripcionT, int existenciaT)
        {
            try
            {
                using (Models.DemoEntities dataContext = new Models.DemoEntities())
                {
                    Models.ARTICULOS articulos = dataContext.ARTICULOS.FirstOrDefault(tbl => tbl.id_articulo == idArticulo);
                    articulos.descripcion = descripcionT;
                    articulos.existencia = existenciaT;
                    dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;   
            }
        }
        public bool DeleteProductos(int idArticulo)
        {
            try
            {
                using (Models.DemoEntities dataContext = new Models.DemoEntities())
                {
                    Models.ARTICULOS articulos = dataContext.ARTICULOS.FirstOrDefault(tbl => tbl.id_articulo == idArticulo);
                    dataContext.ARTICULOS.Remove(articulos);
                    dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;   
            }
        }
    }
}
