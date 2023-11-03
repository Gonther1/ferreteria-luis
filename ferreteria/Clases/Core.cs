using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferreteria.Clases;

public class Core
{
    // Data

    // Listado de productos - Inventario
    List<Producto> Inventario = new List<Producto>()
    {
        new Producto()
        {
            Id = 1,
            Nombre = "Caja de clavos",
            PrecioUnit = 2000,
            Cantidad = 10,
            StockMin = 5,
            StockMax = 100
        },
        new Producto()
        {
            Id = 2,
            Nombre = "Destornillador",
            PrecioUnit = 5000,
            Cantidad = 17,
            StockMin = 20,
            StockMax = 400
        },
        new Producto()
        {
            Id = 3,
            Nombre = "Martillo",
            PrecioUnit = 6000,
            Cantidad = 27,
            StockMin = 50,
            StockMax = 200
        }
    };

    // Listado de Clientes - ListClientes
    List<Cliente> ListClientes = new List<Cliente>()
    {
        new Cliente()
        {
            Id = 1,
            Nombre = "Andres",
            Email = "luisandresalvarezsilva@gmail.com",

        },
        new Cliente()
        {
            Id = 2,
            Nombre = "Pedro",
            Email = "pedro123@gmail.com"
        }
    };

    // Listado de Facturas - Listado de facturas 
    List<Factura> ListFacturas = new List<Factura>()
    {
        new Factura()
        {
            Id = 1,
            Fecha = new DateOnly(2023, 1, 27),
            IdCliente = 1,
            TotalFactura = 4050
        },
        new Factura()
        {
            Id = 2,
            Fecha = new DateOnly(2023, 2, 10),
            IdCliente = 2,
            TotalFactura = 2650
        },
        new Factura()
        {
            Id = 3,
            Fecha = new DateOnly(2023, 2, 5),
            IdCliente = 3,
            TotalFactura = 900
        }
    };

    // Listado Detalles facturas - ListDetallesFacturas
    List<DetalleFactura> ListDetallesFacturas = new List<DetalleFactura>()
    {
        new DetalleFactura()
        {
            Id = 1,
            NroFactura = 2,
            IdProducto = 3,
            Cantidad = 2,
            Valor = 12000
        },
        new DetalleFactura()
        {
            Id = 2,
            NroFactura = 2,
            IdProducto = 2,
            Cantidad = 3,
            Valor = 15000
        },
        new DetalleFactura()
        {
            Id = 3,
            NroFactura = 2,
            IdProducto = 3,
            Cantidad = 2,
            Valor = 500
        }
    };


    // Primer busqueda Linq
    public void ListarInventario()
    {
        Console.Clear();
        var result = (from i in Inventario
                      select i).ToList();
        /* Console.WriteLine("---Inventario---"); */
        foreach (var item in result)
        {
            Console.WriteLine($"Id: {item.Id}");
            Console.WriteLine($"Producto: {item.Nombre}");
            Console.WriteLine($"Precio por unidad: {item.PrecioUnit}");
            Console.WriteLine($"Cantidad: {item.Cantidad}");
            Console.WriteLine($"StockMin: {item.StockMin}");
            Console.WriteLine($"StockMax: {item.StockMax}");

        }
        Console.ReadLine();
    }
    public List<Producto> ProductosPorAgotarse()
    {
        Console.Clear(); 
        var result = Inventario.Where(product => product.Cantidad < product.StockMin).ToList();
        Console.WriteLine("---Productos por agotarse---");
        result.ForEach(x => Console.WriteLine($"\nEl producto {x.Nombre} esta por agotarse con {x.StockMin - x.Cantidad} productos menos que el Stock minimo({x.StockMin})."));
        Console.ReadLine();
        return result;

    }

    public void ProductosPorComprarse()
    {
        Console.Clear();
        var result = (from i in Inventario
                      where i.Cantidad < i.StockMax
                      select i).ToList();
        if (result.Count > 0)
        {
            Console.Clear();
            Console.WriteLine("---Productos por comprar---");
            result.ForEach(x => Console.WriteLine($"Para el producto '{x.Nombre}' se deben comprar {x.StockMax - x.Cantidad} productos(o) más"));
            Console.ReadLine();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Todos los productos tienen su tope máximo");
            Console.ReadLine();
        }
    }

    public void TotalFacMesEnero()
    {
        Console.Clear();
        var result = (from i in ListFacturas
                      where i.Fecha.Year == 2023 && i.Fecha.Month == 1
                      select i).ToList();

        if (result.Count > 0)
        {
            Console.Clear();
            Console.WriteLine("---Facturas Enero 2023---");
            result.ForEach(x => Console.WriteLine($"Id: {x.Id}\nFecha de la factura: {x.Fecha}\nValor Factura: $ {x.TotalFactura}"));
            Console.ReadLine();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("No existe ninguna factura de Enero del 2023");
            Console.ReadLine();
        }
    }

    public void ProductosVendidosUnaFactura()
    {
        int IdSearch;
        string text;
        Console.Clear();
        Console.WriteLine("-------Productos de una factura-------");
        Console.WriteLine("Ingrese el Id de la factura: ");
        text=Console.ReadLine();
        while (!int.TryParse(text, out IdSearch))
        {
            Console.Clear();
            Console.WriteLine("-------Productos de una factura-------");
            Console.WriteLine("Ingrese un id valido: ");
            text=Console.ReadLine();
        };
        var result =
            (from listFact in ListFacturas
             join listDetails in ListDetallesFacturas
             on listFact.Id equals listDetails.NroFactura
             join inv in Inventario
             on listDetails.IdProducto equals inv.Id
             where listFact.Id == IdSearch
             select new ProductoComprado
             {
                 IdProducto = inv.Id,
                 Nombre = inv.Nombre
             }).ToList<ProductoComprado>();
        Console.Clear();
        Console.WriteLine($"Productos de la factura con id: {IdSearch}");
        result.ForEach(x => Console.WriteLine($"IdProducto: {x.IdProducto} - Nombre: {x.Nombre}"));
        Console.ReadLine();
    }

    public void ValorTotalInventario()
    {
        Console.Clear();
        double totalInventario = 0;
        var result = (from i in Inventario
                      select i).ToList();
        Console.WriteLine("--------Total inventario------");
        foreach (var item in result)
        {
            Console.WriteLine($"Producto: {item.Nombre}\nCantidad: {item.Cantidad}\nPrecio unidad: {item.PrecioUnit}\n\n");
            totalInventario += item.Cantidad * item.PrecioUnit;
        };
        Console.WriteLine($"El total del inventario actual es de: {totalInventario}");
        Console.ReadLine();
    }

    public void ListarClientes()
    {
        Console.Clear();
        var result = (from x in ListClientes
                      select x).ToList();
        Console.WriteLine("-----Clientes------");
        result.ForEach(x => Console.WriteLine($"\nId: {x.Id}\nNombre: {x.Nombre}\nEmail:{x.Email}"));
        Console.ReadLine();
    }
}



