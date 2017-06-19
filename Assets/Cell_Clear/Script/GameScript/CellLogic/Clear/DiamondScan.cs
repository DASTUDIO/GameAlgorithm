using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{
    public class DiamondScan : MonoBehaviour
    {

        public static void doSpecialScan()
        {
            List<cellContainer> cellsList = GameManager.getWholeCellList();

            for (int raw = 1; raw <= cellInfo.CellSetsHeigh;raw++)
            {
                for (int column = (raw - 1) * cellInfo.CellSetsWidth + 1; column <= raw * cellInfo.CellSetsWidth; column++)
                {
                    if (cellsList[column-1].getType() == cellInfo.CELL_TYPE.Super && !cellsList[column - 1].getIsAirCube()) //同时不在空中
                    {
                        if (column <= cellInfo.CellSetsWidth)  //第一行的情况                                                                                //第一排
                        {
                            if (column == 1)                                //最左边的情况                                                                        //最左边
                            {
                                if (cellsList[(column - 1) + 1].getType() != cellInfo.CELL_TYPE.None) //最左边如果右边不是空                                      //最左右边不是空
                                {
                                    detectRight(cellsList[column - 1]);     //消除右边
                                    cellsList[column - 1].setWillClear(true);    //消除钻石本身
                                }
                                else                                                                                                                               //最左右边是空
                                {                                            //最左边且右边是空的情况
                                    detectUp(cellsList[column - 1]);         //消除上面
                                    cellsList[column - 1].setWillClear(true);
                                }
                            }
                            else if (column % cellInfo.CellSetsWidth == 0)                                                                                         //最右边
                            {                                               //最右的情况
                                if (cellsList[(column - 1) - 1].getType() == cellInfo.CELL_TYPE.None)                                                              //最右左边是空
                                {                                           //左边是空
                                    detectUp(cellsList[column - 1]);
                                    cellsList[column - 1].setWillClear(true);
                                }
                                else                                                                                                                                //最右 左边不空
                                {                                           //左边不是空
                                    detectLeft(cellsList[column - 1]);                                      //消左边
                                    cellsList[column - 1].setWillClear(true);
                                }
                            }
                            else                                                                                                                                    //不在最左也不再最右
                            {   //不在最左边 也不在最右边
                                if (cellsList[(column - 1) - 1].getType() == cellInfo.CELL_TYPE.None)       //左边是空的情况
                                {
                                    if (cellsList[(column - 1) + 1].getType() == cellInfo.CELL_TYPE.None)   //左右都是空
                                    {
                                        detectUp(cellsList[(column - 1)]);                                  //消除上面
                                        cellsList[column - 1].setWillClear(true);
                                    }
                                    else
                                    {                                                                       //右边不空
                                        detectRight(cellsList[(column - 1)]);                               //消除右边
                                        cellsList[column - 1].setWillClear(true);
                                    }
                                }
                                else
                                {                                                                           //左边不是空的
                                    detectLeft(cellsList[column - 1]);                                      //消左边
                                    cellsList[column - 1].setWillClear(true);
                                }
                            }
                        }
                        else
                        {                                                   //不是第一行的情况
                            detectDown(cellsList[column - 1]);
                            cellsList[column - 1].setWillClear(true);
                        }
                    }
                }
            }
        }


        static void detectUp(cellContainer cell)
        {
            List<cellContainer> cellsList = GameManager.getWholeCellList();

            cellInfo.CELL_COLOR targetColor =
                cellsList[(cell.id - 1) + cellInfo.CellSetsWidth].getColor();

            clearAllColor(targetColor);

        }


        static void detectDown(cellContainer cell)
        {
            List<cellContainer> cellsList = GameManager.getWholeCellList();

            cellInfo.CELL_COLOR targetColor = 
                cellsList[(cell.id - 1) - cellInfo.CellSetsWidth].getColor();

            clearAllColor(targetColor);

        }


        static void detectLeft(cellContainer cell)
        {
            List<cellContainer> cellsList = GameManager.getWholeCellList();

            cellInfo.CELL_COLOR targetColor =
                cellsList[(cell.id - 1) - 1].getColor();

            clearAllColor(targetColor);
        }

        static void detectRight(cellContainer cell)
        {
            List<cellContainer> cellsList = GameManager.getWholeCellList();

            cellInfo.CELL_COLOR targetColor =
                cellsList[(cell.id - 1) + 1].getColor();

            clearAllColor(targetColor);
        }



        static void clearAllColor(cellInfo.CELL_COLOR color)
        {
            List<cellContainer> cellsList = GameManager.getWholeCellList();

            for(int index = 0; index<cellsList.Count; index++)
            {
                if (cellsList[index].getColor() == color)
                {
                    cellsList[index].setWillClear(true);
                }
            }
            CleanScan.doCleanScan();

            if (Time.time > nextTime)
            {
                //MainGameInitialize.getNetWorkCompoent().sendScore((int)GameInfo.getDeltaCubeScore());
                Debug.Log("Alreally send socre: " + (int)GameInfo.getDeltaCubeScore());
                GameInfo.resetCubeScore();

                //nextTime = Time.time + MainGameInitialize.freezeMinTime;
            }


        }


        static float nextTime = 0f;


    }
}