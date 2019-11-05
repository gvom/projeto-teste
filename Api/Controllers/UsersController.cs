using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Models;
using Api.Configuration;
using Api.Interface;
using System;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly AplicacaoContext _context;

        public UsersController(IUserService userService, AplicacaoContext context)
        {
            _userService = userService;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public IActionResult Autenticar([FromBody]AutenticacaoUsuarioModel model)
        {
            Console.WriteLine("oi");
            var user = _userService.Autenticar(model.Nome, model.Senha);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}
