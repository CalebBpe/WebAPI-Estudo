using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.HttpOverrides;

var builder  =  WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
//basicamente middleware pega a requisição e faz algo com ela, nesses exemplos abaixo eu  coloquei configurações para a requisição.

app.UseRouting();
//o userouting apenas armazena a rota e preenche algumas informações de seus metodos, por exemplo o 'GetEndpoin()' que armazena o endpoint, mas para armazenar o 'pai' precisa ser chamado primeiro.
app.Use(async (context, next)=>
{
    //para sermos produtivos, armazenamos o endpoint capturado do "userouting" em uma variavel.
    var endpoint = context.GetEndpoint();

    if(endpoint != null)
    {
        Console.WriteLine($"endpoint atual : {endpoint.DisplayName}");
    }
    else
    {
        Console.WriteLine($"Nenhum endpoin encontrado");
    }
    await next.Invoke();
});

app.Use(async (context, next)=>
{//HttpContext context, RequestDelegate next
    //context => representa toda a requisição e resposta
        //context.Request => dados da requisição(rota, headers, body, etc)
        //context.Response => onde escreve a resposta 
        //context.User, context.Items, context.GetEndPoints...

        await next();
        //next é tipo..."prossiga para o proximo middleware"
});

app.MapControllers();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.Use(async (context, next)=>
{
    var lekPede = context.Request;
    var lekResponde = context.Response;
    var ip = context.Connection.RemoteIpAddress?.ToString();
    var ipViaProxy = lekPede.Headers["X-Forwarded-for"].FirstOrDefault();

    var endpoin = context.GetEndpoint();
    if(endpoin != null)
    {
        await lekResponde.WriteAsync("Salve, primeiro exemplo de response, teu ip é: "+ ip + "Ou via proxy" + ipViaProxy);
    }
    else
    {
        Console.WriteLine("AInda nao está na pagina");
        await next();
    }
});


//app.Use() é forma manual de criar middlewares
// app.Use(async (contex, next)=>
// {
//     if(contex.Request.Path == "/salve")
//     {
//         Console.WriteLine("=> antes do proximo middleware");
//         await next.Invoke();
//         Console.WriteLine("=> Depois do proximo middleware");
//     }
// });

app.Run();