using Mardre.Controllers;

namespace Mardre.Endpoints;

public static class CategoriaEndpoints
{
    public static void AddCategoriaEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/categorias")
            .WithName("Categorias");

        group.MapGet("/", CategoriaController.GetAll)
            .WithName("GetAllCategorias")
            .Produces(200)
            .Produces(500);

        group.MapGet("/{id}", CategoriaController.GetById)
            .WithName("GetCategoriaById")
            .Produces(200)
            .Produces(404)
            .Produces(500);

        group.MapPost("/", CategoriaController.Create)
            .WithName("CreateCategoria")
            .Produces(201)
            .Produces(400)
            .Produces(500);

        group.MapPost("/search", CategoriaController.Search)
            .WithName("SearchCategoria")
            .Produces(200)
            .Produces(500);

        group.MapPut("/{id}", CategoriaController.Update)
            .WithName("UpdateCategoria")
            .Produces(200)
            .Produces(400)
            .Produces(404)
            .Produces(500);

        group.MapDelete("/{id}", CategoriaController.Delete)
            .WithName("DeleteCategoria")
            .Produces(200)
            .Produces(404)
            .Produces(500);
    }
}
