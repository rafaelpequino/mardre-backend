using Mardre.Database;
using Mardre.Dtos;
using Mardre.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mardre.Controllers
{
    public class ProcessamentoController
    {
        [HttpGet("/api/processamento")]
        public static IResult GetAll(HttpContext http)
        {
            try
            {
                var context = new EngenhariasSenacContext();
                var dal = new DAL<Processamento>(context);
                return Results.Ok(dal.Select());
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao buscar processamentos: " + ex.Message);
            }
        }

        [HttpGet("/api/processamento/{id}")]
        public static IResult GetById(int id, HttpContext http)
        {
            try
            {
                var context = new EngenhariasSenacContext();
                var dal = new DAL<Processamento>(context);
                var item = dal.SelectWhere(e => e.CodProcessamento == id);

                if (item == null)
                    return Results.NotFound(new { message = $"Processamento com ID {id} não encontrado" });

                return Results.Ok(item);
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao buscar processamento: " + ex.Message);
            }
        }

        [HttpPost("/api/processamento")]
        public static IResult Create(CreateProcessamentoDto dto, HttpContext http)
        {
            try
            {
                var item = new Processamento
                {
                    DataEntrada = dto.DataEntrada,
                    DataSaida = dto.DataSaida,
                    CodMateria = dto.CodMateria,
                    Peso = dto.Peso,
                    TempoLeitura = dto.TempoLeitura,
                    TempoPesagem = dto.TempoPesagem,
                    TempoClassificacao = dto.TempoClassificacao,
                    TempoRedirecionamento = dto.TempoRedirecionamento,
                    TempoTotalProcessamento = dto.TempoTotalProcessamento,
                    RegistroFotografico = dto.RegistroFotografico
                };

                var context = new EngenhariasSenacContext();
                var dal = new DAL<Processamento>(context);
                dal.Insert(item);

                return Results.Created($"/api/processamento/{item.CodProcessamento}", item);
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao criar processamento: " + ex.Message);
            }
        }

        [HttpPut("/api/processamento/{id}")]
        public static IResult Update(int id, UpdateProcessamentoDto dto, HttpContext http)
        {
            try
            {
                if (id != dto.CodProcessamento)
                    return Results.BadRequest(new { message = "ID da URL não corresponde ao ID do corpo da requisição" });

                var context = new EngenhariasSenacContext();
                var dal = new DAL<Processamento>(context);
                var item = dal.SelectWhere(e => e.CodProcessamento == id);

                if (item == null)
                    return Results.NotFound(new { message = $"Processamento com ID {id} não encontrado" });

                item.DataEntrada = dto.DataEntrada;
                item.DataSaida = dto.DataSaida;
                item.CodMateria = dto.CodMateria;
                item.Peso = dto.Peso;
                item.TempoLeitura = dto.TempoLeitura;
                item.TempoPesagem = dto.TempoPesagem;
                item.TempoClassificacao = dto.TempoClassificacao;
                item.TempoRedirecionamento = dto.TempoRedirecionamento;
                item.TempoTotalProcessamento = dto.TempoTotalProcessamento;
                item.RegistroFotografico = dto.RegistroFotografico;

                dal.Update(item);

                return Results.Ok(new { message = "Processamento atualizado com sucesso", data = item });
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao atualizar processamento: " + ex.Message);
            }
        }

        [HttpDelete("/api/processamento/{id}")]
        public static IResult Delete(int id, HttpContext http)
        {
            try
            {
                var context = new EngenhariasSenacContext();
                var dal = new DAL<Processamento>(context);
                var item = dal.SelectWhere(e => e.CodProcessamento == id);

                if (item == null)
                    return Results.NotFound(new { message = $"Processamento com ID {id} não encontrado" });

                dal.Delete(item);

                return Results.Ok(new { message = $"Processamento com ID {id} excluído com sucesso" });
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao excluir processamento: " + ex.Message);
            }
        }

        [HttpPost("/api/processamento/search")]
        public static IResult Search(SearchProcessamentoDto? dto, HttpContext http)
        {
            try
            {
                var context = new EngenhariasSenacContext();
                var dal = new DAL<Processamento>(context);

                if (dto == null || dto.CodMateria == null)
                    return Results.Ok(dal.Select());

                var result = dal.SelectWhereList(
                    e => e.CodMateria == dto.CodMateria
                );

                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.Problem("Erro ao buscar processamentos: " + ex.Message);
            }
        }
    }
}
