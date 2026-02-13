using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade08
{
class Usuario : IAutenticavel
 {
    public string Nome;
    private string senha;

    public Usuario(string nome, string senha)
    {
        Nome = nome;
        this.senha = senha;
    }

    public bool Autenticar(string senha)
    {
        return this.senha == senha;
    }
 }
}