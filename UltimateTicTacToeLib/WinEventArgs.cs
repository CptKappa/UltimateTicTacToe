using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToeLib
{
    public class WinEventArgs
    {
        public Labels Winner { get; private set; }
        public IField playground { get; private set; }
        public (int, int) WinningMove { get; set; }

        public WinEventArgs(Labels Winner, IField playground, (int, int) WinningMove)
        {
            this.Winner = Winner;
            this.playground = playground;
            this.WinningMove = WinningMove;
        }
    }
}
