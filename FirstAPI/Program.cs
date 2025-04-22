var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

//a gente coloca em app para facilitar o acesso, caso contrario teriamos que colocar todos esses argumetos abaixo
// builder.Build().UseCookiePolicy().UseAntiforgery();

//middleware recebe é um pedaço de codigo que recebe uma requisição http(s) e faz algo com ela. Retorna metodos/autentica/retorna/ler arquivos
//no caso ele verifica todos esses pontos para ai sim ele da um "app.run()"
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); 

app.Use(async (context, next)=>
{
    if(context.Request.Path == "/hello")
    {
        context.Response.StatusCode = 403;
        await context.Response.WriteAsync("Acesso bloqueado");
    }
    else
    {
        await next();
    }
});

//so depois que ele roda, podera ter acesso aos endpoints
app.Run();