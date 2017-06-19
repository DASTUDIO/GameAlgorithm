using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{
    public class BigCubeDetector : MonoBehaviour
    {
        public static void doDetectBigCube(cellContainer cell)
        {
            List<cellContainer> cellsList = GameManager.getWholeCellList();
            
            //cell[xy] 2x2
            cellContainer cell00 = cell;
            cellContainer cell10 = cellsList[(cell.id - 1) + 1];
            cellContainer cell01 = cellsList[(cell.id - 1) + cellInfo.CellSetsWidth];
            cellContainer cell11 = cellsList[(cell.id - 1) + cellInfo.CellSetsWidth + 1];

            ////2x3 
            //cellContainer cell02 = cellsList[(cell.id - 1) + 2 * cellInfo.getCellInfo().CellSetsWidth];
            //cellContainer cell12 = cellsList[(cell.id - 1) + 2 * cellInfo.getCellInfo().CellSetsWidth + 1];

            ////3x3
            //cellContainer cell20 = cellsList[(cell.id - 1) + 2];
            //cellContainer cell21 = cellsList[(cell.id - 1) + cellInfo.getCellInfo().CellSetsWidth + 2];
            //cellContainer cell22 = cellsList[(cell.id - 1) + 2 * cellInfo.getCellInfo().CellSetsWidth + 2];

            ////


            //先判断颜色是否相等
            if (cell00.getColor() == cell10.getColor() &&
                cell.getColor() == cell01.getColor() &&
                cell.getColor() == cell11.getColor()

                &&

                //再判断是否全部为Normal
                cell00.getType() == cell10.getType() &&
                cell00.getType() == cell01.getType() &&
                cell00.getType() == cell11.getType() &&
                cell00.getType() == cellInfo.CELL_TYPE.Normal)
            {

                BigCubeTransfer.doTranformToBig(cell);

            }

        }



    }


}