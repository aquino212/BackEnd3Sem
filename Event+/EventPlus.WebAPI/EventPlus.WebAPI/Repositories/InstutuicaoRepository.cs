

using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class InstituicaoRepository : IInstituicaoRepository
{
    private readonly EventContext _Context;
    public InstituicaoRepository(EventContext context)
    {
        _Context = context;
    }

    /// <summary>
    /// Atualida um instituicao usando o restreamento automático.
    /// </summary>
    /// <param name="id">id do instituicao a ser atualizado</param>
    /// <param name="instituicao">Novos dados </param>
    public void Atualizar(Guid id, Instituicao instituicao)
    {
        var instituicaoExistente = _Context.Instituicaos.Find(id);
        if (instituicaoExistente == null)
        {
            instituicaoExistente.Nome = instituicao.Nome;
            instituicaoExistente.Endereco = instituicao.Endereco;
            instituicaoExistente.Cnpj = instituicao.Cnpj;
            _Context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca um instituicao por seu Id.
    /// </summary>
    /// <param name="id">id da instituicao a ser busacado</param>
    /// <returns>Objeto do TipoEvento com as informações da instituicao buscado</returns>
    public Instituicao BuscarPorId(Guid id)
    {
        return _Context.Instituicaos.Find(id);
    }

    /// <summary>
    /// Cadastra uma nova instituicao.
    /// </summary>
    /// <param name="instituicao">A instituicao a ser cadastrado</param>
    public void Cadastrar(Instituicao instituicao)
    {
        _Context.Instituicaos.Add(instituicao);
        _Context.SaveChanges();
    }

    /// <summary>
    /// Deleta a instituicao
    /// </summary>
    /// <param name="IdInstituicao">id da instituicao a ser deletado</param>
    public void Deletar(Guid IdInstituicao)
    {
        var instituicaoExistente = _Context.Instituicaos.Find(IdInstituicao);
        if (instituicaoExistente != null)
        {
            _Context.Instituicaos.Remove(instituicaoExistente);
            _Context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca a lista da instituicao cadastrados
    /// </summary>
    /// <returns>Uma lista da instituicao</returns>
    public List<Instituicao> Listar()
    {
        return _Context.Instituicaos.OrderBy(instituicao => instituicao.Nome).ToList();
    }
}
