using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Negocio;
using Repositorio;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var pathToJson = Path.Combine(Directory.GetCurrentDirectory(), "poli-nube-firebase.json");

GoogleCredential credential;
using (var stream = new FileStream(pathToJson, FileMode.Open, FileAccess.Read))
{
    credential = GoogleCredential.FromStream(stream);

    // Initialize FirebaseApp if you need it for Auth, Messaging, etc.
    FirebaseApp.Create(new AppOptions()
    {
        Credential = credential,
        ProjectId = "poli-nube"
    });
}

builder.Services.AddSingleton<FirestoreDb>(provider =>
{
    // Build the Firestore Client using the credential we just loaded
    var clientBuilder = new FirestoreClientBuilder
    {
        Credential = credential
    };
    var client = clientBuilder.Build();

    // Create the FirestoreDb instance bound to that client
    return FirestoreDb.Create("poli-nube", client);
});

// Repositorio
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

// Negocio
builder.Services.AddScoped<IUserNegocio, UserNegocio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Index}/{id?}");

app.Run();
