using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{
    public class C_Block_State : AbstractAirBlockState
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
                    //A到底
                    if (index_temp_A < getMatrixWidth())
                    {
                        OnTouchCallScanAndRandomGen();
                        return;
                    }
                    else if (!getCanMove(CellsList[new_Cell_A_Index]))   //A不再最底且底下有东西
                    {
                        OnTouchCallScanAndRandomGen();
                        return;
                    }

                    //无拦截就移动
                    downMoveSingleCell(temp_Cell_A);
                    downMoveSingleCell(temp_Cell_B);

                    writeBuffer();

                }
            }
        }

        public override void LeftMove()
        {
            getBuffer();

            InitialCellsList();

            if (temp_Cell_A != null && temp_Cell_B != null)
            {
                index_temp_A = temp_Cell_A.id - 1;
                index_temp_B = temp_Cell_B.id - 1;

                new_Cell_A_Index = index_temp_A - 1;
                new_Cell_B_Index = index_temp_B - 1;

                if (index_temp_A >= 0 && index_temp_B >= 0)
                {
                    if ((index_temp_A + 1) % getMatrixWidth() == 1)
                    {
                        return;
                    }
                    else if(!getCanMove(CellsList[new_Cell_A_Index]))
                    {
                        return;
                    }
                    
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

                    if ((index_temp_A + 1) % getMatrixWidth() == 0)
                    {
                        return;
                    }
                    else if (!getCanMove(CellsList[new_Cell_A_Index]))
                    {
                        return;
                    }
                    
                    rightMoveSingleCell(temp_Cell_A);
                    rightMoveSingleCell(temp_Cell_B);

                    writeBuffer();

                }
            }
        }

        public override void Rotate()
        {
            getBuffer();

            InitialCellsList();

            if (temp_Cell_A != null && temp_Cell_B != null)
            {
                index_temp_A = temp_Cell_A.id-1;
                index_temp_B = temp_Cell_B.id - 1;

                //new_Cell_A_Index = index_temp_A + 1;
                //new_Cell_B_Index = index_temp_B - getMatrixWidth();

                new_Cell_A_Index = index_temp_A + getMatrixWidth() - 1;
                new_Cell_B_Index = index_temp_B;

                if (new_Cell_A_Index >= 0 && new_Cell_B_Index >= 0)
                {
                    if ((index_temp_A + 1) % getMatrixWidth() == 1) 
                    {
                        new_Cell_A_Index += 1;
                        new_Cell_B_Index += 1;
                    }

                    if(!CellsList[new_Cell_A_Index].getCanMove() &&
                            (index_temp_B+1)%getMatrixWidth() !=0)
                        {
                        new_Cell_A_Index += 1;
                        new_Cell_B_Index += 1;
                        }

                    if (temp_Cell_A.getCanMove() && 
                        temp_Cell_B.getCanMove() && 
                        CellsList[new_Cell_A_Index].getCanMove() &&
                        CellsList[new_Cell_B_Index].getCanMove())
                    {
                        safeTranformAtoB(temp_Cell_B, CellsList[new_Cell_B_Index]);
                        safeTranformAtoB(temp_Cell_A, CellsList[new_Cell_A_Index]);
                        writeBuffer();
                        AutoSwitchState();
                    }
                }
            }
        }

        public override void AutoSwitchState()
        {
            changeState(new B_Block_State());
        }

        public C_Block_State()
        {
            this.POSITION_FLAG = cellInfo.POSITION_FLAG.C;
            this.setIsSplit(false);
        }

    }
}