using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MinimalAPIDemoWithCrudDbContext;

using MinimalAPIDemoWithCrudModels;

using MinimalAPIDemoWithCrudServices;
using MinimalAPIDemoWithCrudServices.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IMinimalAPIDemoWithCrudRepo, MinimalAPIDemoWithCrudRepo>();

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(@"Server=localhost\\SQLEXPRESS;Database=MinimalAPIDemoWithCrudDB;Trusted_Connection=True;");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/stores", ([FromServices] IMinimalAPIDemoWithCrudRepo repo) =>
{
    return Results.Ok(repo.GetAllStores());
})
.WithName("Get All Stores");


app.MapGet("/stores/{storeNumber}", ([FromServices] IMinimalAPIDemoWithCrudRepo repo, int storeNumber) =>
{
    return Results.Ok(repo.GetStoreInformationByStoreNumber(storeNumber));
})
.WithName("Get All Stores by Store Number");

app.MapPost("/stores", ([FromServices] IMinimalAPIDemoWithCrudRepo repo, StoreInformation newStore) =>
{
    repo.InsertNewStoreInformation(newStore);
    return Results.Created($"/getallstores/{newStore.StoreNumber}", newStore);

}).WithName("Insert Store");

app.MapPut("/stores/{storeNumber}", ([FromServices] IMinimalAPIDemoWithCrudRepo repo, StoreInformation updateStore, int storeNumber) =>
{
    repo.UpdateStoreInformation(updateStore);
    return Results.Ok(updateStore);

}).WithName("Update Store");

app.Run();

