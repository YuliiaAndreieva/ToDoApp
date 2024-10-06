using FluentValidation;
using Microsoft.AspNetCore.Identity;
using ToDoApp.API.Configuration;
using ToDoApp.BLL.Validation.Category;
using ToDoApp.DAL.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStorage(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryDtoValidator>();
builder.Services.AddServices();
builder.Services.AddJwtSettings(builder.Configuration);
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedEmail = false;  
        options.Tokens.AuthenticatorTokenProvider = null;
    })
    .AddEntityFrameworkStores<ToDoAppDbContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:5000", "http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var seeder = new DatabaseSeeder(app.Services);
await seeder.SeedAsync();

app.UseCors("AllowOrigins");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();