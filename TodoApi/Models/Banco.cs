

public class Aluno
{
    public string Nome{get; set;}
    public int Id{get; set;}
}

public class Curso
{
    public string nomeCurso{get; set;}
    public int IdAluno{get; set;}
}

public class Banco
{
    public static void Main()
    {
        List<Aluno> aluno = new List<Aluno>
        {
            new Aluno{Nome = "Jose", Id = 1},
            new Aluno{Nome = "Maria", Id = 2},
            new Aluno{Nome = "Rafaela", Id = 3},
            new Aluno{Nome = "Miranda", Id = 4},
        };
        List<Curso> curso = new List<Curso>
        {
            new Curso{nomeCurso = "Matematica" , IdAluno = 1},
            new Curso{nomeCurso = "Programação" , IdAluno = 2},
            new Curso{nomeCurso = "Fisica" , IdAluno = 3},
            new Curso{nomeCurso = "Geografia" , IdAluno = 4},
        };

        var JJoin =  from n in aluno
                    join c in curso on n.Id equals c.IdAluno
                    select new 
                    {
                        NomeAluno = n.Nome,
                        NomeCurso = c.nomeCurso
                    };

        foreach(var n in JJoin)
        {
            Console.WriteLine($"Aluno: {n.NomeAluno}, Curso: {n.NomeCurso}");
        }

    }
}