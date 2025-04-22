using Microsoft.Net.Http.Headers;

namespace FirstAPI.Models;

public class User
{

    public int Id{get; set;}
    public string  Nome{get;set;}
    public string Senha{get;set;}

    public bool ValidarSenha(string senhaDigitada)
    {
        return Senha == senhaDigitada;
    }

    public string Name
    {
        get{return Nome;}
        set
        {
            if(!string.IsNullOrWhiteSpace(value))
            {
                Nome = value;
            }
            else
            {
                Console.WriteLine("Esse nome tá errado aí");
            }
        }
    }
}

public class Teste001
{
    public static void Oi()
    {
        
    }
}