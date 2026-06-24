namespace Negocio
{
    public static class Mapper
    {
        public static DTO.User Map(Repositorio.Dominio.Usuario usuario)
        {
            return new DTO.User
            {
                Id = usuario.Id,
                Name = usuario.Name,
                LastName = usuario.LastName,
                Phone = usuario.Phone,
                Age = usuario.Age
            };
        }
        public static Repositorio.Dominio.Usuario Map(DTO.User user)
        {
            return new Repositorio.Dominio.Usuario
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Phone = user.Phone,
                Age = user.Age
            };
        }
    }
}
