namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class RepositorioFabricante
{
    public Fabricante[] fabricantes = new Fabricante[100];
    public int contadorFabricantes = 0;

    public void CadastrarFabricante(Fabricante fabricante)
    {
        fabricante.id = ++contadorFabricantes;
        fabricantes[contadorFabricantes - 1] = fabricante;
    }

    public bool EditarFabricante(int idSelecionado, Fabricante fabricanteAtualizado)
    {
        Fabricante fabricanteSelecionado = SelecionarFabricantePorId(idSelecionado);

        if (fabricanteSelecionado == null)
            return false;

        fabricanteSelecionado.nome = fabricanteAtualizado.nome;
        fabricanteSelecionado.email = fabricanteAtualizado.email;
        fabricanteSelecionado.telefone = fabricanteAtualizado.telefone;

        return true;
    }

    public bool ExcluirFabricante(int idSelecionado)
    {
        for (int i = 0; i < fabricantes.Length; i++)
        {
            if (fabricantes[i] == null)
                continue;

            if (fabricantes[i].id == idSelecionado)
            {
                fabricantes[i] = null;
                return true;
            }
        }

        return false;
    }

    public Fabricante[] SelecionarFabricantes()
    {
        return fabricantes;
    }

    public Fabricante SelecionarFabricantePorId(int idSelecionado)
    {
        foreach (var f in fabricantes)
        {
            if (f != null && f.id == idSelecionado)
                return f;
        }

        return null;
    }
}