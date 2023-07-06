using Pronia.Core.Interfaces;

namespace Pronia.Core.Entities;

public class Users:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Occupation { get; set; }
    public  string ImagePath { get; set; }
    public string Comment { get; set; }
}
