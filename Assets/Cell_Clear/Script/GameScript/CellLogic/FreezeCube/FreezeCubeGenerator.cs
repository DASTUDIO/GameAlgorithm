using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{
    public class FreezeCubeGenerator : MonoBehaviour
    {
        [SerializeField]                                                //算子
        static int multiplyOperator = 1;
        
        static List<cellContainer> cellsList;


        //public static bool genRandomFreezeCube(int cubeCount)
        //{
        //    cellsList = GameManager.getWholeCellList();

        //    int GenTimes = multiplyOperator * cubeCount; 

        //    int t
        
        //    return false;

        //}
        
        //why aways one cube?



        public static void genRandomFreezeCube(int cubeCount,int FreezeTimes)
        {
            cellsList = GameManager.getWholeCellList();

            int genTimes = multiplyOperator * cubeCount;

            //Debug.Log(genTimes  + "times");


            int tempPosition = -1;

            cellContainer tempCell = new cellContainer();

            Resource r = Resource.getResource();


            int tempRaw = -1;

            int tempColumn = -1;

            
            #region 起点随机偏移

            int startOffset = Random.Range(0, 3);

            #endregion


            for (int i = 1; i <= genTimes; i++)
            {
                #region  for tempPosition

                int j = i + startOffset;

                tempRaw = cellInfo.CellSetsHeigh - (j / cellInfo.CellSetsWidth ) - 1;

                tempColumn = j % cellInfo.CellSetsWidth;

                tempPosition = (tempRaw * cellInfo.CellSetsWidth + tempColumn) - 1 ;           //-1 for index

                #endregion

                int randomCubeType = Random.Range(1, 4);
                
                    switch (randomCubeType)
                    {
                        case 1:

                            cellsList[tempPosition].setCellInfo(cellInfo.RedNormalFreezed);

                            cellsList[tempPosition].setSprite(
                                r.getCurrentTheme().getShapeSprite(cellInfo.CELL_COLOR.RED, cellInfo.CELL_TYPE.Freeze)
                                );

                            //setFreezeTime
                            cellsList[tempPosition].setFreezeTime(FreezeTimes);


                        break;


                    case 2:

                            cellsList[tempPosition].setCellInfo(cellInfo.YellowNormalFreezed);

                            cellsList[tempPosition].setSprite(
                                r.getCurrentTheme().getShapeSprite(cellInfo.CELL_COLOR.YELLOW, cellInfo.CELL_TYPE.Freeze)
                                );

                            //setFreezeTime
                            cellsList[tempPosition].setFreezeTime(FreezeTimes);

                        break;

                    case 3:

                            cellsList[tempPosition].setCellInfo(cellInfo.GreenNormalFreezed);

                            cellsList[tempPosition].setSprite(
                                r.getCurrentTheme().getShapeSprite(cellInfo.CELL_COLOR.GREEN, cellInfo.CELL_TYPE.Freeze)
                                );

                            //setFreezeTime
                            cellsList[tempPosition].setFreezeTime(FreezeTimes);

                        break;

                    case 4:

                            cellsList[tempPosition].setCellInfo(cellInfo.BlueNormalFreezed);

                            cellsList[tempPosition].setSprite(
                                r.getCurrentTheme().getShapeSprite(cellInfo.CELL_COLOR.BLUE, cellInfo.CELL_TYPE.Freeze)
                                );

                            //setFreezeTime
                            cellsList[tempPosition].setFreezeTime(FreezeTimes);

                        break;

                    }
            }

        }



    }
}