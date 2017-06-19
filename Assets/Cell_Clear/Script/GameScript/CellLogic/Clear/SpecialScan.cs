using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{
    public class SpecialScan : MonoBehaviour
    {
        public static void doSpecialScan()
        {
            List<cellContainer> cellsList = GameManager.getWholeCellList();

            for (int raw = 1; raw <= cellInfo.CellSetsHeigh; raw++)
            {
                for (int column = (raw-1)* cellInfo.CellSetsWidth + 1; 
                    column <= raw * cellInfo.CellSetsWidth; 
                    column++ )
                {
                    //检测特殊方块
                    detectSpecialCell(cellsList[column-1]);
                }
            }
            CleanScan.doCleanScan();
            DiamondScan.doSpecialScan();
        }
        
        //检测特殊方块
        static void detectSpecialCell(cellContainer cell)
        {
            if (cell.getType() == cellInfo.CELL_TYPE.Special && !cell.getIsAirCube())
            {
                diggout(cell);
            }
        }
        
        static void diggout(cellContainer cell)
        {
            if (cell.getType() != cellInfo.CELL_TYPE.Special)
            {
                //Debug.Log("clear Normal");
                cell.setWillClear(true);
            }

            if (!cell.getBeDigged())
            {
                cell.setBeDigged(true);

                if (cell.horizontalSets.Count > 0)
                {
                    foreach (var c in cell.horizontalSets)
                    {
                        diggout(c);
                    }
                    cell.setWillClear(true);
                }
                
                if (cell.verticalSets.Count > 0)
                {
                    foreach (var c in cell.verticalSets)
                    {
                        diggout(c);
                    }
                    cell.setWillClear(true);
                }
            }
        }
        
    }
}