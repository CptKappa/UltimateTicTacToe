using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToeLib
{
    public class Tile
    {
        public Labels Label { get; private set; }
        public (int, int) Position { get; set; }
        
        public Tile(int x, int y)
        {
            this.Label = Labels.None;
            this.Position = (x, y);
        }

        public bool Set(Labels Label)
        {
            // tile occupied?
            if (this.Label == Labels.None)
            {
                this.Label = Label;
                return true;
            }

            return false;
        }
    }
}
