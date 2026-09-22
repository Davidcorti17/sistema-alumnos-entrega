public class Alumno : Persona, IExportable
{
    public int Legajo { get; private set; }

    // private set: se leen desde afuera pero solo se cambian adentro de la clase.
    // Etapa 5: por eso alumno.Nota1 = 47; ya no compila, da error CS0272.
    public double Nota1 { get; private set; }
    public double Nota2 { get; private set; }

    // Etapa 5: el constructor ya no recibe las notas, solo los datos de la persona y el legajo.
    public Alumno(string nombre, int documento, int legajo) : base(nombre, documento)
    {
        Legajo = legajo;
    }

    // Etapa 2: "new Alumno()" sin datos da error CS7036, porque al escribir un constructor
    // propio desaparece el constructor vacio que C# pone solo.

    public bool CargarNotas(double nota1, double nota2)
    {
        if (nota1 < 0 || nota1 > 10 || nota2 < 0 || nota2 > 10)
        {
            return false;
        }

        Nota1 = nota1;
        Nota2 = nota2;
        return true;
    }

    public double Promedio()
    {
        return (Nota1 + Nota2) / 2;
    }

    public bool EstaAprobado()
    {
        return Promedio() >= 6;
    }

    public void SubirNota()
    {
        if (Nota1 < 10) Nota1 = Nota1 + 1;
        if (Nota2 < 10) Nota2 = Nota2 + 1;
        if (Nota1 > 10) Nota1 = 10;
        if (Nota2 > 10) Nota2 = 10;
    }

    // Etapa 4: sin la palabra override el compilador avisa con la advertencia CS0114,
    // "oculta el miembro heredado object.ToString()", y Console.WriteLine(alumno)
    // vuelve a mostrar el nombre de la clase.
    public override string ToString()
    {
        return Legajo + " - " + Nombre + " (promedio: " + Promedio() + ")";
    }

    public override string Presentarse()
    {
        return "Hola, soy " + Nombre + ", alumno con legajo " + Legajo + ".";
    }

    public string ExportarLinea()
    {
        return "ALUMNO;" + Legajo + ";" + Nombre + ";" + Promedio();
    }
}
