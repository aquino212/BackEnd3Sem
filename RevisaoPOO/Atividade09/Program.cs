using Atividade09;

Console.WriteLine("Digite o primeiro número:");
int numero1 = int.Parse(Console.ReadLine());

Console.WriteLine("Digite o segundo número:");
int numero2 = int.Parse(Console.ReadLine());

Console.WriteLine("Soma: " + Calculadora.Somar(numero1, numero2));
Console.WriteLine("Multiplicação: " + Calculadora.Multiplicar(numero1, numero2));

