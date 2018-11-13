using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToeLib
{
    public class GameMaster
    {
        public Playground gameField { get; set; }

        public Labels currentPlayer { get; set; }

        public GameMaster()
        {
            this.gameField = new Playground();
            this.currentPlayer = Labels.X;
        }


    }
}
