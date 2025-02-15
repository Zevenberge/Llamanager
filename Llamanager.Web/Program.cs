using Llamanager.Engine;
using Llamanager.Tickets.SelfContained;
using Llamanager.Web;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLlm(options => builder.Configuration.GetSection("Llm").Bind(options));

builder.Services.AddSingleton<SseSessionPool>();
builder.Services.AddSingleton<IDocumentStore>(new DocumentStore
{
    Urls = [ builder.Configuration["Database:Url"] ],
    Database = builder.Configuration["Database:Name"],
});
builder.Services.AddScoped(svp =>
{
    return svp.GetRequiredService<IDocumentStore>().OpenAsyncSession();
});

builder.Services.AddControllers();
var ticketSource = builder.Configuration.TicketSource();
if(ticketSource == "llamanager")
{
    builder.Services.AddSelfContainedTicketing(options => 
    { 
        builder.Configuration.GetSection("SelfContainedTicketing").Bind(options);
    });
}
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
app.UseCors(policy => 
    policy.SetIsOriginAllowed(origin => origin == app.Configuration.Frontend())
);
app.UseTransactions();
app.MapControllers();

app.Run();

