using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToeLib
{
    public class Field : IField
    {
        public event WinEventHandler Win;

        private Tile[,] tiles { get; set; }
        public Labels Label { get; private set; }
        public (int, int) Position { get; set; }

        public Field(int x, int y)
        {
            this.Label = Labels.None;
            this.Position = (x, y);

            tiles = new Tile[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tiles[i, j] = new Tile(j, i);
                }
            }
        }

        protected virtual void OnWin(Labels label, int x, int y)
        {
            Win?.Invoke(this, new WinEventArgs(label, null, (x, y)));
        }

        public Labels Get(int x, int y)
        {
            return this.tiles[y, x].Label;
        }

        public bool SetTile(int x, int y, Labels label)
        {
            bool res = this.tiles[y, x].Set(label);

            if (CheckWin(x, y) != Labels.None)
            {
                Set(label);
                OnWin(label, x, y);
            }

            return res;
        }

        public bool Set(Labels Label)
        {
            // field occupied?
            if (this.Label == Labels.None)
            {
                this.Label = Label;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if someone won using the given tile
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Labels CheckWin(int x, int y)
        {
            Labels cl = Get(x, y);

            // check horizontal
            if (Get(x, 0) == cl && Get(x, 1) == cl && Get(x, 2) == cl)
            {
                return cl;
            }
            // check vertical
            else if (Get(0, y) == cl && Get(1, y) == cl && Get(2, y) == cl)
            {
                return cl;
            }

            // check diagonal
            if (Get(0, 0) == cl && Get(1, 1) == cl && Get(2, 2) == cl)
            {
                return cl;
            }
            else if (Get(2, 0) == cl && Get(1, 1) == cl && Get(0, 2) == cl)
            {
                return cl;
            }

            return Labels.None;
        }
    }
}
