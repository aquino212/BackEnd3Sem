 using Atividade04;


Console.WriteLine("Digite o nome:");
string nome = Console.ReadLine();

Console.WriteLine("Digite a idade:");
int idade = int.Parse(Console.ReadLine());

Pessoa pessoa = new Pessoa(nome, idade);

Console.WriteLine();
pessoa.ExibirDados();


