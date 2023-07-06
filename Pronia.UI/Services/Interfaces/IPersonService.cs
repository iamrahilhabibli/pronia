using Pronia.Core.Entities;

namespace Pronia.UI.Services.Interfaces
{
    public interface IPersonService 
    {
        public string Name { get; set; }
        public Person Greet();
    }
}
