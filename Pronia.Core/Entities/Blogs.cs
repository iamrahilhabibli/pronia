using Pronia.Core.Interfaces;

namespace Pronia.Core.Entities;

public class Blogs : IEntity
{
	public int Id { get; set; }
	public string Author { get; set; } = null!;
	public DateTime Date { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
}
