using BooksAPI.Models;

var builder = WebApplication.CreateBuilder();
builder.Services.AddSqlServer<BooksContext>(builder.Configuration.GetConnectionString("BooksConnection"));
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Books API v1"));
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();
app.Run();

