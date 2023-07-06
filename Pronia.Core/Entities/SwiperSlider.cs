using Pronia.Core.Interfaces;

namespace Pronia.Core.Entities;

public class SwiperSlider:IEntity
{
    public int Id { get; set; }
    public string ImagePath { get; set; } = null!;
    public string ImageDesc { get; set; } 
}
