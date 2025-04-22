using System.IO.Pipelines;
using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("hello")]
    public class HelloControler : ControllerBase
    {   
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { mensagem = "Salve, meu lek. Minha primeira API aqui hehehe"});
        } 
        [Route("salve")]
        [HttpGet]
        public IActionResult GetResult()
        {
            return Ok(new {messagem = "OUtra rota teste"});
        }
    }
    [Route("not")]
    public class OlaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Oloko() => Ok("Salve, meu lek");
    }
    [Route("/")]

    public class RotaPrincipal : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html");
            return PhysicalFile(filePath, "text/html");
        }
    }
    [Route("usuarios")]
    public class LogicadeSenha : ControllerBase
    {
        private static List<User> usuarios = new List<User>
        {
            new User{Nome = "Rafael", Senha = "Flamengo_Campeao(nao pego ninguem)"}
        };

        [HttpGet]
        public IActionResult Mostrar()
        {
            return Ok(usuarios);
        }

        [HttpPost]
        public IActionResult CriarUsuario([FromBody] User novoUsuario)
        {
            usuarios.Add(novoUsuario);
            return Ok(new {messagem = "Novo usuario criado!"});
        }
    }
}