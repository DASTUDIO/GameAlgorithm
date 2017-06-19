using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{
    public class A_Block_State : AbstractAirBlockState
    {
        public override void NatureDrop()
        {
            //Debug.Log("Entry NatureDrop");

            getBuffer();                                                       //get temp_Cell_A,temp_Cell_B 

            InitialCellsList();                                                //get CellsList
            
            if (temp_Cell_A != null && temp_Cell_B != null)
            {
                index_temp_A = temp_Cell_A.id - 1;                              //每次都会刷新这些索引值 所以不需要 new_Cell_Index
                index_temp_B = temp_Cell_B.id - 1;

                new_Cell_A_Index = index_temp_A - getMatrixWidth();
                new_Cell_B_Index = index_temp_B - getMatrixWidth();

                if (index_temp_A >= 0 && index_temp_B >= 0)
                {
                    #region 第一次拦截 到底或者底下有东西唤起 OnTouch 拦截 
                    //B 到底
                    if (index_temp_B < getMatrixWidth())                 //检测当前B是不是在底部一排  如果是则设置当前块为不可动 
                    {
                        OnTouchCallScanAndRandomGen();
                        return;
                    }
                    else                                                        //不在第一排的情况
                    {
                        //B 底下有东西
                        if (!getCanMove(CellsList[new_Cell_B_Index]))
                        {
                            OnTouchCallScanAndRandomGen();
                            return;
                        }
                    }
                    #endregion

                    //无拦截就移动

                    downMoveSingleCell(temp_Cell_B);
                    downMoveSingleCell(temp_Cell_A);

                    writeBuffer();

                    #region 第二次拦截 暂时未打开

                    //if (new_Cell_B_Index < getMatrixWidth())
                    //{
                    //    Debug.Log("do quick scan"+new_Cell_B_Index);
                    //    GameManager.doClearScan();

                    //}
                    //else                                                        //不在第一排的情况
                    //{
                    //    //B 底下有东西
                    //    if (!getCanMove(CellsList[new_Cell_B_Index - getMatrixWidth()]))
                    //    {
                    //        Debug.Log("DO QUICK SCAN"+new_Cell_B_Index);
                    //        GameManager.doClearScan();

                    //    }
                    //}
                    #endregion

                }
            }
        }

        public override void LeftMove()
        {
            getBuffer();

            InitialCellsList();

            if (temp_Cell_A != null && temp_Cell_B != null)     //判断只有在一定高度以下才能移动 只判断A情况即可
            {
                index_temp_A = temp_Cell_A.id - 1;
                index_temp_B = temp_Cell_B.id - 1;

                new_Cell_A_Index = index_temp_A - 1;
                new_Cell_B_Index = index_temp_B - 1;

                if (index_temp_A >= 0 && index_temp_B >= 0)
                {
                    #region 如果到达左侧边界或者左边有东西 拦截

                    //到达边界
                    if ((index_temp_A + 1) % getMatrixWidth() == 1)
                    {
                        return;
                    }
                    else
                    {   //不再边界上 则检测左侧有东西没
                        if (getCellColor(CellsList[index_temp_A - 1]) != CellNoneColor)
                        {
                            return;
                        }
                        if (getCellColor(CellsList[index_temp_B - 1]) != CellNoneColor)
                        {
                            return;
                        }
                    }
                    #endregion

                    leftMoveSingleCell(temp_Cell_A);
                    leftMoveSingleCell(temp_Cell_B);

                    writeBuffer();
                }
            }
        }

        public override void RightMove()
        {
            getBuffer();

            InitialCellsList();

            if (temp_Cell_A != null && temp_Cell_B != null)
            {
                index_temp_A = temp_Cell_A.id - 1;
                index_temp_B = temp_Cell_B.id - 1;

                new_Cell_A_Index = index_temp_A + 1;
                new_Cell_B_Index = index_temp_B + 1;

                if (index_temp_A >= 0 && index_temp_B >= 0)
                {
                    #region A如果到达右边界 或者右侧有东西

                    if ((index_temp_A + 1) % getMatrixWidth() == 0)
                    {
                        return;
                    }

                    if (getCellColor(CellsList[index_temp_A + 1]) != CellNoneColor)
                    {
                        return;
                    }

                    if (getCellColor(CellsList[index_temp_B + 1]) != CellNoneColor)
                    {
                        return;
                    }

                    #endregion

                    rightMoveSingleCell(temp_Cell_A);
                    rightMoveSingleCell(temp_Cell_B);

                    writeBuffer();
                }
            }
        }

        public override void Rotate()
        {
            getBuffer();                                                                    //得到 temp_Cell_A/B 

            InitialCellsList();                                                             //得到 MatrixSet

            if (temp_Cell_A != null && temp_Cell_B != null /*&&                               //确保从缓冲取出东西了
                (temp_Cell_A.id / getMatrixWidth() + 1) <= (getMatrixHeight() - 2)*/)                                 
            {
                index_temp_A = temp_Cell_A.id - 1;
                index_temp_B = temp_Cell_B.id - 1;

                //new_Cell_A_Index = index_temp_A - getMatrixWidth();
                //new_Cell_B_Index = index_temp_B + 1;

                new_Cell_A_Index = index_temp_A + 1 - getMatrixWidth();
                new_Cell_B_Index = index_temp_B;

                if (new_Cell_A_Index >= 0 && new_Cell_B_Index >= 0)
                {
                    if ((index_temp_A + 1) % getMatrixWidth() == 0)                         //最右边的情况  左移
                    {
                        new_Cell_A_Index -= 1;
                        new_Cell_B_Index -= 1;
                        
                        //#region 在最右边 被夹在中间 的 情况

                        //if (!CellsList[new_Cell_B_Index].getCanMove() ||
                        //    !CellsList[new_Cell_A_Index].getCanMove())                      //如果如果左边任何一个有东西
                        //{
                        //    //int tempIndex = new_Cell_A_Index;                             //AB颠倒
                        //    //new_Cell_A_Index = index_temp_B;
                        //    //new_Cell_B_Index = index_temp_A;

                        //    //if (temp_Cell_A.getCanMove() &&                                  
                        //    //    temp_Cell_B.getCanMove() &&
                        //    //    CellsList[new_Cell_A_Index].getCanMove() &&
                        //    //    CellsList[new_Cell_B_Index].getCanMove())
                        //    //{
                        //        cellTranslator.exchangeAB(CellsList[index_temp_A], CellsList[index_temp_B]);
                        //        writeBuffer();
                        //        changeState(new C_Block_State());
                        //    //}
                        //    return;
                        //}
                        //#endregion
                    }

                    if (!CellsList[new_Cell_A_Index].getCanMove() &&                        //右边有东西移动 同时不能穿到上一行
                        (index_temp_B + 1) % getMatrixWidth() > 1)                          //也就是说现在b不在最左边 也就是新a（b+1）是大于1的
                    {
                        new_Cell_A_Index -= 1;
                        new_Cell_B_Index -= 1;

                        //#region 左右都有东西的情况

                        //if (!CellsList[new_Cell_B_Index].getCanMove() ||
                        // !CellsList[new_Cell_A_Index].getCanMove())                           //如果如果左边任何一个有东西
                        //{
                        //    //int tempIndex = new_Cell_A_Index;                               //AB颠倒
                        //    //new_Cell_A_Index = new_Cell_B_Index;
                        //    //new_Cell_B_Index = tempIndex;

                        //    //if (temp_Cell_A.getCanMove() &&
                        //    //    temp_Cell_B.getCanMove() &&
                        //    //    CellsList[new_Cell_A_Index].getCanMove() &&
                        //    //    CellsList[new_Cell_B_Index].getCanMove())
                        //    //{
                        //    cellTranslator.exchangeAB(CellsList[index_temp_A],CellsList[index_temp_B]);
                        //        writeBuffer();
                        //        changeState(new C_Block_State());
                        //    //}
                        //    return;
                        //}
                        //#endregion
                    }

                    //#region 卡在最左边 右侧有东西
                    //if ((index_temp_B + 1) % getMatrixWidth() == 1)                                   //最左边的情况
                    //{
                    //    if ((!getCanMove(CellsList[index_temp_A + 1])) || (!getCanMove(CellsList[index_temp_B + 1])))
                    //    {
                    //        cellTranslator.exchangeAB(CellsList[index_temp_A], CellsList[index_temp_B]);
                    //        writeBuffer();
                    //        changeState(new C_Block_State());
                    //        return;
                    //    }
                    //}
                    //#endregion



                    if (temp_Cell_A.getCanMove() &&                                         //这一个最后的综合判断 解决了所有可能穿透的问题 所以前方不用再判断
                        temp_Cell_B.getCanMove() &&
                        CellsList[new_Cell_A_Index].getCanMove() &&
                        CellsList[new_Cell_B_Index].getCanMove())
                    {
                        safeTranformAtoB(CellsList[index_temp_B], CellsList[new_Cell_B_Index]);
                        safeTranformAtoB(CellsList[index_temp_A], CellsList[new_Cell_A_Index]);
                        writeBuffer();
                        AutoSwitchState();
                    }
                }
            }
        }

        public override void AutoSwitchState()
        {
            changeState(new D_Block_State());
        }

        public A_Block_State()
        {
            this.POSITION_FLAG = cellInfo.POSITION_FLAG.A;
            this.setIsSplit(false);
        }
        
    }
}