﻿using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class Equipamento : EntidadeBase
{
	public int id;
	public string nome;
	public decimal precoAquisicao;
	public string numeroSerie;
	public Fabricante fabricante;
	public DateTime dataFabricacao;

	public override void AtualizarRegistro(EntidadeBase registroAtualizado)
	{
		Equipamento equipamentoAtualizado = (Equipamento)registroAtualizado;

		this.nome = equipamentoAtualizado.nome;
		this.precoAquisicao = equipamentoAtualizado.precoAquisicao;
		this.numeroSerie = equipamentoAtualizado.numeroSerie;
		this.fabricante = equipamentoAtualizado.fabricante;
		this.dataFabricacao = equipamentoAtualizado.dataFabricacao;
	}
}