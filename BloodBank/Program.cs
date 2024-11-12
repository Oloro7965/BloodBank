using BloodBank.Application.Commands.CreateDonorCommand;
using BloodBank.Core.Repositories;
using BloodBank.Infraestructure.Persistance;
using BloodBank.Infraestructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BloodBankDBContext>(options =>
        options.UseInMemoryDatabase("bloodBank"));
builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssemblyContaining(typeof(CreateDonorCommand)));
builder.Services.AddScoped<IDonorRepository,DonorRepository>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
