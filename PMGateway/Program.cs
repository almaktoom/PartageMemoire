using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using PMGateway.Services;
using ServiceMetier;
using System.Text;
using PMGateway.Model;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Configuration de la chaîne de connexion
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21)))); // Remplacez par votre version de MySQL

// Ajouter Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

//builder.Services.AddDbContext<YourDbContext>();

/*builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<>()
    .AddDefaultTokenProviders();*/



builder.Services.AddScoped<Service1Client>();

// Autres services...


// ...


// Configuration de l'authentification JWT
// Charger les paramètres JwtSettings
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<PMGateway.Model.JwtSettings>();

// Configuration de l'authentification JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
    };
});

// Ajouter les services à la conteneur
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Ajouter des services 
builder.Services.AddScoped<ICommentaireService, CommentaireService>();
builder.Services.AddScoped<IPersonneService, PersonneService>();
builder.Services.AddScoped<IProfesseurService, ProfesseurService>();
builder.Services.AddScoped<IEtudiantService, EtudiantService>();
builder.Services.AddScoped<IDepartementService, DepartementService>();
builder.Services.AddScoped<IFiliereService, FiliereService>();
builder.Services.AddScoped<IJuryService, JuryService>();
builder.Services.AddScoped<IMemoireService, MemoireService>();
//builder.Services.AddScoped<JwtTokenService>();

// Configuration du client WCF (décommenter si nécessaire)
// builder.Services.AddScoped<Service1Client>();

var app = builder.Build();

// Configuration du pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Ajoutez cette ligne pour activer l'authentification
app.UseAuthorization();

app.MapControllers();

app.Run();
