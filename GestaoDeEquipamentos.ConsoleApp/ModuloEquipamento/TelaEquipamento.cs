﻿using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class TelaEquipamento
{
	public RepositorioEquipamento repositorioEquipamento;
	public RepositorioFabricante repositorioFabricante;

	public void ExibirCabecalho()
	{
		Console.Clear();
		Console.WriteLine("Gestão de Equipamentos");
		Console.WriteLine();
	}

	public char ApresentarMenu()
	{
		ExibirCabecalho();

		Console.WriteLine("1 - Cadastro de Equipamento");
		Console.WriteLine("2 - Visualizar Equipamentos");
		Console.WriteLine("3 - Editar Equipamentos");
		Console.WriteLine("4 - Excluir Equipamentos");
		Console.WriteLine("S - Sair");
		Console.WriteLine();

		Console.Write("Digite uma opção válida: ");
		char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

		return opcaoEscolhida;
	}

	public void CadastrarRegistro()
	{
		ExibirCabecalho();

		Console.WriteLine("Cadastro de Equipamentos");
		Console.WriteLine();

		Equipamento equipamento = ObterDados();

		repositorioEquipamento.CadastrarRegistro(equipamento);

		Console.WriteLine($"\nEquipamento \"{equipamento.nome}\" cadastrado com sucesso!");
		Console.ReadLine();
	}

	public void EditarRegistro()
	{
		ExibirCabecalho();

		Console.WriteLine("Edição de Equipamentos");
		Console.WriteLine();

		VisualizarRegistros(false);

		Console.Write("Digite o id do registro que deseja selecionar: ");
		int idSelecionado = Convert.ToInt32(Console.ReadLine());

		Console.WriteLine();

		Equipamento equipamentoAtualizado = ObterDados();

		bool conseguiuEditar = repositorioEquipamento.EditarRegistro(idSelecionado, equipamentoAtualizado);

		if (!conseguiuEditar)
		{
			Console.WriteLine("Não foi possível encontrar o registro selecionado.");
			Console.ReadLine();

			return;
		}

		Console.WriteLine($"\nEquipamento \"{equipamentoAtualizado.nome}\" editado com sucesso!");
		Console.ReadLine();
	}

	public void ExcluirRegistro()
	{
		ExibirCabecalho();

		Console.WriteLine("Exclusão de Equipamentos");

		Console.WriteLine();

		VisualizarRegistros(false);

		Console.Write("Digite o id do registro que deseja selecionar: ");
		int idSelecionado = Convert.ToInt32(Console.ReadLine());

		Console.WriteLine();

		bool conseguiuExcluir = repositorioEquipamento.ExcluirRegistro(idSelecionado);

		if (!conseguiuExcluir)
		{
			Console.WriteLine("Não foi possível encontrar o registro selecionado.");
			Console.ReadLine();

			return;
		}

		Console.WriteLine($"\nEquipamento excluído com sucesso!");
		Console.ReadLine();
	}

	public void VisualizarRegistros(bool exibirCabecalho)
	{
		if (exibirCabecalho == true)
			ExibirCabecalho();

		Console.WriteLine("Visualização de Equipamentos");

		Console.WriteLine();

		Console.WriteLine(
			"{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
			"Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
		);

		EntidadeBase[] equipamentos = repositorioEquipamento.SelecionarRegistros();

		for (int i = 0; i < equipamentos.Length; i++)
		{
			Equipamento e = (Equipamento)equipamentos[i];

			if (e == null)
				continue;

			Console.WriteLine(
				"{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
				e.id, e.nome, e.precoAquisicao.ToString("C2"), e.numeroSerie, e.fabricante.nome, e.dataFabricacao.ToShortDateString()
			);
		}

		Console.ReadLine();
	}

	public void VisualizarFabricantes()
	{
		Console.WriteLine();

		Console.WriteLine("Visualização de Fabricantes");

		Console.WriteLine();

		Console.WriteLine(
			"{0, -10} | {1, -20} | {2, -30} | {3, -15}",
			"Id", "Nome", "Email", "Telefone"
		);

		EntidadeBase[] fabricantes = repositorioFabricante.SelecionarRegistros();

		for (int i = 0; i < fabricantes.Length; i++)
		{
			Fabricante f = (Fabricante)fabricantes[i];

			if (f == null)
				continue;

			Console.WriteLine(
			   "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
				f.id, f.nome, f.email, f.telefone
			);
		}

		Console.ReadLine();
	}

	public Equipamento ObterDados()
	{
		Console.Write("Digite o nome do equipamento: ");
		string nome = Console.ReadLine();

		Console.Write("Digite o preço de aquisição do equipamento: ");
		decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

		Console.Write("Digite o número de série do equipamento: ");
		string numeroSerie = Console.ReadLine();

		Console.Write("Digite a data de fabricação do equipamento: ");
		DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

		VisualizarFabricantes();

		Console.Write("Digite o id do fabricante do equipamento: ");
		int idFabricante = Convert.ToInt32(Console.ReadLine());

		Fabricante fabricanteSelecionado = (Fabricante)repositorioFabricante.SelecionarRegistroPorId(idFabricante);

		Equipamento equipamento = new Equipamento();
		equipamento.nome = nome;
		equipamento.precoAquisicao = precoAquisicao;
		equipamento.numeroSerie = numeroSerie;
		equipamento.fabricante = fabricanteSelecionado;
		equipamento.dataFabricacao = dataFabricacao;

		return equipamento;
	}
}