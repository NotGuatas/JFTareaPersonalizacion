using Microsoft.EntityFrameworkCore;
using JFApi.Data;
using JFTareaPersonalizacion.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace JFApi.Controllers;

public static class JFsuplementosEndpoints
{
    public static void MapJFsuplementosEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/JFsuplementos").WithTags(nameof(JFsuplementos));

        group.MapGet("/", async (JFApiContext db) =>
        {
            return await db.JFsuplementos.ToListAsync();
        })
        .WithName("GetAllJFsuplementos")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<JFsuplementos>, NotFound>> (int id, JFApiContext db) =>
        {
            return await db.JFsuplementos.AsNoTracking()
                .FirstOrDefaultAsync(model => model.ID == id)
                is JFsuplementos model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetJFsuplementosById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, JFsuplementos jFsuplementos, JFApiContext db) =>
        {
            var affected = await db.JFsuplementos
                .Where(model => model.ID == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.ID, jFsuplementos.ID)
                    .SetProperty(m => m.Nombre, jFsuplementos.Nombre)
                    .SetProperty(m => m.Whey, jFsuplementos.Whey)
                    .SetProperty(m => m.Cafeina, jFsuplementos.Cafeina)
                    .SetProperty(m => m.Precio, jFsuplementos.Precio)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateJFsuplementos")
        .WithOpenApi();

        group.MapPost("/", async (JFsuplementos jFsuplementos, JFApiContext db) =>
        {
            db.JFsuplementos.Add(jFsuplementos);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/JFsuplementos/{jFsuplementos.ID}",jFsuplementos);
        })
        .WithName("CreateJFsuplementos")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, JFApiContext db) =>
        {
            var affected = await db.JFsuplementos
                .Where(model => model.ID == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteJFsuplementos")
        .WithOpenApi();
    }
}
