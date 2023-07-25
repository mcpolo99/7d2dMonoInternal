using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenDTDMono.Interface
{
    public interface IListItem
    {
        string Name { get; }
    }

    public class EntityZombie : IListItem
    {
        public string Name { get; set; }
        // Other properties and methods for the EntityZombie class
    }

    public class PlayerCharacter : IListItem
    {
        public string Name { get; set; }
        // Other properties and methods for the PlayerCharacter class
    }
}
