// See https://aka.ms/new-console-template for more information
using Northwind.EntityModels; // To use Northwind.
using NorthwindDb db = new();
WriteLine($"Provider: {db.Database.ProviderName}");
