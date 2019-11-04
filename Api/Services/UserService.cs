using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Api.Configuration;
using Api.Interface;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly AplicacaoContext _context;

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, AplicacaoContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

            public UsuarioModel Autenticar(string nome, string senha)
        {
            var usuario = this._context.Usuario.SingleOrDefault(x => x.Nome == nome && x.Senha == senha);

            if (usuario == null)
                return null;

            // Gerar o JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var usuarioModel = new UsuarioModel();
            usuarioModel.Id = usuario.Id;
            usuarioModel.Nome = usuario.Nome;
            usuarioModel.Role = usuario.Role;
            usuarioModel.Token = tokenHandler.WriteToken(token);

            return usuarioModel;
        }
    }
}