using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{
   // Configure Swagger Page
   var title = "Our Versioned API";
   var description = "Thsi is a Web API that demonstrates versioning";
   var terms = new Uri("https://localhost:7056/terms");
   var license = new OpenApiLicense()
   {
      Name = "This is my full license information or a link to it."
   };

   var contact = new OpenApiContact()
   {
      Name = "Iyad Shobaki Helpdesk",
      Email = "iyad@shobaki.com",
      Url = new Uri("https://www.iyadshobaki.com")
   };

   opts.SwaggerDoc("v1", new OpenApiInfo
   {
      Version = "v1",
      Title = $"{title} v1 (deprecated)",
      Description = description,
      TermsOfService = terms,
      License = license,
      Contact = contact
   });

   opts.SwaggerDoc("v2", new OpenApiInfo
   {
      Version = "v2",
      Title = $"{title} v2",
      Description = description,
      TermsOfService = terms,
      License = license,
      Contact = contact
   });
});

// Versioing Config
builder.Services.AddApiVersioning(opts =>
{
   opts.AssumeDefaultVersionWhenUnspecified = true; // if we don't specify a version, assume its the default version
   opts.DefaultApiVersion = new(2, 0);
   opts.ReportApiVersions = true; //Reporting the version
})
   // Configure Swagger
   .AddApiExplorer(opts =>
   {
      opts.GroupNameFormat = "'v'VVV";
      opts.SubstituteApiVersionInUrl = true;
   });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(opts =>
   {
      opts.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
      opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
   });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
