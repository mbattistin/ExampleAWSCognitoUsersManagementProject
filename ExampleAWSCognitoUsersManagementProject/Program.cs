using ExampleAWSCognitoUsersManagementProject.Domain.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var sendGridConfig = new AWSCognitoConfiguration();
new ConfigureFromConfigurationOptions<AWSCognitoConfiguration>(
    builder.Configuration.GetSection("AWSCognitoConfiguration"))
    .Configure(sendGridConfig);
builder.Services.AddSingleton(sendGridConfig);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
