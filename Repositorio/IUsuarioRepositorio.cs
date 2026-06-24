using Repositorio.Dominio;

namespace Repositorio
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> GetAllUsuarioAsync();
        Task<Usuario> GetUsuarioByIdAsync(string id);
        Task CreateUsuarioAsync(Usuario user);
        Task UpdateUsuarioAsync(Usuario user);
        Task DeleteUsuarioAsync(string id);
    }
}
