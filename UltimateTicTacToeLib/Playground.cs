using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToeLib
{
    public class Playground
    {
        public Field[,] field { get; set; }

        public Playground()
        {
            field = new Field[3, 3];
        }

    }
}
