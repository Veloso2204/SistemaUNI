using System;
using System.Collections.Generic;
using Uni;
using System.Linq;

class Program
{
    static List<Aluno> listaDeAlunos = new List<Aluno>();
    static List<Professor> listadeProf = new List<Professor>();
    static List<Curso> listadeCurso = new List<Curso>();
    static List<Aula> listadeAula = new List<Aula>();
    static List<Departamento> listaDeDepartamentos = new List<Departamento>();

    static Dictionary<int, Action> opcoesMenu = new Dictionary<int, Action>
    {
        { 1, OpcoesAluno },
        { 2, OpcoesProfessor },
        { 3, OpcoesCurso },
        { 4, OpcoesDepartamento },
        { 5, OpcoesAula },
        { 0, () => { Console.WriteLine("Saindo..."); } }
    };

    static void ListarAlunos(List<Aluno> alunos)
    {
        foreach (var aluno in alunos)
        {
            Console.WriteLine($"ID: {aluno.ID}, Nome: {aluno.Nome}");
        }
    }

    static void ListarProf(List<Professor> prof)
    {
        foreach (var professor in prof)
        {
            Console.WriteLine($"ID: {professor.ID}, Nome: {professor.Nome}");
        }
    }

    static void ListarCurso(List<Curso> curso)
    {
        foreach (var cursos in curso)
        {
            Console.WriteLine($"ID: {cursos.ID}, Nome: {cursos.Nome}, Carga Horário: {cursos.CargaHoraria}");
        }
    }

    static void ObterlistadeProf(List<Professor> prof)
    {
        foreach (var professor in prof)
        {
            Console.WriteLine($"ID: {professor.ID}, Nome: {professor.Nome}");
        }
    }

    static void ListarDepartamentos(List<Departamento> departa)
    {
        foreach (var departamento in departa)
        {
            Console.WriteLine("Departamento:");
            Console.WriteLine($"ID: {departamento.ID}, Nome: {departamento.Nome}");

            if (departamento.Professor.Any())
            {
                Console.WriteLine("Professores:");
                foreach (var professor in departamento.Professor)
                {
                    Console.WriteLine($"  - ID: {professor.ID}, Nome: {professor.Nome}");
                }
            }

            Console.WriteLine();
        }
    }

    static void ListarAula(List<Aula> aula)
    {
        foreach (var aulas in aula)
        {
            Console.WriteLine($"ID: {aulas.ID}, Curso: {aulas.Curso.Nome}, Professor: {aulas.Professor.Nome}, Sala: {aulas.Sala}, Horário: {aulas.Horario}");
        }
    }


    static void InserirAula()
    {
        if (listadeCurso.Count == 0 || listadeProf.Count == 0)
        {
            Console.WriteLine("Não há cursos ou professores registrados. Por favor, registre cursos e professores antes de adicionar uma aula.");
            return;
        }

        Console.WriteLine("Insira o ID da aula:");
        int idAula = int.Parse(Console.ReadLine());

        Console.WriteLine("\n\n Lista de Cursos \n");
        ListarCurso(listadeCurso);
        Console.WriteLine("\n\n");

        Console.WriteLine("Insira o ID do Curso:");
        int idCurso = int.Parse(Console.ReadLine());
        Curso cursoSelecionado = listadeCurso.FirstOrDefault(curso => curso.ID == idCurso);

        Console.WriteLine("\n\n Lista de Professores \n");
        ListarProf(listadeProf);
        Console.WriteLine("\n\n");

        Console.WriteLine("Insira o ID do Professor:");
        int idProfessor = int.Parse(Console.ReadLine());
        Professor professorSelecionado = listadeProf.FirstOrDefault(professor => professor.ID == idProfessor);

        Console.WriteLine("Insira o número da sala:");
        int sala = int.Parse(Console.ReadLine());

        Console.WriteLine("Insira o horário da aula:");
        int horario = int.Parse(Console.ReadLine());

        if (cursoSelecionado != null && professorSelecionado != null)
        {
            Aula novaAula = new Aula
            {
                ID = idAula,
                Curso = cursoSelecionado,
                Professor = professorSelecionado,
                Sala = sala,
                Horario = horario
            };

            listadeAula.Add(novaAula);
            Console.WriteLine("Aula adicionada com sucesso!");
        }
        else
        {
            Console.WriteLine("Curso ou Professor não encontrado!");
        }
    }



