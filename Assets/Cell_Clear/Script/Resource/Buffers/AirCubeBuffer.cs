using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{
    public class AirCubeBuffer
    {

        private cellContainer cell_A;

        private cellContainer cell_B;

        public cellContainer getCell_A()
        {
            return this.cell_A;
        }

        public cellContainer getCell_B()
        {
            return this.cell_B;
        }

        public void setCell_A(cellContainer cell)
        {
            this.cell_A = cell;
        }

        public void setCell_B(cellContainer cell)
        {
            this.cell_B = cell;
        }

    }
}