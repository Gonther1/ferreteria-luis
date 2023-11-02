using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferreteria.Clases;

public class Factura : BaseEntity
{
    public DateOnly Fecha { get; set; }
    public int IdCliente { get; set; }
    public Cliente Clientes { get; set; }
    public double TotalFactura { get; set; }
}
