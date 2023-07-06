using Pronia.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Core.Entities;

public class Product:IEntity
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    public string ImagePathMain { get; set; }
    public string ImagePathHover { get; set; }
    public int Rate { get; set; }
    [Required]
    public bool IsDeleted { get; set; }
}
