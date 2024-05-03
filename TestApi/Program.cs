using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();
ApplicationDbContext dbContext = new();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.MapGet("/categories/", (IMapper mapper) => dbContext.Categories.ProjectTo<CategoryListDTO>(mapper.ConfigurationProvider).ToList());

app.MapGet("/products/", (IMapper mapper) => dbContext.Products.ProjectTo<ProductListItemDTO>(mapper.ConfigurationProvider).ToList());

app.MapGet("/categories/{id}", (int id) => dbContext.Categories.Find(id));

app.MapGet("/categories/{id}/products", (int id, IMapper mapper) =>
    dbContext.Products.Where(product => product.CategoryId == id).ProjectTo<ProductListItemDTO>(mapper.ConfigurationProvider).ToList()
);

app.MapGet("/products/{id}", (int id, IMapper mapper) =>
{
    Product p = dbContext.Products.Find(id);
    if (p != null)
    {
        ProductDetailsItemDTO pDetailsDto = mapper.Map<ProductDetailsItemDTO>(p);
        return Results.Ok(pDetailsDto);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapPost("/categories/add", (IMapper mapper, CategoryCreateDTO cDto) =>
{
    Category c = mapper.Map<Category>(cDto);
    dbContext.Add(c);
    dbContext.SaveChanges();
});

app.MapPost("/products/add", (IMapper mapper, ProductCreateDTO cpd) =>
{
    ProductValidator validator = new();
    ValidationResult result = validator.Validate(cpd);
    if (!result.IsValid)
    {
        return Results.BadRequest(result.Errors);
    }
    else if (dbContext.Categories.Find(cpd.CategoryId) == null)
    {
        return Results.BadRequest("No Category In DB");
    }
    Product p = mapper.Map<Product>(cpd);
    dbContext.Add(p);
    dbContext.SaveChanges();
    return Results.Ok(p);
});

app.MapPut("/categories/update/{id}", (int id, CategoryListDTO cDto) =>
{
    Category c = dbContext.Categories.Find(id);
    if (c != null)
    {
        c.Name = cDto.Name;
        dbContext.Update(c);
        dbContext.SaveChanges();
        return Results.Ok(c);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapPut("/products/update/{id}", (int id, ProductUpdateDTO pDto) =>
{
    Product p = dbContext.Products.Find(id);
    if (p != null)
    {
        p.Name = pDto.Name;
        p.Price = pDto.Price;
        p.Description = pDto.Description;
        p.Quantity = pDto.Quantity;
        p.CategoryId = pDto.CategoryId;
        dbContext.Update(p);
        dbContext.SaveChanges();
        return Results.Ok(p);
    }
    else
    {
        return Results.NotFound();
    }

});

app.MapDelete("/categories/delete/{id}", (int id) =>
{
    Category c = dbContext.Categories.Find(id);
    dbContext.Remove(c);
    dbContext.SaveChanges();
});

app.MapDelete("/products/delete/{id}", (int id) =>
{
    Product p = dbContext.Products.Find(id);
    // List<Product> products = dbContext.Products.Where(p => p.Id > id).ToList();
    // dbContext.RemoveRange(products);
    dbContext.Products.Remove(p);
    dbContext.SaveChanges();
});

app.Run();
