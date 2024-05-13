using AutoMapper;
using Microsoft.Identity.Client;
using Storage.Domain.DTOs.ProductDTOs;
using Storage.Domain.Models;

public class OrderCreateDTO
{
    public List<ProductForOrderDTO> Products { get; set; }
}