    static void OpcoesAluno()
    {
        Console.WriteLine("Você escolheu a opção Aluno");
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Inserir Aluno");
        Console.WriteLine("2 - Listar Aluno");

        int escolha;
        if (!int.TryParse(Console.ReadLine(), out escolha))
        {
            Console.WriteLine("Por favor, insira um número válido.");
            return;
        }

        switch (escolha)
        {
            case 1:
                Console.WriteLine("Insira o ID do aluno:");
                int idAluno = int.Parse(Console.ReadLine());
                Console.WriteLine("Insira o Nome do aluno:");
                string nomeAluno = Console.ReadLine();

                Aluno novoAluno = new Aluno
                {
                    ID = idAluno,
                    Nome = nomeAluno
                };

                listaDeAlunos.Add(novoAluno);
                break;

            case 2:
                ListarAlunos(listaDeAlunos);
                break;

            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }

    static void OpcoesProfessor()
    {
        Console.WriteLine("Você escolheu a opção Professor");
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Inserir Professor");
        Console.WriteLine("2 - Listar Professor");

        int escolha;
        if (!int.TryParse(Console.ReadLine(), out escolha))
        {
            Console.WriteLine("Por favor, insira um número válido.");
            return;
        }

        switch (escolha)
        {
            case 1:
                Console.WriteLine("Insira o ID do Professor:");
                int idProf = int.Parse(Console.ReadLine());
                Console.WriteLine("Insira o Nome do Professor:");
                string nomeProf = Console.ReadLine();

                Professor novoProf = new Professor
                {
                    ID = idProf,
                    Nome = nomeProf
                };

                listadeProf.Add(novoProf);
                break;

            case 2:
                ListarProf(listadeProf);
                break;

            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }

    static void OpcoesCurso()
    {
        Console.WriteLine("Você escolheu a opção Curso");
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Inserir Curso");
        Console.WriteLine("2 - Listar Curso");

        int escolha;
        if (!int.TryParse(Console.ReadLine(), out escolha))
        {
            Console.WriteLine("Por favor, insira um número válido.");
            return;
        }

        switch (escolha)
        { 
            case 1:
                Console.WriteLine("Insira o Id do Curso:");
                int idCurso = int.Parse(Console.ReadLine());
                Console.WriteLine("Insira o Nome do Curso:");
                string nomeCurso = Console.ReadLine();
                Console.WriteLine("Insira o valor da Carga Horária:");
                int cargaHor = int.Parse(Console.ReadLine());

                Curso novoCurso = new Curso
                {
                    ID = idCurso,
                    Nome = nomeCurso,
                    CargaHoraria = cargaHor
                };

                listadeCurso.Add(novoCurso);
            break;
            case 2:
                ListarCurso(listadeCurso);
                break;
        }
    }

    static void OpcoesDepartamento()
    {
        Console.WriteLine("Você escolheu a opção Departamento");
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Inserir Departamento");
        Console.WriteLine("2 - Listar Departamento");

        int escolha;
        if (!int.TryParse(Console.ReadLine(), out escolha))
        {
            Console.WriteLine("Por favor, insira um número válido.");
            return;
        }

        switch (escolha)
        {
            case 1:
                Console.WriteLine("Insira o ID do departamento:");
                int idDep = int.Parse(Console.ReadLine());
                Console.WriteLine("Insira o Nome do departamento:");
                string nomeDep = Console.ReadLine();
                Console.WriteLine("\n\n Lista de Professores \n");
                ObterlistadeProf(listadeProf);
                Console.WriteLine("\n\n");

                Console.WriteLine("Digite o ID do professor que deseja adicionar:");
                int idProfessor = int.Parse(Console.ReadLine());

                Professor professorSelecionado = listadeProf.FirstOrDefault(professor => professor.ID == idProfessor);

                if (professorSelecionado != null)
                {
                    Departamento departamento = new Departamento
                    {
                        ID = idDep,
                        Nome = nomeDep,
                        Professor = new List<Professor>()
                    };
                    departamento.Professor.Add(professorSelecionado);
                    listaDeDepartamentos.Add(departamento);
                    Console.WriteLine($"Professor {professorSelecionado.Nome} adicionado ao departamento!");
                }
                else
                {
                    Console.WriteLine("Professor não encontrado!");
                }
                break;
            case 2:
                ListarDepartamentos(listaDeDepartamentos);
                break;
        }
    }

    static void OpcoesAula()
    {
        Console.WriteLine("Você escolheu a opção Aula");
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Inserir Aula");
        Console.WriteLine("2 - Listar Aula");

        int escolha;
        if (!int.TryParse(Console.ReadLine(), out escolha))
        {
            Console.WriteLine("Por favor, insira um número válido.");
            return;
        }

        switch (escolha)
        {
            case 1:
                InserirAula();
                break;
            case 2:
                ListarAula(listadeAula);
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }

    static void ExibirMenuPrincipal()
    {
        Console.WriteLine("Selecione uma opção:");
        Console.WriteLine("1 - Aluno");
        Console.WriteLine("2 - Professor");
        Console.WriteLine("3 - Curso");
        Console.WriteLine("4 - Departamento");
        Console.WriteLine("5 - Aula");
        Console.WriteLine("0 - Sair");

        Console.WriteLine("< ------------------------------------ >");
        Console.WriteLine($" | Número de Alunos: {listaDeAlunos.Count}               |");
        Console.WriteLine($" | Número de Professores: {listadeProf.Count}          | ");
        Console.WriteLine($" | Número de Cursos: {listadeCurso.Count}               | ");
        Console.WriteLine($" | Número de Departamentos: {listaDeDepartamentos.Count}        | ");
        Console.WriteLine($" | Número de Aulas: {listadeAula.Count}                | ");
        Console.WriteLine("< ------------------------------------ >");
    }

    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            ExibirMenuPrincipal();

            int escolha;
            if (!int.TryParse(Console.ReadLine(), out escolha))
            {
                Console.WriteLine("Por favor, insira um número válido.");
                continue;
            }

            if (opcoesMenu.ContainsKey(escolha))
            {
                opcoesMenu[escolha].Invoke();
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

            if (escolha == 0)
            {
                continuar = false;
            }

            if (continuar)
            {
                Console.WriteLine("Deseja continuar? (S para sim, qualquer outra tecla para sair): ");
                string resposta = Console.ReadLine();
                if (resposta != "S" && resposta != "s")
                {
                    continuar = false;
                }
            }

            Console.WriteLine();
        }
    }
}
