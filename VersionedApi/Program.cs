var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Versioing Config
builder.Services.AddApiVersioning(opts =>
{
   opts.AssumeDefaultVersionWhenUnspecified = true; // if we don't specify a version, assume its the default version
   opts.DefaultApiVersion = new(1, 0);
   opts.ReportApiVersions = true; //Reporting the version
});


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
