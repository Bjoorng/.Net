﻿namespace Store.Domain.Models;

public class Store
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
}