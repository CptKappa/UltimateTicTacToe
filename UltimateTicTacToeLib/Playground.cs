using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToeLib
{
    public class Playground : IField
    {
        public event WinEventHandler Win;

        private Field[,] fields { get; set; }

        public Playground()
        {
            fields = new Field[3, 3];

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    fields[y, x] = new Field(x, y);
                    fields[y, x].Win += Field_Win;
                }
            }
        }

        protected virtual void OnWin(Labels label, Field field, int x, int y)
        {
            Win?.Invoke(this, new WinEventArgs(label, field, (x, y)));
        }

        private void Field_Win(object sender, WinEventArgs e)
        {
            Field field = (Field)sender;
            (int x, int y) = field.Position;

            if (CheckWin(x, y) != Labels.None)
            {
                OnWin(e.Winner, field, x * 3 + e.WinningMove.Item1, y * 3 + e.WinningMove.Item2);
            }
        }

        public Labels Get(int fieldX, int fieldY, int tileX, int tileY)
        {
            return this.fields[fieldY, fieldX].Get(tileX, tileY);
        }

        public bool Set(int fieldX, int fieldY, int tileX, int tileY, Labels label)
        {
            if (this.fields[fieldY, fieldX].Label == Labels.None)
            {
                return this.fields[fieldY, fieldX].SetTile(tileX, tileY, label);
            }

            return false;
        }

        private Labels GetFieldLabel(int x, int y)
        {
            return this.fields[y, x].Label;
        }

        private Labels CheckWin(int x, int y)
        {
            Labels cl = GetFieldLabel(x, y);

            // check horizontal
            if (GetFieldLabel(x, 0) == cl && GetFieldLabel(x, 1) == cl && GetFieldLabel(x, 2) == cl)
            {
                return cl;
            }
            // check vertical
            else if (GetFieldLabel(0, y) == cl && GetFieldLabel(1, y) == cl && GetFieldLabel(2, y) == cl)
            {
                return cl;
            }

            // check diagonal
            if (GetFieldLabel(0, 0) == cl && GetFieldLabel(1, 1) == cl && GetFieldLabel(2, 2) == cl)
            {
                return cl;
            }
            else if (GetFieldLabel(2, 0) == cl && GetFieldLabel(1, 1) == cl && GetFieldLabel(0, 2) == cl)
            {
                return cl;
            }

            return Labels.None;
        }
    }
}
