using Echeinbetter.Database;
using Echeinbetter.Dtos;
using Echeinbetter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Echeinbetter.Controllers
{
    public class MateriaPrimaController
    {
        [HttpGet("/api/materiaprima")]
        public static IResult GetAll(HttpContext http)
        {
            try
            {
                var context = new EngenhariasSenacContext();
                var dal = new DAL<MateriaPrima>(context);
                return Results.Ok(dal.Select());
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao buscar matérias-primas: " + ex.Message);
            }
        }

        [HttpGet("/api/materiaprima/{id}")]
        public static IResult GetById(int id, HttpContext http)
        {
            try
            {
                var context = new EngenhariasSenacContext();
                var dal = new DAL<MateriaPrima>(context);
                var item = dal.SelectWhere(e => e.CodMateria == id);

                if (item == null)
                    return Results.NotFound(new { message = $"Matéria-prima com ID {id} não encontrada" });

                return Results.Ok(item);
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao buscar matéria-prima: " + ex.Message);
            }
        }

        [HttpPost("/api/materiaprima")]
        public static IResult Create(CreateMateriaPrimaDto dto, HttpContext http)
        {
            try
            {
                var item = new MateriaPrima
                {
                    Descricao = dto.Descricao,
                    CodigoBarras = dto.CodigoBarras,
                    CodCategoria = dto.CodCategoria,
                    EstoqueMin = dto.EstoqueMin,
                    EstoqueMax = dto.EstoqueMax,
                    Tipo = dto.Tipo,
                    Descarte = dto.Descarte,
                    FatorCo2 = dto.FatorCo2,
                    EmissaoCo2 = dto.EmissaoCo2
                };

                var context = new EngenhariasSenacContext();
                var dal = new DAL<MateriaPrima>(context);
                dal.Insert(item);

                return Results.Created($"/api/materiaprima/{item.CodMateria}", item);
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao criar matéria-prima: " + ex.Message);
            }
        }

        [HttpPut("/api/materiaprima/{id}")]
        public static IResult Update(int id, UpdateMateriaPrimaDto dto, HttpContext http)
        {
            try
            {
                if (id != dto.CodMateria)
                    return Results.BadRequest(new { message = "ID da URL não corresponde ao ID do corpo da requisição" });

                var context = new EngenhariasSenacContext();
                var dal = new DAL<MateriaPrima>(context);
                var item = dal.SelectWhere(e => e.CodMateria == id);

                if (item == null)
                    return Results.NotFound(new { message = $"Matéria-prima com ID {id} não encontrada" });

                item.Descricao = dto.Descricao;
                item.CodigoBarras = dto.CodigoBarras;
                item.CodCategoria = dto.CodCategoria;
                item.EstoqueMin = dto.EstoqueMin;
                item.EstoqueMax = dto.EstoqueMax;
                item.Tipo = dto.Tipo;
                item.Descarte = dto.Descarte;
                item.FatorCo2 = dto.FatorCo2;
                item.EmissaoCo2 = dto.EmissaoCo2;

                dal.Update(item);

                return Results.Ok(new { message = "Matéria-prima atualizada com sucesso", data = item });
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao atualizar matéria-prima: " + ex.Message);
            }
        }

        [HttpDelete("/api/materiaprima/{id}")]
        public static IResult Delete(int id, HttpContext http)
        {
            try
            {
                var context = new EngenhariasSenacContext();
                var dal = new DAL<MateriaPrima>(context);
                var item = dal.SelectWhere(e => e.CodMateria == id);

                if (item == null)
                    return Results.NotFound(new { message = $"Matéria-prima com ID {id} não encontrada" });

                dal.Delete(item);

                return Results.Ok(new { message = $"Matéria-prima com ID {id} excluída com sucesso" });
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao excluir matéria-prima: " + ex.Message);
            }
        }

        [HttpPost("/api/materiaprima/search")]
        public static IResult Search(SearchMateriaPrimaDto? dto, HttpContext http)
        {
            try
            {
                var context = new EngenhariasSenacContext();
                var dal = new DAL<MateriaPrima>(context);

                if (dto == null || string.IsNullOrWhiteSpace(dto.CodigoBarras))
                    return Results.Ok(dal.Select());

                var result = dal.SelectWhereList(
                    e => e.CodigoBarras != null && e.CodigoBarras.ToLower().Contains(dto.CodigoBarras.ToLower())
                );

                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao buscar matérias-primas: " + ex.Message);
            }
        }
    }
}
