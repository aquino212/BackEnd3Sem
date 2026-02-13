using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade08
{
class Administrador : IAutenticavel
 {
    public string Nome;
    private string senha;

    public Administrador(string nome, string senha)
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