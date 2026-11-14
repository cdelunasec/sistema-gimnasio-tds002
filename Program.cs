using System.Globalization;
using System.Text;
using SistemaGimnasio;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;
// Formato dominicano para los montos: 1,200.00
CultureInfo.CurrentCulture = new CultureInfo("es-DO");

Datos.CargarEjemplos();

int opcion;

do
{
    MostrarMenu();
    opcion = Entrada.LeerEntero("Elige una opción: ", 0, 5);

    switch (opcion)
    {
        case 1:
            Miembros.RegistrarMiembro();
            break;
        case 2:
            Miembros.MostrarLista();
            break;
        case 3:
            Miembros.BuscarMiembro();
            break;
        case 4:
            Pagos.RegistrarPago();
            break;
        case 5:
            Reportes.MostrarReporte();
            break;
        case 0:
            Console.WriteLine();
            Console.WriteLine("Gracias por usar el sistema de GymTDS. ¡Hasta luego!");
            break;
    }

    if (opcion != 0)
    {
        Entrada.Pausa();
    }

} while (opcion != 0);


static void MostrarMenu()
{
    Entrada.Titulo("GymTDS - Sistema de gimnasio");
    Console.WriteLine("  1. Registrar miembro");
    Console.WriteLine("  2. Ver lista de miembros");
    Console.WriteLine("  3. Buscar miembro");
    Console.WriteLine("  4. Registrar pago de membresía");
    Console.WriteLine("  5. Reporte del gimnasio");
    Console.WriteLine("  0. Salir");
    Console.WriteLine(new string('-', 50));
}
