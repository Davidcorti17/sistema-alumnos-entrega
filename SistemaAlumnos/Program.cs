using SistemaAlumnos;

var alumnos = new List<Alumno>();

var personas = new List<Persona>
{
    new Alumno("Ana Perez", 40111222, 1234),
    new Profesor("Marta Diaz", 25333444, "Programacion"),
    new Preceptor("Luis Gomez", 30555666, "manana")
};

Console.WriteLine("--- Presentaciones ---");

foreach (var p in personas)
{
    Console.WriteLine(p.Presentarse());
}

var materias = new List<Materia>
{
        new Materia("PROG1", "Programacion I", 128),
        new Materia("BD1", "Base de Datos I", 96)
};

var ana = new Alumno("Ana Perez", 40111222, 1234);
ana.CargarNotas(7, 7);

var exportables = new List<IExportable>
{
    ana,
    new Profesor("Marta Diaz", 25333444, "Programacion"),
    materias[0],
    materias[1]
};

Console.WriteLine();
Console.WriteLine("--- Exportar ---");

foreach (var e in exportables)
{
    Console.WriteLine(e.ExportarLinea());
}

var salir = false;

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

    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.Write("Nombre: ");
            var nombre = Console.ReadLine();

            Console.Write("Documento: ");
            var documento = int.Parse(Console.ReadLine());

            Console.Write("Legajo: ");
            var legajo = int.Parse(Console.ReadLine());

            Console.Write("Nota 1: ");
            var nota1 = double.Parse(Console.ReadLine());
            Console.Write("Nota 2: ");
            var nota2 = double.Parse(Console.ReadLine());

            var nuevo = new Alumno(nombre, documento, legajo);

            if (nuevo.CargarNotas(nota1, nota2))
            {
                alumnos.Add(nuevo);
                Console.WriteLine("Alumno agregado.");
            }
            else
            {
                Console.WriteLine("Las notas tienen que estar entre 0 y 10. No se agrego.");
            }

            break;

        case "2":
            if (alumnos.Count == 0)
            {
                Console.WriteLine("Todavia no hay alumnos.");
                break;
            }

            foreach (var a in alumnos)
            {
                Console.WriteLine(a);
            }

            break;

        case "3":
            Console.Write("Legajo a buscar: ");
            var buscado = int.Parse(Console.ReadLine());

            var encontrado = alumnos.FirstOrDefault(a => a.Legajo == buscado);

            if (encontrado is null)
            {
                Console.WriteLine("No existe un alumno con ese legajo.");
            }
            else
            {
                Console.WriteLine(encontrado);
            }

            break;

        case "4":
            if (alumnos.Count == 0)
            {
                Console.WriteLine("Todavia no hay alumnos.");
                break;
            }

            Console.WriteLine("Promedio general: " + alumnos.Average(a => a.Promedio()));
            break;

        case "5":
            Console.WriteLine("Aprobados: " + alumnos.Count(a => a.EstaAprobado()));
            break;

        case "6":
            salir = true;
            break;

        default:
            Console.WriteLine("Esa opcion no existe.");
            break;
    }
}
