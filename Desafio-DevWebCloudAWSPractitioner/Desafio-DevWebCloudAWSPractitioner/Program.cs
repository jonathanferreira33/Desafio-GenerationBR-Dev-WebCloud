using Desafio_DevWebCloudAWSPractitioner.Aplicacao.UseCases;
using Desafio_DevWebCloudAWSPractitioner.Application.Gateways;
using Desafio_DevWebCloudAWSPractitioner.Application.UseCases;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DB.Persistence;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext.Persistence;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.Gateways;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:44329");
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Context
builder.Services.AddDbContextPool<AppDBContext>(options =>
{
    var connetionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
});


builder.Services.AddTransient<ISchoolInfosGateway, SchoolInfosInteractor>();
builder.Services.AddTransient<IStudentGateway, StudentInteractor>();

builder.Services.AddTransient<IStudentRepositoryGateway, StudentRepositoryGateway>();
builder.Services.AddTransient<ISchoolInfosRepositoryGateway, SchoolInfosRepositoryGateway>();

builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<ISchoolInfosRepository, SchoolInfosRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
