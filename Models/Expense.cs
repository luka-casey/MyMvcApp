using System;
using System.ComponentModel.DataAnnotations;

namespace MyMvcApp.Models;

public class Expense
{
    public int Id { get; set; }
    public decimal Value { get; set; }
    [Required] //Investigate required 
    public string? Description { get; set; }
}
