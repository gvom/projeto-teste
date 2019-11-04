using WebApi.Models;

namespace Api.Interface
{
    public interface IUserService
    {
        UsuarioModel Autenticar(string nome, string senha);
    }
}