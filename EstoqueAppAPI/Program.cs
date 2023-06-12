
using EstoqueApp.API.Extensions;
using EstoqueAppAPI.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRouting(map => map.LowercaseUrls = true);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerDoc();
builder.Services.AddCorsPolicy();
builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddServices(builder.Configuration);
builder.Services.AddAutoMapperProfiles();
builder.Services.AddMediatR();
builder.Services.AddJwtBearer(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwaggerDoc();
app.UseCorsPolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }