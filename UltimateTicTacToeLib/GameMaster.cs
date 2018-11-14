using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToeLib
{
    public delegate void WinEventHandler(object sender, WinEventArgs e);

    public class GameMaster
    {
        public event WinEventHandler Win;

        private Playground playground { get; set; }
        public Labels CurrentPlayer { get; set; }
        public bool Running { get; set; }

        public GameMaster()
        {
            this.playground = new Playground();
            this.playground.Win += Playground_Win;

            this.CurrentPlayer = Labels.X;
            this.Running = false;
        }

        private void Playground_Win(object sender, WinEventArgs e)
        {
            this.Running = false;

            OnWin(e.WinningMove.Item1, e.WinningMove.Item2);
        }

        protected virtual void OnWin(int x, int y)
        {
            Win?.Invoke(this, new WinEventArgs(this.CurrentPlayer, this.playground, (x, y)));
        }

        public void Start()
        {
            this.Running = true;
        }

        public bool Set(int x, int y)
        {
            // valid position
            if (x < 0 || x > 8 || y < 0 || y > 8)
            {
                return false;
            }

            if (!this.playground.Set(x / 3, y / 3, x % 3, y % 3, this.CurrentPlayer))
            {
                return false;
            }

            this.CurrentPlayer = this.CurrentPlayer == Labels.X ? Labels.O : Labels.X;

            return true;
        }

        public Labels Get(int fieldX, int fieldY, int tileX, int tileY)
        {
            return this.playground.Get(fieldX, fieldY, tileX, tileY);
        }
    }
}
