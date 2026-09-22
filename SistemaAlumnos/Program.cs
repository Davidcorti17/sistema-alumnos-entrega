// Etapa 9: si agrego ExportarEncabezado() a la interfaz y no lo implemento,
// aparecen 3 errores CS0535 (uno por cada clase que implementa IExportable:
// Alumno, Profesor y Materia) diciendo que la clase no implementa el
// miembro de interfaz "IExportable.ExportarEncabezado()".

List<Alumno> alumnos = new List<Alumno>();

// Etapa 8: una lista de Persona con distintos tipos mezclados.
List<Persona> personas = new List<Persona>();
personas.Add(new Alumno("Ana Perez", 40111222, 1234));
personas.Add(new Profesor("Marta Diaz", 25333444, "Programacion"));
personas.Add(new Preceptor("Luis Gomez", 30555666, "manana"));

Console.WriteLine("--- Presentaciones ---");
foreach (Persona p in personas)
{
    Console.WriteLine(p.Presentarse());
}

// Etapa 9: listado precargado de materias.
List<Materia> materias = new List<Materia>();
materias.Add(new Materia("PROG1", "Programacion I", 128));
materias.Add(new Materia("BD1", "Base de Datos I", 96));

Alumno ana = new Alumno("Ana Perez", 40111222, 1234);
ana.CargarNotas(7, 7);

List<IExportable> exportables = new List<IExportable>();
exportables.Add(ana);
exportables.Add(new Profesor("Marta Diaz", 25333444, "Programacion"));
exportables.Add(materias[0]);
exportables.Add(materias[1]);

Console.WriteLine();
Console.WriteLine("--- Exportar ---");
foreach (IExportable e in exportables)
{
    Console.WriteLine(e.ExportarLinea());
}

// Etapa 6: menu.
bool salir = false;

while (!salir)
{
    Console.WriteLine();
    Console.WriteLine("--- Menu ---");
    Console.WriteLine("1 - Agregar alumno");
    Console.WriteLine("2 - Listar alumnos");
    Console.WriteLine("3 - Buscar por legajo");
    Console.WriteLine("4 - Promedio general");
    Console.WriteLine("5 - Cantidad de aprobados");
    Console.WriteLine("6 - Salir");
    Console.Write("Opcion: ");

    string opcion = Console.ReadLine();

    if (opcion == "1")
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Documento: ");
        int documento = int.Parse(Console.ReadLine());

        Console.Write("Legajo: ");
        int legajo = int.Parse(Console.ReadLine());

        Console.Write("Nota 1: ");
        double nota1 = double.Parse(Console.ReadLine());

        Console.Write("Nota 2: ");
        double nota2 = double.Parse(Console.ReadLine());

        Alumno nuevo = new Alumno(nombre, documento, legajo);

        if (nuevo.CargarNotas(nota1, nota2))
        {
            alumnos.Add(nuevo);
            Console.WriteLine("Alumno agregado.");
        }
        else
        {
            Console.WriteLine("Notas invalidas, tienen que estar entre 0 y 10. No se agrego el alumno.");
        }
    }
    else if (opcion == "2")
    {
        if (alumnos.Count == 0)
        {
            Console.WriteLine("Todavia no hay alumnos.");
        }
        else
        {
            foreach (Alumno a in alumnos)
            {
                Console.WriteLine(a);
            }
        }
    }
    else if (opcion == "3")
    {
        Console.Write("Legajo a buscar: ");
        int buscado = int.Parse(Console.ReadLine());

        Alumno encontrado = null;

        foreach (Alumno a in alumnos)
        {
            if (a.Legajo == buscado)
            {
                encontrado = a;
            }
        }

        if (encontrado == null)
        {
            Console.WriteLine("No existe un alumno con ese legajo.");
        }
        else
        {
            Console.WriteLine(encontrado);
        }
    }
    else if (opcion == "4")
    {
        if (alumnos.Count == 0)
        {
            Console.WriteLine("Todavia no hay alumnos.");
        }
        else
        {
            double suma = 0;

            foreach (Alumno a in alumnos)
            {
                suma = suma + a.Promedio();
            }

            Console.WriteLine("Promedio general: " + (suma / alumnos.Count));
        }
    }
    else if (opcion == "5")
    {
        int aprobados = 0;

        foreach (Alumno a in alumnos)
        {
            if (a.EstaAprobado())
            {
                aprobados++;
            }
        }

        Console.WriteLine("Aprobados: " + aprobados);
    }
    else if (opcion == "6")
    {
        salir = true;
    }
    else
    {
        Console.WriteLine("Opcion invalida.");
    }
}
