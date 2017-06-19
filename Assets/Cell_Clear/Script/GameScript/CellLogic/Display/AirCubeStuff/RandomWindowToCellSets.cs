using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{
    public class RandomWindowToCellSets : MonoBehaviour
    {
        public static void doRandomWindowToCellSet()
        {
            //Initialize
            int height = cellInfo.CellSetsHeigh;
            int width = cellInfo.CellSetsWidth;

            List<cellContainer> list = cellInfo.getCellInfo().cellWholeSet;
            randomWindowDisplayer rwd = GameManager.getRandomWindowDisplayer();
            
            //确定最顶上 中间的方块 && 确定第二行 中间的方块
            cellContainer upCell = list[(height - 1) * width + (int)(0.5 * (width + 1))];
            cellContainer downCell = list[(height - 1 - 1) * width + (int)(0.5 * (width + 1))];
            
            //移动到场景中
            if (rwd != null)
            {
                if (rwd.upRandomCell != null && rwd.downRandomCell != null)
                {
                    cellTranslator.translateCellInfoAtoB
                        (rwd.upRandomCell, upCell);

                    cellTranslator.translateCellInfoAtoB
                        (rwd.downRandomCell, downCell);
                    
                    //写入缓冲区
                    GameController.getResource().getAirCubeBuffer().setCell_A(upCell);
                    GameController.getResource().getAirCubeBuffer().setCell_B(downCell);
                    GameController.getResource().getAirCubeBuffer().getCell_A().setIsAirCube(true);
                    GameController.getResource().getAirCubeBuffer().getCell_B().setIsAirCube(true);
                    
                    //重置context 的 AirCube State 为 默认的 A_POSITION
                    GameManager.setCurrentAirState(new A_Block_State());

                    //产生新Random Cube
                    rwd.doDisplayRandomsCube();

                }
            }
        }
    }
}