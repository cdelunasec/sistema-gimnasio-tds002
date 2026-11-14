namespace SistemaGimnasio;

// Aquí se guardan los datos del gimnasio mientras el programa está abierto.
// Usamos arreglos paralelos: la posición i de cada arreglo es el mismo miembro.
static class Datos
{
    public const int MaxMiembros = 50;

    public static string[] Nombres = new string[MaxMiembros];
    public static int[] Edades = new int[MaxMiembros];
    public static int[] Planes = new int[MaxMiembros];        // 1 = Básico, 2 = Premium, 3 = VIP
    public static int[] MesesPagados = new int[MaxMiembros];

    public static int Cantidad = 0;
    public static double TotalIngresos = 0;
    public static int PagosRealizados = 0;

    // Unos miembros de ejemplo para que la lista no arranque vacía en la demo
    public static void CargarEjemplos()
    {
        AgregarMiembro("Ana Martínez", 22, 2, 3);
        AgregarMiembro("Luis Pérez", 35, 1, 1);
        AgregarMiembro("Carla Gómez", 28, 3, 6);
    }

    public static void AgregarMiembro(string nombre, int edad, int plan, int meses)
    {
        Nombres[Cantidad] = nombre;
        Edades[Cantidad] = edad;
        Planes[Cantidad] = plan;
        MesesPagados[Cantidad] = meses;
        Cantidad++;
    }
}
