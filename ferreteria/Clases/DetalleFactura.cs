using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferreteria.Clases;

public class DetalleFactura : BaseEntity
{
    public int NroFactura { get; set; }
    public Factura Facturas { get; set; }
    public int IdProducto { get; set; }
    public Producto Productos { get; set; }
    public int Cantidad { get; set; }
    public double Valor { get; set; }
}
