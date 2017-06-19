using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 重力不受canMove影响
/// </summary>

namespace DA.STUDIO
{
    public class additionalDrop : MonoBehaviour
    {

        //static List<cellContainer> cellsList = GameManager.getWholeCellList();

        public static bool freezeDrop = false;

        public void doAdditionalDropOneStep()
        {

            List<cellContainer> cellsList = GameManager.getWholeCellList();

            int width = cellInfo.CellSetsWidth;

            for (int index = 0; index < cellsList.Count; index++)
            {
                cellContainer cell = cellsList[index];

                //doSetCanMove
                setCanMoveSmart(cell);


                //从最底下向上依次移动与判断 所以检测到上一个时下方已经被一下去的 所以一定是NONE 除非全部到底
                if (index >= width)
                {
                    if (!cell.getIsCombineAnchor())
                    {

                        if (couldMove(cell))
                        {
                            cellTranslator.downMove(cell);
                        }
                    }

                    else if (cell.getIsCombineAnchor())
                    {   
                                                                                                                      //就移动其全部HideInBig块
                                cellContainer upCell = cellsList[index + width];
                                cellContainer rightCell = cellsList[(cell.id-1) + 1];
                                cellContainer upRightCell = cellsList[index + 1 + width];

                                if( couldMove(cell)&&
                                    unSafeCouldMove(rightCell)                //cell 和其右边同时为空才可以
                                   )
                                {
                                    //Debug.Log("Enter additionalDrop's BigCubeDrop");
                                    BigCubeTransfer.BigCubeAnchorDownMove(cell);
                                    
                                }
                    }

                    
                    
                } 
            } 
        }


        static bool couldMove(cellContainer cell)                    //检测单块是否可以移动
        {
            List<cellContainer> cellsList = GameManager.getWholeCellList();

            if ((cell.getType() != cellInfo.CELL_TYPE.None) &&              //不检测空块
                 cell.getType() != cellInfo.CELL_TYPE.HideInBig &&          //不检测隐藏块
                 !cell.getIsAirCube()                                       //不检测悬浮块
               )
            {                                                               //下面是空
                if (cellsList[(cell.id - 1) - cellInfo.CellSetsWidth].getType() == cellInfo.CELL_TYPE.None)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        //专门监测HideInBig块的
        static bool unSafeCouldMove(cellContainer cell)                    //这个是专门检测Hide块的
        {
            List<cellContainer> cellsList = GameManager.getWholeCellList();

            if ((cell.getType() != cellInfo.CELL_TYPE.None) &&              //不检测空块
                 cell.getType() == cellInfo.CELL_TYPE.HideInBig &&
                !cell.getIsAirCube()                                       //不检测悬浮Air块
               )
            {                                                               //下面是空
                if (cellsList[(cell.id - 1) - cellInfo.CellSetsWidth].getType() == cellInfo.CELL_TYPE.None)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        static void setCanMoveSmart(cellContainer cell)
        {
            List<cellContainer> cellsList = GameManager.getWholeCellList();

            if (cell.id > cellInfo.CellSetsWidth)
            {
                if (!cell.getIsAirCube() &&                                                                             //不设置悬浮Air块 只要不是空 
                    cell.getType() != cellInfo.CELL_TYPE.None)
                {

                    if (!cellsList[(cell.id - 1) - cellInfo.CellSetsWidth].getCanMove())                                 //只要下面有东西 一律setTure
                    {
                        cell.setCanMove(false);
                        //Debug.Log("set " + cell.id + "'s cube CANMOVE false");
                    }
                    else
                    {
                        cell.setCanMove(true);                                                                               //否则一律setFalse
                        //Debug.Log("set " + cell.id + "'s cube CANMOVE true");
                    }

                }
            }
            else
            {
                cell.setCanMove(false);                                                                                     //最下面一排自动为true
            }



        }


        #region Timmer Stuff

        float nextTime = 0;

        public float timeInterval = 0.05f;

        void Update()
        {
            if (Time.time > nextTime)
            {
                if (!freezeDrop)
                {
                    doAdditionalDropOneStep();
                }

                nextTime = Time.time + timeInterval;

            }
        }



        #endregion

        
    }

}