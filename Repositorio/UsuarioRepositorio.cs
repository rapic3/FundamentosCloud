using Google.Cloud.Firestore;
using Repositorio.Dominio;

namespace Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly FirestoreDb _db;

        public UsuarioRepositorio(FirestoreDb firestore)
        {
            _db = firestore;
        }

        public async Task<List<Usuario>> GetAllUsuarioAsync()
        {
            var UsuariosRef = _db.Collection("Usuarios");
            var snapshot = await UsuariosRef.GetSnapshotAsync();
            var Usuarios = new List<Usuario>();
            foreach (var document in snapshot.Documents)
            {
                Usuarios.Add(document.ConvertTo<Usuario>());
            }
            return Usuarios;
        }

        public async Task<Usuario> GetUsuarioByIdAsync(string id)
        {
            var UsuarioDoc = _db.Collection("Usuarios").Document(id);
            var snapshot = await UsuarioDoc.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                return snapshot.ConvertTo<Usuario>();
            }
            return null;
        }

        public async Task CreateUsuarioAsync(Usuario Usuario)
        {
            var UsuarioRef = _db.Collection("Usuarios").Document(Usuario.Id);
            await UsuarioRef.SetAsync(Usuario);
        }

        public async Task UpdateUsuarioAsync(Usuario Usuario)
        {
            var usuarioRef = _db.Collection("Usuarios").Document(Usuario.Id);

            var updates = new Dictionary<string, object>
            {
                { "Name", Usuario.Name },
                { "LastName", Usuario.LastName },
                { "Phone", Usuario.Phone },
                { "Age", Usuario.Age }
            };

            await usuarioRef.UpdateAsync(updates);
        }


        public async Task DeleteUsuarioAsync(string id)
        {
            var UsuarioRef = _db.Collection("Usuarios").Document(id);
            await UsuarioRef.DeleteAsync();
        }
    }
}
