using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferreteria.Clases;

public class Core
{
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
            Cantidad = 200,
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

    public void ListarInventario()
    {
        var result = (from i in Inventario
                     select i).ToList();
        Console.Clear();
        Console.WriteLine("---Inventario---");
        result.ForEach(x => Console.WriteLine($"\nId: {x.Id}\nNombre: {x.Nombre}\nPrecio por unidad: {x.PrecioUnit}\nCantidad: {x.Cantidad}\nStock Minimo: {x.StockMin}\nStock Maximo: {x.StockMax}"));
        Console.ReadLine();
    }
    public List<Producto> ProductosPorAgotarse()
    {
        var result = Inventario.Where(product => product.Cantidad < product.StockMin).ToList();
        Console.Clear();
        Console.WriteLine("---Productos por agotarse---");
        result.ForEach(x => Console.WriteLine($"\nEl producto {x.Nombre} esta por agotarse con {x.StockMin - x.Cantidad} productos menos que el Stock minimo({x.StockMin})."));
        Console.ReadLine();
        return result;

    }

    public void ProductosPorComprarse()
    {
        var result = (from i in Inventario
                      where i.Cantidad<i.StockMax
                      select i).ToList();
        Console.Clear();
        if (result.Count > 0)
        {
            Console.WriteLine("---Productos por comprar---");
            result.ForEach(x => Console.WriteLine($"Para el producto '{x.Nombre}' se deben comprar {x.StockMax - x.Cantidad} productos(o) más"));
            Console.ReadLine();
        }
        else 
        {
            Console.WriteLine("Todos los productos tienen su tope máximo");
            Console.ReadLine();
        }
    }

    public void TotalFacMesEnero()
    {
        var result = (from i in ListFacturas
                      where i.Fecha.Year==2023 && i.Fecha.Month==1
                      select i).ToList();

        Console.Clear();
        if (result.Count > 0)
        {
            Console.WriteLine("---Facturas Enero 2023---");
            result.ForEach(x => Console.WriteLine($"{x.TotalFactura}"));
            Console.ReadLine();
        }
        else 
        {
            Console.WriteLine("No existe ninguna factura de Enero del 2023");
            Console.ReadLine();
        }
    }

    public void ProductosVendidosUnaFactura()
    {
/*         var result = (from i in ListFacturas
                      where i.Fecha.Year==2023 && i.Fecha.Month==1
                      select i).ToList();

        Console.Clear();
        if (result.Count > 0)
        {
            Console.WriteLine("---Facturas Enero 2023---");
            result.ForEach(x => Console.WriteLine($"{x.TotalFactura}"));
            Console.ReadLine();
        }
        else 
        {
            Console.WriteLine("No existe ninguna factura de Enero del 2023");
            Console.ReadLine();
        } */
    }

    public void ValorTotalInventario()
    {
/*         var result = (from i in ListFacturas
                      where i.Fecha.Year==2023 && i.Fecha.Month==1
                      select i).ToList();

        Console.Clear();
        if (result.Count > 0)
        {
            Console.WriteLine("---Facturas Enero 2023---");
            result.ForEach(x => Console.WriteLine($"{x.TotalFactura}"));
            Console.ReadLine();
        }
        else 
        {
            Console.WriteLine("No existe ninguna factura de Enero del 2023");
            Console.ReadLine();
        } */
    }


}
