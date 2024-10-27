using FirefishTechnicalTaskAPI.Interfaces.Repositories;
using FirefishTechnicalTaskAPI.Interfaces.Services;
using FirefishTechnicalTaskAPI.Repositories;
using FirefishTechnicalTaskAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string sqlConnectionString = builder.Configuration.GetConnectionString("SQLConnectionString") ?? throw new InvalidOperationException("Incorrect SQL Connection String");

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers();

builder.Services.AddSingleton<ICandidateRepository, CandidateRepository>(x => ActivatorUtilities.CreateInstance<CandidateRepository>(x, sqlConnectionString));
builder.Services.AddSingleton<ICandidateService, CandidateService>();

var app = builder.Build();

app.UseRouting();

app.UseCors("AllowSpecificOrigin"); // Use the CORS policy

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

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