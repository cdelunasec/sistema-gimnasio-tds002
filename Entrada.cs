namespace SistemaGimnasio;

// Métodos para leer datos del teclado sin que el programa explote
// y para darle formato a la pantalla.
static class Entrada
{
    // Pide un número entero y no deja pasar hasta que esté entre min y max
    public static int LeerEntero(string mensaje, int min, int max)
    {
        int numero;
        bool valido;

        do
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();
            valido = int.TryParse(texto, out numero);

            if (!valido)
            {
                MostrarError("Eso no es un número válido, intenta de nuevo.");
            }
            else if (numero < min || numero > max)
            {
                MostrarError($"El número debe estar entre {min} y {max}.");
                valido = false;
            }
        } while (!valido);

        return numero;
    }

    // Pide un texto y no acepta que lo dejen vacío
    public static string LeerTexto(string mensaje)
    {
        string texto = "";

        while (texto.Trim() == "")
        {
            Console.Write(mensaje);
            texto = Console.ReadLine() ?? "";

            if (texto.Trim() == "")
            {
                MostrarError("Este campo no puede quedar vacío.");
            }
        }

        return texto.Trim();
    }

    public static void Titulo(string texto)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('=', 50));
        Console.WriteLine($"  {texto.ToUpper()}");
        Console.WriteLine(new string('=', 50));
        Console.ResetColor();
    }

    public static void MostrarError(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"  [!] {mensaje}");
        Console.ResetColor();
    }

    public static void MostrarExito(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  [OK] {mensaje}");
        Console.ResetColor();
    }

    public static void Pausa()
    {
        Console.WriteLine();
        Console.Write("Presiona Enter para volver al menú...");
        Console.ReadLine();
    }
}
