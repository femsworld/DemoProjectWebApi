using DemoProject;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Lifetimes
//Scoped create a new instance for each HTTP request (Recommended for ASP.NET Core most of the time)
//Transient create a new instance every time the service is requested
//Singletons -> it creates only one instance for as long as the application us running

builder.Services.AddScoped<NameService>();
builder.Services.AddScoped<SomeOtherService>();

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
