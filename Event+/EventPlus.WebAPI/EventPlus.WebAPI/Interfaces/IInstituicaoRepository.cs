using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface IInstituicaoRepository
{
        void Cadastrar(Instituicao instituicao);
        void Deletar(Guid IdInstituicao);
        List<Instituicao> Listar();
        Models.Instituicao BuscarPorId(Guid id);
        void Atualizar(Guid id, Instituicao instituicao);
}
