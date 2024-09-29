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
    })
    .AddEntityFrameworkStores<ToDoAppDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();