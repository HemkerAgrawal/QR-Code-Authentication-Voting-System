

//using Microsoft.EntityFrameworkCore;
//using VoteApi.Data;





var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<ApiContext>
  //  (opt => opt.UseInMemoryDatabase("C:\\Users\\ishee\\source\\repos\\FingerPrint_Voting_Systen\\bin\\dbase.db"));

// Add services to the container.

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
