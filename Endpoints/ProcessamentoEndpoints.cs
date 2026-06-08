using Mardre.Controllers;

namespace Mardre.Endpoints;

public static class ProcessamentoEndpoints
{
    public static void AddProcessamentoEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/processamento")
            .WithName("Processamento");

        group.MapGet("/", ProcessamentoController.GetAll)
            .WithName("GetAllProcessamento")
            .Produces(200)
            .Produces(500);

        group.MapGet("/{id}", ProcessamentoController.GetById)
            .WithName("GetProcessamentoById")
            .Produces(200)
            .Produces(404)
            .Produces(500);

        group.MapPost("/", ProcessamentoController.Create)
            .WithName("CreateProcessamento")
            .Produces(201)
            .Produces(400)
            .Produces(500);

        group.MapPost("/search", ProcessamentoController.Search)
            .WithName("SearchProcessamento")
            .Produces(200)
            .Produces(500);

        group.MapPut("/{id}", ProcessamentoController.Update)
            .WithName("UpdateProcessamento")
            .Produces(200)
            .Produces(400)
            .Produces(404)
            .Produces(500);

        group.MapDelete("/{id}", ProcessamentoController.Delete)
            .WithName("DeleteProcessamento")
            .Produces(200)
            .Produces(404)
            .Produces(500);
    }
}
