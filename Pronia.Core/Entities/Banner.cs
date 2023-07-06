using Pronia.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Core.Entities;

public class Banners : IEntity
{
	public int Id { get; set; }
	[Required]
	public string Title { get; set; } = null!;
	[Required]	
	public string Collection { get; set; } = null!;
    public string ImagePath { get; set; }
}
