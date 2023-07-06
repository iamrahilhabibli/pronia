using Pronia.Core.Entities;
using Pronia.UI.Services.Interfaces;

namespace Pronia.UI.Services
{
    public class PersonService : IPersonService
    {
        public string Name { get ; set ; }

        public Person Greet()
        {
            return new Person { Name = "Rahil" };
        }
    }
}
