using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamove
{
    public class Player : IPlayer
    { 
        public string Name { get; set; }
        public string Position { get; set; }

        public Player(string name, string position)
        {
            this.Name = name;
            this.Position = position;
        }
    }
}
