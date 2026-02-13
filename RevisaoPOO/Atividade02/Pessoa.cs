using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade02
{
    using System;

    class Pessoa
    {
    public string Nome;
    public int Idade;

    public void ExibirDados()
     {
        Console.WriteLine("Nome: " + Nome);
        Console.WriteLine("Idade: " + Idade);
     }
    }

}