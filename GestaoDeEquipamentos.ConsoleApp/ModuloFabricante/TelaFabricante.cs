namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class TelaFabricante
{
    public RepositorioFabricante repositorioFabricante;

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine();
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine("1 - Cadastrar Fabricante");
        Console.WriteLine("2 - Visualizar Fabricantes");
        Console.WriteLine("3 - Editar Fabricante");
        Console.WriteLine("4 - Excluir Fabricante");
        Console.WriteLine("S - Voltar");

        Console.Write("\nEscolha uma opção: ");
        char opcao = Console.ReadLine().ToUpper()[0];

        return opcao;
    }

    public void CadastrarRegistro()
    {
        ExibirCabecalho();
        Console.WriteLine("Cadastro de Fabricante\n");

        Fabricante fabricante = ObterDados();

        repositorioFabricante.CadastrarFabricante(fabricante);

        Console.WriteLine("\nFabricante cadastrado com sucesso!");
        Console.ReadLine();
    }

    public void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Fabricantes\n");

        Console.WriteLine("{0,-5} | {1,-20} | {2,-25} | {3,-15}", "Id", "Nome", "Email", "Telefone");

        var fabricantes = repositorioFabricante.SelecionarFabricantes();

        foreach (var f in fabricantes)
        {
            if (f == null) continue;

            Console.WriteLine("{0,-5} | {1,-20} | {2,-25} | {3,-15}", f.id, f.nome, f.email, f.telefone);
        }

        Console.ReadLine();
    }

    public void EditarRegistro()
    {
        ExibirCabecalho();
        Console.WriteLine("Edição de Fabricante\n");

        VisualizarRegistros(false);

        Console.Write("Digite o ID do fabricante a editar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Fabricante novo = ObterDados();

        bool editado = repositorioFabricante.EditarFabricante(id, novo);

        if (!editado)
            Console.WriteLine("\nFabricante não encontrado!");
        else
            Console.WriteLine("\nFabricante editado com sucesso!");

        Console.ReadLine();
    }

    public void ExcluirRegistro()
    {
        ExibirCabecalho();
        Console.WriteLine("Exclusão de Fabricante\n");

        VisualizarRegistros(false);

        Console.Write("Digite o ID do fabricante a excluir: ");
        int id = Convert.ToInt32(Console.ReadLine());

        bool excluido = repositorioFabricante.ExcluirFabricante(id);

        if (!excluido)
            Console.WriteLine("\nFabricante não encontrado!");
        else
            Console.WriteLine("\nFabricante excluído com sucesso!");

        Console.ReadLine();
    }

    private Fabricante ObterDados()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        return new Fabricante
        {
            nome = nome,
            email = email,
            telefone = telefone
        };
    }
}