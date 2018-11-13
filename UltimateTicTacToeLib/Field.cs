using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToeLib
{
    public class Field
    {
        public Tile[,] tiles { get; set; }

        public Field()
        {
            tiles = new Tile[3, 3];
        }

    }
}
