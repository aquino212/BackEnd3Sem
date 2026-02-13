using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade03
{
class Pessoa
{
    public string Nome;

    private int idade;

    public int Idade
    {
        get { return idade; }
        set
        {
            if (value > 0)
            {
                idade = value;
            }
        }
    }

    public void ExibirDados()
    {
        Console.WriteLine("Nome: " + Nome);
        Console.WriteLine("Idade: " + Idade);
    }
}
}