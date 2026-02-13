 using Atividade03;
     
Console.WriteLine("Digite o nome:");
string nome = Console.ReadLine();

Console.WriteLine("Digite a idade:");
int idade = int.Parse(Console.ReadLine());

Pessoa pessoa = new Pessoa();
pessoa.Nome = nome;
pessoa.Idade = idade;

Console.WriteLine();
pessoa.ExibirDados();

Console.ReadLine();