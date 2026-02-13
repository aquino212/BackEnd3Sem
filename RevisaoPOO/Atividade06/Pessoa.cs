using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade06
{
 class Pessoa
{
    public string Nome;
    public int Idade;

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade > 0 ? idade : 0;
    }

    public void ExibirDados()
    {
        Console.WriteLine("Nome: " + Nome);
        Console.WriteLine("Idade: " + Idade);
    }

    // Método sem parâmetro
    public void Apresentar()
    {
        Console.WriteLine("Olá, meu nome é " + Nome);
    }

    // Método com parâmetro (sobrecarga)
    public void Apresentar(string sobrenome)
    {
        Console.WriteLine("Olá, meu nome é " + Nome + " " + sobrenome);
    }
}
}