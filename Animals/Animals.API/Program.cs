using Animals.API.Filters;
using Animals.API.Interfaces;
using Animals.API.Middlewares;
using Animals.API.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddSingleton<IAnimalService, AnimalService>();
//builder.Services.AddTransient<ExceptionHandlerMiddleware>();
//builder.Services.AddTransient<AnimalMiddleware>();
//builder.Services.AddTransient<AnMiddlware>();
//builder.Services.AddControllers(opt=>opt.Filters.Add(new ErrorHandlerFilter()));

//builder.Services.AddControllers(opt=>opt.Filters.Add(new TimeFilter()));
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

//app.UseMiddleware<ExceptionHandlerMiddleware>();

//app.UseMiddleware<AnimalMiddleware>();

//app.UseMiddleware<AnMiddlware>();

app.MapControllers();

app.Run();