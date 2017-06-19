using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// 这里Column为id 真正索引要 -1
/// 
/// </summary>

namespace DA.STUDIO
{
    public class PreScan : MonoBehaviour
    {
        [SerializeField]
        GameObject TaskQuene;
        
        public static void doPreScan()
        {
            List<cellContainer> cellsList = GameManager.getWholeCellList();

            for (int raw = 1; raw <= cellInfo.CellSetsHeigh; raw++)
            {
                for (int column = (raw - 1) * cellInfo.CellSetsWidth + 1; 
                    column <= raw * cellInfo.CellSetsWidth; 
                    column++)
                {
                    detectCell(cellsList[column-1]);                    //id是为了方便找方块 只有-1 才是真正的索引
                }
            }
            prepareBeDigged();
            SpecialScan.doSpecialScan();
            CombineScan.doCombineScan();
        }

        static void detectCell(cellContainer cell)
        {
            if (cell.getType() != cellInfo.CELL_TYPE.None && !cell.getIsAirCube())              //避免检测和写入空cell 与 AirCell
            {
                List<cellContainer> cellsList = GameManager.getWholeCellList();

                if (cell.id % cellInfo.CellSetsWidth != 0)
                {
                    if (cell.getColor() == cellsList[(cell.id - 1) + 1].getColor())
                    {
                        cell.horizontalSets.Add(cellsList[(cell.id - 1) + 1]);
                        
                    }
                }

                if (cell.id % cellInfo.CellSetsWidth != 1)
                {
                    if (cell.getColor() == cellsList[(cell.id - 1) - 1].getColor())
                    {
                        cell.horizontalSets.Add(cellsList[(cell.id - 1) - 1]);
                        
                    }
                }

                if (cell.id > cellInfo.CellSetsWidth)
                {
                    if (cell.getColor() == cellsList[(cell.id - 1 - cellInfo.CellSetsWidth)].getColor())
                    {
                        cell.verticalSets.Add(cellsList[((cell.id - 1) - cellInfo.CellSetsWidth)]);
                        
                    }

                    if (cell.id < (cellInfo.CellSetsHeigh * cellInfo.CellSetsWidth) &&
                        cell.getColor() == cellsList[(cell.id - 1) + cellInfo.CellSetsWidth].getColor()) 
                    {
                        cell.verticalSets.Add(cellsList[((cell.id - 1) + cellInfo.CellSetsWidth)]);
                        
                    }

                }

                if (cell.id < (cellInfo.CellSetsHeigh))
                {
                    if (cell.getColor() == cellsList[(cell.id - 1 + cellInfo.CellSetsWidth)].getColor())
                    {
                        cell.verticalSets.Add(cellsList[(cell.id - 1) + cellInfo.CellSetsWidth]);
                       
                    }
                }

            }
        }

        static void prepareBeDigged()
        {
            List<cellContainer> cellsList = GameManager.getWholeCellList();

            for (int raw = 1; raw <= cellInfo.CellSetsHeigh; raw++)
            {
                for (int column = (raw - 1) * cellInfo.CellSetsWidth + 1; 
                    column <= raw * cellInfo.CellSetsWidth; 
                    column++)
                {
                    cellsList[column - 1].setBeDigged(false);
                    //Debug.Log(column + "setBeDiggedFlag" + cellsList[column - 1].getBeDigged());
                }
            }
        }

        public static void doDelayPreScan()
        {
            GameObject.FindGameObjectWithTag("taskQuene")
                .GetComponent<taskQuene>().executeDelayClearScan();
        }
        
        public static void doDelayPreScanDebug()
        {
            List<cellContainer> list = GameManager.getWholeCellList();

            for (int raw = 1; raw <= cellInfo.CellSetsHeigh; raw++)
            {
                for (int column = (raw - 1) * cellInfo.CellSetsWidth + 1;
                    column <= raw * cellInfo.CellSetsWidth;
                    column++)
                {
                    list[column - 1].setBeDigged(false);
                }
            }

            GameObject.FindGameObjectWithTag("taskQuene")
                .GetComponent<taskQuene>().executeDelayClearScan();
            
        }
    }
}