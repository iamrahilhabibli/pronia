using Pronia.Core.Interfaces;

namespace Pronia.Core.Entities;

public class NewProducts : IEntity
{
	public int Id { get; set; }
    public string MainImagePath { get; set; } = null!;
    public string SecondaryImagePath { get; set; }
    public string Name { get; set; }=null!;
    public decimal Price { get; set; }
    public int Rate { get; set; }
}
