using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// static 静态工具类 不挂载
/// </summary>

namespace DA.STUDIO
{


    public class cellTranslator
    {

        List<cellContainer> listTemp;

        public static void translateCellInfoAtoB(cellContainer a, cellContainer b)
        {
            
            b.setCellInfo(a.getCellPropety());
            b.setSprite(a.getSprite());

            if (a.id != b.id)
            {
                a.setCellInfo(cellInfo.noneInfo);
                a.setSprite(null);
            }
            
        }


        public static void exchangeAB(cellContainer a,cellContainer b)
        {
            cellContainer tempCell = new cellContainer();

            Sprite tempSprite;

            tempCell.setCellInfo(a.getCellPropety());
            tempSprite = a.getSprite();

            a.setCellInfo(b.getCellPropety());
            a.setSprite(b.getSprite());

            b.setCellInfo(tempCell.getCellPropety());
            b.setSprite(tempSprite);

        }

        public static int downMove(cellContainer a)              //下方移动 实际是这个块内容上的移动 这块本身不动
        {

            int index_A = -1;                                 //减一是为了列表索引是从0开始 而我们ID是从1开始的
            int index_B = -1;

            index_A = a.id - 1;
            index_B = index_A - cellInfo.CellSetsWidth;

            List<cellContainer> listTemp = GameManager.getWholeCellList();

            cellContainer b = listTemp[index_B];

            translateCellInfoAtoB(a, b);

            return index_B;

        }

        public static int leftMove(cellContainer a)              //左移动 返回新id
        {
            int index_A = a.id - 1;
            int index_B = a.id - 1 - 1;                           //因为这是从左向右一行一行排列递增的

            List<cellContainer> listTemp = GameManager.getWholeCellList();

            cellContainer b = listTemp[index_B];

            translateCellInfoAtoB(a, b);

            return index_B;

        }

        public static int rightMove(cellContainer a)             //右移动
        {

            int index_A = a.id - 1;
            int index_B = a.id - 1 + 1;

            List<cellContainer> listTemp = GameManager.getWholeCellList();

            cellContainer b = listTemp[index_B];

            translateCellInfoAtoB(a, b);

            return index_B;

        }


        //实现移动主要逻辑
        public static int safeMove(cellContainer cell, cellInfo.MOVE_DIRECTION direction)
        {
            if (cell.getCanMove())
            {
                switch (direction)
                {
                    case cellInfo.MOVE_DIRECTION.DOWN:

                        return cellTranslator.downMove(cell);


                    case cellInfo.MOVE_DIRECTION.LEFT:

                        return cellTranslator.leftMove(cell);


                    case cellInfo.MOVE_DIRECTION.RIGHT:

                        return cellTranslator.rightMove(cell);                           //调用cellTranslator移动

                }
            }
            return (cell.id - 1);                                                             //如果没移动 返回它本身的索引
        }


    }
}