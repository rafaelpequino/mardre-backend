using Echeinbetter.Database;
using Echeinbetter.Dtos;
using Echeinbetter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Echeinbetter.Controllers
{
    public class CategoriaController
    {
        [HttpGet("/api/categorias")]
        public static IResult GetAll(HttpContext http)
        {
            try
            {
                var context = new EngenhariasSenacContext();
                var dal = new DAL<Categoria>(context);
                return Results.Ok(dal.Select());
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao buscar categorias: " + ex.Message);
            }
        }

        [HttpGet("/api/categorias/{id}")]
        public static IResult GetById(int id, HttpContext http)
        {
            try
            {
                var context = new EngenhariasSenacContext();
                var dal = new DAL<Categoria>(context);
                var item = dal.SelectWhere(e => e.CodCategoria == id);

                if (item == null)
                    return Results.NotFound(new { message = $"Categoria com ID {id} não encontrada" });

                return Results.Ok(item);
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao buscar categoria: " + ex.Message);
            }
        }

        [HttpPost("/api/categorias")]
        public static IResult Create(CreateCategoriaDto dto, HttpContext http)
        {
            try
            {
                var item = new Categoria
                {
                    Descricao = dto.Descricao
                };

                var context = new EngenhariasSenacContext();
                var dal = new DAL<Categoria>(context);
                dal.Insert(item);

                return Results.Created($"/api/categorias/{item.CodCategoria}", item);
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao criar categoria: " + ex.Message);
            }
        }

        [HttpPut("/api/categorias/{id}")]
        public static IResult Update(int id, UpdateCategoriaDto dto, HttpContext http)
        {
            try
            {
                if (id != dto.CodCategoria)
                    return Results.BadRequest(new { message = "ID da URL não corresponde ao ID do corpo da requisição" });

                var context = new EngenhariasSenacContext();
                var dal = new DAL<Categoria>(context);
                var item = dal.SelectWhere(e => e.CodCategoria == id);

                if (item == null)
                    return Results.NotFound(new { message = $"Categoria com ID {id} não encontrada" });

                item.Descricao = dto.Descricao;
                dal.Update(item);

                return Results.Ok(new { message = "Categoria atualizada com sucesso", data = item });
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao atualizar categoria: " + ex.Message);
            }
        }

        [HttpDelete("/api/categorias/{id}")]
        public static IResult Delete(int id, HttpContext http)
        {
            try
            {
                var context = new EngenhariasSenacContext();
                var dal = new DAL<Categoria>(context);
                var item = dal.SelectWhere(e => e.CodCategoria == id);

                if (item == null)
                    return Results.NotFound(new { message = $"Categoria com ID {id} não encontrada" });

                dal.Delete(item);

                return Results.Ok(new { message = $"Categoria com ID {id} excluída com sucesso" });
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao excluir categoria: " + ex.Message);
            }
        }

        [HttpPost("/api/categorias/search")]
        public static IResult Search(CreateCategoriaDto? dto, HttpContext http)
        {
            try
            {
                var context = new EngenhariasSenacContext();
                var dal = new DAL<Categoria>(context);

                if (dto == null || string.IsNullOrWhiteSpace(dto.Descricao))
                    return Results.Ok(dal.Select());

                var result = dal.SelectWhereList(
                    e => e.Descricao != null && e.Descricao.ToLower().Contains(dto.Descricao.ToLower())
                );

                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao buscar categorias: " + ex.Message);
            }
        }
    }
}
