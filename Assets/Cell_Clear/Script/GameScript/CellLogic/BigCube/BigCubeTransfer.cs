using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DA.STUDIO
{

    public class BigCubeTransfer : MonoBehaviour
    {
        
        static Vector2 BigCubeSize = new Vector2(320f, 320f);
        static Vector2 NormalCubeSize = new Vector2(150f, 150f);

        public static void doTranformToBig(cellContainer cell)
        {

            List<cellContainer> cellsList = GameManager.getWholeCellList();

            //cell[xy] 
            cellContainer cell00 = cell;
            cellContainer cell10 = cellsList[(cell.id - 1) + 1];
            cellContainer cell01 = cellsList[(cell.id - 1) + cellInfo.CellSetsWidth];
            cellContainer cell11 = cellsList[(cell.id - 1) + cellInfo.CellSetsWidth + 1];

            //doTransform
            //依然使用颜色来检测 消除也是如此 否则大方块两边的方块连不上
            cell.setIsCombineAnchor(true);
            cell00.gameObject.GetComponent<RectTransform>().sizeDelta = BigCubeSize;

            cell10.setSprite(null);
            cell10.setCellInfo(cellInfo.HideInBig);
            cell10.setColor(cell00.getColor());

            cell01.setSprite(null);
            cell01.setCellInfo(cellInfo.HideInBig);
            cell01.setColor(cell00.getColor());

            cell11.setSprite(null);
            cell11.setCellInfo(cellInfo.HideInBig);
            cell11.setColor(cell00.getColor());


        }


        public static void reverseTransformFromBig(cellContainer cell)
        {

            List<cellContainer> cellsList = GameManager.getWholeCellList();

            cellContainer cell00 = cell;
            cellContainer cell10 = cellsList[(cell.id - 1) + 1];
            cellContainer cell01 = cellsList[(cell.id - 1) + cellInfo.CellSetsHeigh];
            cellContainer cell11 = cellsList[(cell.id - 1) + cellInfo.CellSetsWidth + 1];


            cell00.gameObject.GetComponent<RectTransform>().sizeDelta = NormalCubeSize;
            cell.setIsCombineAnchor(false);


            cell10.setCellInfo(cellInfo.noneInfo);
            cell10.setSprite(null);
            cell01.setCellInfo(cellInfo.noneInfo);
            cell01.setSprite(null);
            cell11.setCellInfo(cellInfo.noneInfo);
            cell11.setSprite(null);

        }


        public static void BigCubeAnchorDownMove(cellContainer cell)
        {

            if (cell.getIsCombineAnchor())
            {
                List<cellContainer> cellsList = GameManager.getWholeCellList();

                Vector2 cubeSize = cell.gameObject.GetComponent<RectTransform>().sizeDelta;


                cellContainer downCell = cellsList[(cell.id - 1) - cellInfo.CellSetsWidth];

                Debug.Log("Enter BigCubeTransfer's BigCubeDownMove");

                downCell.gameObject.GetComponent<RectTransform>().sizeDelta = cubeSize;
                downCell.setCellInfo(cell.getCellPropety());
                downCell.setSprite(cell.getSprite());
                downCell.setIsCombineAnchor(true);

                cell.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 110);
                cell.setCellInfo(cellInfo.noneInfo);
                cell.setSprite(null);
                cell.setIsCombineAnchor(false);


                cellContainer rightCell = cellsList[(cell.id - 1) + 1];
                cellContainer upCell = cellsList[(cell.id - 1) + cellInfo.CellSetsWidth];
                cellContainer upRightCell = cellsList[(cell.id - 1) + cellInfo.CellSetsWidth + 1];


                cellTranslator.downMove(rightCell);
                cellTranslator.downMove(upCell);
                cellTranslator.downMove(upRightCell);

            }

        }


        //public static void BigCubeDownMoveDebug(cellContainer cell)
        //{
        //    if (cell)
        //    {

        //        List<cellContainer> cellslist = GameManager.getWholeCellList();

        //        Vector2 cubeSize = cell.gameObject.GetComponent<RectTransform>().sizeDelta;

        //        cellContainer downCell = cellslist[(cell.id - 1) - cellInfo.CellSetsWidth];



        //    }
        //}


    }
}