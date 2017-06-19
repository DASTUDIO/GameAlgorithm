using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DA.STUDIO
{

    public class CombineScan : MonoBehaviour
    {
        static float cubeSize = 110;
        static float padding = 10;

        public static void doCombineScan()
        {
            List<cellContainer> cellsList = GameManager.getWholeCellList();
            
            int width = cellInfo.CellSetsWidth;

            int height = cellInfo.CellSetsHeigh;
            
            //检测 不检测最右边一行 最高一列 省得判断里去分辨它
            for (int raw = 1; raw <= (height - 1); raw++)
            {
                for (int column = (raw - 1) * width + 1; column <= raw * width - 1; column++)
                {
                    BigCubeDetector.doDetectBigCube(cellsList[column - 1]);
                }
            }


        }
    }
}