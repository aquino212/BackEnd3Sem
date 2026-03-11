namespace EventPlus.WebAPI.Interfaces;

public interface IInstituicaoRepository
{
        void Cadastrar(Models.Instituicao instituicao);
        void Deletar(Guid IdInstituicao);
        List<Models.Instituicao> Listar();
        Models.Instituicao BuscarPorId(Guid id);
        void Atualizar(Guid id, Models.Instituicao instituicao);
}
