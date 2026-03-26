using SmartSaleApi.Extensions.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSecurity(builder.Configuration);
builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddContexts(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddSettings(builder.Configuration);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
