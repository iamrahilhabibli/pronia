using Pronia.Core.Entities;

namespace Pronia.UI.ViewModels;

public class HomeVM
{
	public IEnumerable<Slider> Sliders { get; set; }
	public IEnumerable<Shipping> Shippings { get; set; }
	public IEnumerable<Product> Products { get; set; }
	public IEnumerable<Banners> Banners { get; set; }
	public IEnumerable<Users> Users { get; set; }

	public IEnumerable<SwiperSlider> SwiperSlider { get; set; }

	public IEnumerable<Blogs> Blogs { get; set; }
	public IEnumerable<NewProducts> NewProducts { get; set; }
}
