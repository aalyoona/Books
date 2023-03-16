using Books.API.Configs;
using Books.API.Extensions;
using Books.API.Infrastructure;
using Books.BLL.Configs;
using Books.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string _connectionStringVariableName = "CONNECTION_STRING";
string conString = builder.Configuration.GetValue<string>(_connectionStringVariableName);

builder.Services.AddAutoMapper(typeof(BuisnessMapper).Assembly, typeof(DataMapper).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<BooksContext>(options =>
            options.UseSqlServer(conString));

builder.Services.AddSwagger();

builder.Services.RegisterDependency();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseMiddleware<GlobalExceptionHandler>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
