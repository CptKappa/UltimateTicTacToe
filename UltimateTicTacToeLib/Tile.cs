using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToeLib
{
    public class Tile
    {
        private Labels label { get; set; }
        
        public Tile()
        {
            label = Labels.None;
        }

        public void ChangeLabel(Labels l)
        {
            this.label = l;
        }

        public Labels GetLabel()
        {
            return this.label;
        }
    }
}
