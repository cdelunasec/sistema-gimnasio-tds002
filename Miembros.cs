namespace SistemaGimnasio;

// Todo lo que tiene que ver con los miembros: registrarlos, listarlos y buscarlos.
static class Miembros
{
    public static void RegistrarMiembro()
    {
        Entrada.Titulo("Registrar miembro");

        if (Datos.Cantidad >= Datos.MaxMiembros)
        {
            Entrada.MostrarError("El gimnasio está lleno, no se pueden registrar más miembros.");
            return;
        }

        string nombre = Entrada.LeerTexto("Nombre completo: ");

        if (BuscarIndice(nombre) != -1)
        {
            Entrada.MostrarError($"Ya existe un miembro llamado {nombre}.");
            return;
        }

        int edad = Entrada.LeerEntero("Edad (14 a 90): ", 14, 90);

        Console.WriteLine();
        Console.WriteLine("Planes disponibles:");
        for (int plan = 1; plan <= 3; plan++)
        {
            Console.WriteLine($"  {plan}. {NombrePlan(plan),-8} RD$ {Pagos.PrecioPlan(plan),8:N2} al mes");
        }
        int planElegido = Entrada.LeerEntero("Elige el plan (1-3): ", 1, 3);

        Datos.AgregarMiembro(nombre, edad, planElegido, 0);
        Entrada.MostrarExito($"{nombre} quedó registrado en el plan {NombrePlan(planElegido)}.");
        Console.WriteLine("  Recuerda registrar su primer pago en la opción 4.");
    }

    public static void MostrarLista()
    {
        Entrada.Titulo("Lista de miembros");

        if (Datos.Cantidad == 0)
        {
            Console.WriteLine("  Todavía no hay miembros registrados.");
            return;
        }

        Console.WriteLine($"  {"#",-3} {"Nombre",-22} {"Edad",4}  {"Plan",-8} {"Meses",5}");
        Console.WriteLine("  " + new string('-', 46));

        for (int i = 0; i < Datos.Cantidad; i++)
        {
            MostrarFila(i);
        }

        Console.WriteLine("  " + new string('-', 46));
        Console.WriteLine($"  Total de miembros: {Datos.Cantidad}");
    }

    public static void BuscarMiembro()
    {
        Entrada.Titulo("Buscar miembro");

        string texto = Entrada.LeerTexto("Escribe el nombre o parte del nombre: ").ToLower();
        int encontrados = 0;

        for (int i = 0; i < Datos.Cantidad; i++)
        {
            if (Datos.Nombres[i].ToLower().Contains(texto))
            {
                if (encontrados == 0)
                {
                    Console.WriteLine($"  {"#",-3} {"Nombre",-22} {"Edad",4}  {"Plan",-8} {"Meses",5}");
                    Console.WriteLine("  " + new string('-', 46));
                }
                MostrarFila(i);
                encontrados++;
            }
        }

        if (encontrados == 0)
        {
            Entrada.MostrarError($"No se encontró ningún miembro con \"{texto}\".");
        }
        else
        {
            Console.WriteLine($"  Resultados: {encontrados}");
        }
    }

    // Devuelve la posición del miembro con ese nombre exacto, o -1 si no existe
    public static int BuscarIndice(string nombre)
    {
        for (int i = 0; i < Datos.Cantidad; i++)
        {
            if (Datos.Nombres[i].ToLower() == nombre.ToLower())
            {
                return i;
            }
        }
        return -1;
    }

    // Convierte el número del plan en su nombre
    public static string NombrePlan(int plan)
    {
        switch (plan)
        {
            case 1: return "Básico";
            case 2: return "Premium";
            case 3: return "VIP";
            default: return "Sin plan";
        }
    }

    static void MostrarFila(int i)
    {
        Console.WriteLine($"  {i + 1,-3} {Datos.Nombres[i],-22} {Datos.Edades[i],4}  {NombrePlan(Datos.Planes[i]),-8} {Datos.MesesPagados[i],5}");
    }
}
