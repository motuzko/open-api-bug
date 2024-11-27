using Demo.Models.Models;
using Scalar.AspNetCore;

var tmpBuilder = WebApplication.CreateBuilder(args);

tmpBuilder.Services.AddOpenApi(
    inOptions => inOptions.AddDocumentTransformer(
        (inDocument,
            inContext,
            inToken) =>
        {
            inDocument.Info.Version = "v0.2";
            inDocument.Info.Title = "System.Text.Json Playground Web API";

            return Task.CompletedTask;
        }));

var tmpApp = tmpBuilder.Build();

// Configure the HTTP request pipeline.
if (tmpApp.Environment.IsDevelopment())
{
    tmpApp.MapOpenApi();
    tmpApp.MapScalarApiReference(
        inOptions => inOptions.WithDefaultHttpClient(
            ScalarTarget.CSharp,
            ScalarClient.HttpClient));
}

tmpApp.UseHttpsRedirection();

string[] tmpSummaries =
[
    "Freezing",
    "Bracing",
    "Chilly",
    "Cool",
    "Mild",
    "Warm",
    "Balmy",
    "Hot",
    "Sweltering",
    "Scorching"
];

tmpApp.MapGet(
    "/test",
    () => new RiskArraySourceMarginBreakdown(default!, default!, default!, default!, default!, default!, default!,
        default!, default!, default!, default!, default!, default!, default!));

tmpApp
    .MapGet(
        "/",
        () => Results.Redirect("/scalar/v1"))
    .ExcludeFromDescription();

tmpApp.Run();