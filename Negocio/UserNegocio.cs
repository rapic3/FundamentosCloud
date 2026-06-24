using DTO;
using Repositorio;
using Repositorio.Dominio;

namespace Negocio
{
    public class UserNegocio : IUserNegocio
    {
        private readonly IUsuarioRepositorio _repoUserService;

        public UserNegocio(IUsuarioRepositorio repoUserService)
        {
            _repoUserService = repoUserService;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var usuario = await _repoUserService.GetAllUsuarioAsync();

            return usuario.Select(Mapper.Map).ToList();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var usuario = await _repoUserService.GetUsuarioByIdAsync(id);
            return Mapper.Map(usuario);
        }

        public Task CreateUserAsync(User user)
        {
            Usuario usuario = Mapper.Map(user);

            return _repoUserService.CreateUsuarioAsync(usuario);
        }

        public Task UpdateUserAsync(User user)
        {
            Usuario usuario = Mapper.Map(user);

            return _repoUserService.UpdateUsuarioAsync(usuario);
        }

        public Task DeleteUserAsync(string id)
        {
            return _repoUserService.DeleteUsuarioAsync(id);
        }
    }
}
