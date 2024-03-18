using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();
builder.Services.AddSingleton(jwtOptions);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opts =>
    {
        var signingKeyBytes = Encoding.UTF8.GetBytes(jwtOptions.SigningKey);
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:5282",
            ValidAudience = "https://localhost:5282",
            IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
        };
    });

builder.Services.AddAuthorization();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();


app.MapPost("/login", (HttpContext ctx, JwtOptions jwtOptions) => TokenEndpoint.Connect(ctx, jwtOptions));
//app.MapGet("/jwt-token/headers", (HttpContext ctx) =>
//{
//    if (ctx.Request.Headers.TryGetValue("Authorization", out var headerAuth))
//    {
//        var jwtToken = headerAuth.First().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
//        return Task.FromResult(Results.Ok(new { token = jwtToken }));
//    }
//    return Task.FromResult(Results.NotFound(new { message = "jwt not found" }));
//});

//app.MapGet("/jwt-token/context", async (HttpContext ctx) =>
//{
//    var token = await ctx.GetTokenAsync("access_token");

//    return Results.Ok(new { token = token });
//});



app.MapControllers();

app.Run();
