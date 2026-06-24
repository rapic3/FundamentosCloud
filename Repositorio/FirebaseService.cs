using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace Repositorio
{
    public class FirebaseService
    {
        static FirebaseService()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "poli-nube-firebase.json");
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.GetApplicationDefault()
            });
        }

        public static void InitializeFirebase()
        {
            // Initialize Firebase here if needed
        }
    }
}


