namespace SistemaAlumnos
{
    public class Alumno : Persona, IExportable
    {
        public int Legajo { get; private set; }
        public double Nota1 { get; private set; }

        public double Nota2 { get; private set; }

        public Alumno(string nombre, int documento, int legajo) : base(nombre, documento)
        {
            Legajo = legajo;
        }

        // las notas van por aca, si no entran en 0..10 no toca nada
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
            if (Nota1 < 10) Nota1++;
            if (Nota2 < 10) Nota2++;
        }

        // sin el override tira warning CS0114, dice que oculta el ToString de object
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
}
