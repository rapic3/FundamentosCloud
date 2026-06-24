using Google.Cloud.Firestore;

namespace Repositorio.Dominio
{
    [FirestoreData] 
    public class Usuario
    {
        [FirestoreDocumentId] 
        public string Id { get; set; }

        [FirestoreProperty("Name")]
        public string Name { get; set; }

        [FirestoreProperty("LastName")] 
        public string LastName { get; set; }

        [FirestoreProperty("Phone")]
        public string Phone { get; set; }

        [FirestoreProperty("Age")]
        public int Age { get; set; }
    }
}
