using Echeinbetter.Controllers;

namespace Echeinbetter.Endpoints;

public static class MateriaPrimaEndpoints
{
    public static void AddMateriaPrimaEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/materiaprima")
            .WithName("MateriaPrima");

        group.MapGet("/", MateriaPrimaController.GetAll)
            .WithName("GetAllMateriaPrima")
            .Produces(200)
            .Produces(500);

        group.MapGet("/{id}", MateriaPrimaController.GetById)
            .WithName("GetMateriaPrimaById")
            .Produces(200)
            .Produces(404)
            .Produces(500);

        group.MapPost("/", MateriaPrimaController.Create)
            .WithName("CreateMateriaPrima")
            .Produces(201)
            .Produces(400)
            .Produces(500);

        group.MapPost("/search", MateriaPrimaController.Search)
            .WithName("SearchMateriaPrima")
            .Produces(200)
            .Produces(500);

        group.MapPut("/{id}", MateriaPrimaController.Update)
            .WithName("UpdateMateriaPrima")
            .Produces(200)
            .Produces(400)
            .Produces(404)
            .Produces(500);

        group.MapDelete("/{id}", MateriaPrimaController.Delete)
            .WithName("DeleteMateriaPrima")
            .Produces(200)
            .Produces(404)
            .Produces(500);
    }
}
