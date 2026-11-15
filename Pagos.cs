namespace SistemaGimnasio;

// Precios, descuentos y registro de pagos de membresía.
static class Pagos
{
    // Precio mensual de cada plan
    public static double PrecioPlan(int plan)
    {
        switch (plan)
        {
            case 1: return 1200.00;
            case 2: return 1800.00;
            case 3: return 2500.00;
            default: return 0;
        }
    }

    // Mientras más meses paga de una vez, más descuento le toca
    public static double CalcularDescuento(int meses)
    {
        if (meses >= 12)
        {
            return 0.15;
        }
        else if (meses >= 6)
        {
            return 0.10;
        }
        else if (meses >= 3)
        {
            return 0.05;
        }
        return 0;
    }

    public static double CalcularTotal(int plan, int meses)
    {
        double subtotal = PrecioPlan(plan) * meses;
        double descuento = subtotal * CalcularDescuento(meses);
        return subtotal - descuento;
    }

    public static void RegistrarPago()
    {
        Entrada.Titulo("Registrar pago de membresía");

        if (Datos.Cantidad == 0)
        {
            Entrada.MostrarError("No hay miembros registrados todavía.");
            return;
        }

        for (int i = 0; i < Datos.Cantidad; i++)
        {
            Console.WriteLine($"  {i + 1}. {Datos.Nombres[i]}");
        }

        int numero = Entrada.LeerEntero($"Número del miembro (1-{Datos.Cantidad}): ", 1, Datos.Cantidad);
        int indice = numero - 1;
        int plan = Datos.Planes[indice];

        Console.WriteLine($"  Plan actual: {Miembros.NombrePlan(plan)} (RD$ {PrecioPlan(plan):N2} al mes)");
        Console.WriteLine("  Descuentos: 3 meses 5%, 6 meses 10%, 12 meses 15%");

        int meses = Entrada.LeerEntero("¿Cuántos meses va a pagar? (1-12): ", 1, 12);

        double subtotal = PrecioPlan(plan) * meses;
        double porcentaje = CalcularDescuento(meses);
        double total = CalcularTotal(plan, meses);

        MostrarRecibo(Datos.Nombres[indice], plan, meses, subtotal, porcentaje, total);

        int confirmar = Entrada.LeerEntero("¿Confirmar el pago? (1 = Sí, 2 = No): ", 1, 2);

        if (confirmar == 1)
        {
            Datos.MesesPagados[indice] += meses;
            Datos.TotalIngresos += total;
            Datos.PagosRealizados++;
            Entrada.MostrarExito($"Pago registrado. {Datos.Nombres[indice]} tiene {Datos.MesesPagados[indice]} meses pagados.");
        }
        else
        {
            Console.WriteLine("  Pago cancelado.");
        }
    }

    static void MostrarRecibo(string nombre, int plan, int meses, double subtotal, double porcentaje, double total)
    {
        Console.WriteLine();
        Console.WriteLine("  ----------- RECIBO -----------");
        Console.WriteLine($"  {"Miembro:",-14}{nombre}");
        Console.WriteLine($"  {"Plan:",-14}{Miembros.NombrePlan(plan)}");
        Console.WriteLine($"  {"Meses:",-14}{meses}");
        Console.WriteLine($"  {"Subtotal:",-14}RD$ {subtotal,10:N2}");
        Console.WriteLine($"  {"Descuento:",-14}{porcentaje,14:P0}");
        Console.WriteLine($"  {"TOTAL:",-14}RD$ {total,10:N2}");
        Console.WriteLine("  ------------------------------");
    }
}
