namespace SistemaGimnasio;

// Resumen general del gimnasio con estadísticas sacadas de los datos.
static class Reportes
{
    public static void MostrarReporte()
    {
        Entrada.Titulo("Reporte del gimnasio");

        if (Datos.Cantidad == 0)
        {
            Console.WriteLine("  No hay datos para mostrar todavía.");
            return;
        }

        Console.WriteLine("  Miembros por plan:");
        for (int plan = 1; plan <= 3; plan++)
        {
            int cantidad = ContarPorPlan(plan);
            string barra = new string('#', cantidad);
            Console.WriteLine($"    {Miembros.NombrePlan(plan),-8} {cantidad,3}  {barra}");
        }

        Console.WriteLine();
        Console.WriteLine($"  {"Total de miembros:",-28}{Datos.Cantidad,10}");
        Console.WriteLine($"  {"Edad promedio:",-28}{CalcularEdadPromedio(),10:F1} años");
        Console.WriteLine($"  {"Pagos registrados hoy:",-28}{Datos.PagosRealizados,10}");
        Console.WriteLine($"  {"Ingresos de hoy:",-28}RD$ {Datos.TotalIngresos,10:N2}");

        int mejor = MiembroMasMeses();
        Console.WriteLine($"  {"Miembro con más meses:",-28}{Datos.Nombres[mejor]} ({Datos.MesesPagados[mejor]} meses)");

        int sinPagar = ContarSinPagar();
        if (sinPagar > 0)
        {
            Entrada.MostrarError($"Hay {sinPagar} miembro(s) que todavía no han pagado ningún mes.");
        }
    }

    public static int ContarPorPlan(int plan)
    {
        int contador = 0;
        for (int i = 0; i < Datos.Cantidad; i++)
        {
            if (Datos.Planes[i] == plan)
            {
                contador++;
            }
        }
        return contador;
    }

    public static double CalcularEdadPromedio()
    {
        int suma = 0;
        int i = 0;
        while (i < Datos.Cantidad)
        {
            suma += Datos.Edades[i];
            i++;
        }
        return (double)suma / Datos.Cantidad;
    }

    public static int MiembroMasMeses()
    {
        int posicion = 0;
        for (int i = 1; i < Datos.Cantidad; i++)
        {
            if (Datos.MesesPagados[i] > Datos.MesesPagados[posicion])
            {
                posicion = i;
            }
        }
        return posicion;
    }

    static int ContarSinPagar()
    {
        int contador = 0;
        for (int i = 0; i < Datos.Cantidad; i++)
        {
            if (Datos.MesesPagados[i] == 0)
            {
                contador++;
            }
        }
        return contador;
    }
}
