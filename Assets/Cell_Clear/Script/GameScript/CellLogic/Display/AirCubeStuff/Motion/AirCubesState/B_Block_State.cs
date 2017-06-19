using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{

    public class B_Block_State : AbstractAirBlockState
    {

        public override void NatureDrop()
        {
            getBuffer();

            InitialCellsList();

            if (temp_Cell_A != null && temp_Cell_B != null)
            {
                index_temp_A = temp_Cell_A.id - 1;
                index_temp_B = temp_Cell_B.id - 1;

                new_Cell_A_Index = index_temp_A - getMatrixWidth();
                new_Cell_B_Index = index_temp_B - getMatrixWidth();

                if (index_temp_A >= 0 && index_temp_B >= 0)
                {
                    #region 如果到底唤起OnTouch 拦截

                    if (index_temp_A < getMatrixWidth() || index_temp_B < getMatrixWidth())
                    {
                        OnTouchCallScanAndRandomGen();
                        return;
                    }
                    else
                    {   //不是第一排的情况
                        if (!getCanMove(CellsList[new_Cell_A_Index]))   //不在第一排 但是A下面有东西
                        {
                            temp_Cell_A.setCanMove(false);
                            temp_Cell_A.setIsAirCube(false);
                            this.setIsSplit(true);
                        }

                        if (!getCanMove(CellsList[new_Cell_B_Index]))  //不在第一排 但是B下面有东西
                        {
                            temp_Cell_B.setCanMove(false);
                            temp_Cell_B.setIsAirCube(false);
                            this.setIsSplit(true);
                        }

                        if (!getCanMove(CellsList[new_Cell_A_Index]) &&
                            !getCanMove(CellsList[new_Cell_B_Index]))
                        {
                            OnTouchCallScanAndRandomGen();
                            return;
                        }
                    }

                    #endregion

                    downMoveSingleCell(temp_Cell_B);
                    downMoveSingleCell(temp_Cell_A);

                    writeBuffer();
                }
            }
        }

        public override void LeftMove()
        {
            getBuffer();

            InitialCellsList();

            if (temp_Cell_A != null && temp_Cell_B != null && !getIsSplit())
            {
                index_temp_A = temp_Cell_A.id - 1;
                index_temp_B = temp_Cell_B.id - 1;

                new_Cell_A_Index = index_temp_A - 1;
                new_Cell_B_Index = index_temp_B - 1;

                if (index_temp_A >= 0 && index_temp_B >= 0)
                {
                    #region A现在已经到达左侧边界 或者左边有东西 拦截

                    //A到达左侧边界
                    if ((index_temp_A + 1) % getMatrixWidth() == 1)
                    {
                        return;
                    }
                    else
                    {   //A不在左侧边界 但左边有东西
                        if (!getCanMove(CellsList[new_Cell_A_Index]))
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

            if (temp_Cell_A != null && temp_Cell_B != null && !getIsSplit())
            {
                index_temp_A = temp_Cell_A.id - 1;
                index_temp_B = temp_Cell_B.id - 1;

                new_Cell_A_Index = index_temp_A + 1;
                new_Cell_B_Index = index_temp_B + 1;


                if (index_temp_A >= 0 && index_temp_B >= 0)
                {
                    #region B已经到达右侧边界 或者有东西 拦截

                    if ((index_temp_B + 1) % getMatrixWidth() == 0)
                    {
                        return;
                    }
                    else
                    {
                        if (!getCanMove(CellsList[new_Cell_B_Index]))
                        {
                            return;
                        }
                    }

                    #endregion

                    rightMoveSingleCell(temp_Cell_B);
                    rightMoveSingleCell(temp_Cell_A);

                    writeBuffer();

                }
            }
        }

        public override void Rotate()
        {
            getBuffer();

            InitialCellsList();

            if (temp_Cell_A != null && temp_Cell_B != null && !getIsSplit())
            {
                index_temp_A = temp_Cell_A.id - 1;
                index_temp_B = temp_Cell_B.id - 1;

                //new_Cell_A_Index = index_temp_A;
                //new_Cell_B_Index = index_temp_B + getMatrixWidth() - 1;

                new_Cell_A_Index = index_temp_A + getMatrixWidth() + 1;
                new_Cell_B_Index = index_temp_B;

                if (new_Cell_A_Index >= 0 && new_Cell_B_Index >= 0)
                {
                    if (temp_Cell_A.getCanMove() && 
                        temp_Cell_B.getCanMove() && 
                        CellsList[new_Cell_A_Index].getCanMove() && 
                        CellsList[new_Cell_B_Index].getCanMove())
                    {
                        safeTranformAtoB(CellsList[index_temp_A], CellsList[new_Cell_A_Index]);
                        safeTranformAtoB(CellsList[index_temp_B], CellsList[new_Cell_B_Index]);
                        writeBuffer();
                        AutoSwitchState();
                    }
                }
            }
        }

        public override void AutoSwitchState()
        {
            changeState(new A_Block_State());
        }

        public B_Block_State()
        {
            this.POSITION_FLAG = cellInfo.POSITION_FLAG.B;
            this.setIsSplit(false);
        }

        void Update()
        {
            doUpdate();
        }

    }
}