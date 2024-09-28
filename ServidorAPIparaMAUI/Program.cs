using Microsoft.EntityFrameworkCore;
using ServidorAPIparaMAUI.Contenido;
using ServidorAPIparaMAUI.Models;

var builder = WebApplication.CreateBuilder(args);

// Corregir la referencia de la cadena de conexión: debes pasar el nombre como string
builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlite(builder.Configuration.GetConnectionString("MiConexionLocalSQLite")));

// Construir la aplicación
//creacion del expoint
var app = builder.Build();
app.MapGet("api/plato",async(AppDbContext contexto) => {
    var elementos = await contexto.Platos.ToListAsync();
    //rerotnar como json
    return Results.Ok(elementos);
});
//--
app.MapPost("api/plato", async (AppDbContext contexto, Plato plato) => {
    //Agregando
    var elementos = await contexto.Platos.AddAsync(plato);
    await contexto.SaveChangesAsync();//funcion asincrona
    return Results.Created($"api/plato/{plato.Id}", plato);//genera una respuesta http 201, URI y Objeto
    
});
//Modificar
app.MapPut("api/plato/{identificador}", async (AppDbContext contexto,int identificador, Plato plato) => {
    //cambios
    var platoModelo = await contexto.Platos.FirstOrDefaultAsync(pl => pl.Id == identificador);
    if (platoModelo == null)
        return Results.NotFound();//http 404
    platoModelo.Nombre = plato.Nombre;
    await contexto.SaveChangesAsync();//funcion asincrona
    return Results.NoContent();//http 200, URI y Objeto

});

//delete
app.MapDelete("api/plato/{id}", async (AppDbContext contexto, int id) => {
    //Agregando
    var platoModelo = await contexto.Platos.FirstOrDefaultAsync(pl => pl.Id == id);
    if (platoModelo == null)
        return Results.NotFound();//http 404
    contexto.Platos.Remove(platoModelo);
    await contexto.SaveChangesAsync();//funcion asincrona
    return Results.NoContent();//HTTP 200, URI y Objeto

});

app.Run();