using Atividade08;

Usuario usuario = new Usuario("Ivan", "1234");
Administrador admin = new Administrador("Admin", "4321");

Console.WriteLine("Usuário autenticado? " + usuario.Autenticar("1234"));
Console.WriteLine("Administrador autenticado? " + admin.Autenticar("4321"));
