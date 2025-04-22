using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class HelloControler : ControllerBase
    {
        [HttpGet]
        [Route("/salve")]
        public IActionResult Get()
        {
            return Ok(new { messagem = "Salve, meu men. So passando aqui pra dizer que vc ta no caminho certo, tudo bem se esquecer de conceitos as vezes, o importante é que voce continue praticando!"});
        }

        [HttpGet]
        [Route("/not")]
        public IActionResult Result()
        {
            return Ok(new {messagem = "Outro exemplo meu lek"});
        }
    }
}