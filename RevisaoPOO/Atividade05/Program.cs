using Atividade05;


Console.WriteLine("Digite o nome:");
string nome = Console.ReadLine();

Console.WriteLine("Digite a idade:");
int idade = int.Parse(Console.ReadLine());

Console.WriteLine("Digite o salário:");
double salario = double.Parse(Console.ReadLine());

Funcionario funcionario = new Funcionario(nome, idade, salario);

Console.WriteLine();
funcionario.ExibirDadosFuncionario();


