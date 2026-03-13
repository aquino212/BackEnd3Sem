
namespace EventPlus.WebAPI.Utils;

public class Cryptografia
{
    public static string GerarHash(string senha)
    {
        return BCrypt.Net.BCrypt.HashPassword(senha);
    }
    public static bool VerificarHash(string senhaInformada, string senhaBanco)
    {
        return BCrypt.Net.BCrypt.Verify(senhaInformada, senhaBanco);
    }

    internal static bool CompararHash(string senha1, string senha2)
    {
        throw new NotImplementedException();
    }
}
