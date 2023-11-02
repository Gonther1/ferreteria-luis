using System.ComponentModel.Design;
using ferreteria.Clases;

internal class Program
{
    private static void Main(string[] args)
    {
        string menu;
        Core ObjCore = new Core();
        do {
            Console.Clear();
            Console.WriteLine("Ingrese la opcion a realizar: ");
            Console.WriteLine("1-Listar los productos del inventario");
            Console.WriteLine("2-Listar productos a punto de agotarse");
            Console.WriteLine("3-Listar productos que se deben comprar y cantidad a comprar");
            Console.WriteLine("4-Listar total de facturas de enero del 2023");
            Console.WriteLine("5-Calcular valor total del inventario");
            Console.WriteLine("6-Salir");
            menu = Console.ReadLine();
            switch (menu)
            {
                case "1":
                    ObjCore.ListarInventario();
                    break;
                case "2":
                    ObjCore.ProductosPorAgotarse();
                    break;
                case "3":
                    ObjCore.ProductosPorComprarse();
                    break;
                case "4":
                    ObjCore.TotalFacMesEnero();
                    break;
                case "5":
                    ObjCore.ProductosVendidosUnaFactura();
                    break;
                case "6":
                    ObjCore.ValorTotalInventario(); 
                    break;
                case "7":
                    Console.WriteLine("Adios...");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opcion invalida\n\nPresione una tecla para continuar...");
                    Console.ReadLine();
                    break;
            }
        } while (menu != "7");
    }
}