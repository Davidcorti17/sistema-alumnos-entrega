namespace SistemaAlumnos
{
    public class Persona
    {
        public string Nombre { get; set; }
        public int Documento { get; set; }

        public Persona(string nombre, int documento)
        {
            Nombre = nombre;
            Documento = documento;
        }

        public virtual string Presentarse()
        {
            return "Hola, soy " + Nombre + ".";
        }
    }
}
