using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{
    public class FreezeScan : MonoBehaviour
    {
        //这个函数在 OnTouch 中独立触发

        public static void doFreezeScan()
        {
            List<cellContainer> cellsList = GameManager.getWholeCellList();

            int width = cellInfo.CellSetsWidth;

            int height = cellInfo.CellSetsHeigh;

            for (int raw = 1; raw <= (height - 1); raw++)
            {
                for (int column = (raw - 1) * width + 1; column <= raw * width - 1; column++)
                {
                    if (cellsList[column - 1].getIsFreeze())
                    {
                        FreezeTransfer.doTransferFreezeOneTime(cellsList[column - 1]);
                    }
                }
            }
        }
    }
}