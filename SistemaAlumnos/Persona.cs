public class Persona
{
    public string Nombre { get; set; }
    public int Documento { get; set; }

    public Persona(string nombre, int documento)
    {
        Nombre = nombre;
        Documento = documento;
    }

    // virtual: las clases hijas pueden reemplazar este metodo.
    // Etapa 8: si le saco el virtual, en Alumno da error CS0506
    // "no puede reemplazar el miembro heredado porque no es virtual, abstracto ni reemplazado".
    public virtual string Presentarse()
    {
        return "Hola, soy " + Nombre + ".";
    }
}
