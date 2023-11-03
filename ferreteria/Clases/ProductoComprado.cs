using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferreteria.Clases;

public class ProductoComprado 
{
    public int IdProducto { get; set; }
    public string NameProduct { get; set; }
    public Producto Productos { get; set; }
    public int IdCliente { get; set; }
    public Cliente Clientes { get; set; }
    public List<Producto> ListProductos { get; set; }
}
