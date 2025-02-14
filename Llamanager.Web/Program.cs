using Llamanager.Engine;
using Llamanager.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLlm(options => builder.Configuration.GetSection("Llm").Bind(options));

builder.Services.AddSingleton<SseSessionPool>();

builder.Services.AddControllers();
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

app.MapControllers();

app.Run();

