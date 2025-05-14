using Application.Interfaces;
using Application.Services;
using Infrastracture.Authentication;
using Infrastracture.Repositories.CompanyPersonImgRepository;
using Infrastracture.Repositories.CompanyPersonRepository;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddScoped<ICompanyPersonService, CompanyPersonService>();
builder.Services.AddScoped<ICompanyPersonRepository, CompanyPersonRepository>();

builder.Services.AddScoped<ICompanyPersonImgService, CompanyPersonImgService>();
builder.Services.AddScoped<ICompanyPersonImgRepository, CompanyPersonImgRepository>();

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services.AddAuthorization();

// CORS ayarı
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:7244") // İzin verilen origin buraya
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
