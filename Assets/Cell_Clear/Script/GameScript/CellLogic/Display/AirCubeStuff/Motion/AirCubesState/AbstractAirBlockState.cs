using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{

    public abstract class AbstractAirBlockState :  IAirState
    {

        public void changeState(AbstractAirBlockState acs)
        {
            GameManager.setCurrentAirState(acs);
        }

        public cellInfo.POSITION_FLAG POSITION_FLAG;

        protected int index_temp_A = -1;
        protected int index_temp_B = -1;
        protected int new_Cell_A_Index = -1;
        protected int new_Cell_B_Index = -1;
        protected cellContainer temp_Cell_A = null;
        protected cellContainer temp_Cell_B = null;


        protected List<cellContainer> CellsList;

        public abstract void NatureDrop();

        public abstract void LeftMove();

        public abstract void RightMove();

        public abstract void Rotate();

        public abstract void AutoSwitchState();


        #region Internal Stuff (protected)

        #region Constant Elements

        protected cellInfo.CELL_COLOR CellNoneColor =
            cellInfo.CELL_COLOR.NONE;

        #endregion

        #region get & set Buffered cell_A cell_B

        protected cellContainer getCell_A()
        {
            return GameController.getResource().getAirCubeBuffer().getCell_A();
        }

        protected void setCell_A(cellContainer a)
        {
            GameController.getResource().getAirCubeBuffer().setCell_A(a);
        }

        protected cellContainer getCell_B()
        {
            return GameController.getResource().getAirCubeBuffer().getCell_B();
        }

        protected void setCell_B(cellContainer b)
        {
            GameController.getResource().getAirCubeBuffer().setCell_B(b);
        }

        #endregion

        protected void InitialCellsList()
        {
            this.CellsList = GameManager.getWholeCellList();
        }

        //temp_Cell_A                       //temp_Cell_B
        protected void getBuffer()
        {
            temp_Cell_A = getCell_A();
            temp_Cell_B = getCell_B();
        }

        protected void writeBuffer()
        {
            if (new_Cell_A_Index != -1 && new_Cell_B_Index != -1)
            {
                InitialCellsList();
                setCell_A(CellsList[new_Cell_A_Index]);
                setCell_B(CellsList[new_Cell_B_Index]);
            }
        }

        protected int getMatrixWidth()
        {
            return cellInfo.CellSetsWidth;
        }

        protected int getMatrixHeight()
        {
            return cellInfo.CellSetsHeigh;
        }

        protected cellInfo.CELL_COLOR getCellColor(cellContainer c)
        {
            return c.getCellPropety().color;
        }

        protected bool getCanMove(cellContainer c)
        {
            return c.getCanMove();
        }

        protected void setCanMove(cellContainer c, bool b)
        {
            c.setCanMove(b);
        }

        protected void Freeze_Cell(cellContainer c)
        {                                                       //全部都落地后 无视是否canMove 缓冲区都要被替换
            c.setCanMove(false);
        }

        protected void Release_Cell(cellContainer c)
        {
            c.setCanMove(true);
        }

        protected void safeTranformAtoB(cellContainer a, cellContainer b)
        {
            //如果ab的id不等 那么转换后 a 会变成canmove为true的空值
            cellTranslator.translateCellInfoAtoB(a, b);
        }

        //这些移动只能判断整体边界 这可能会导致一个移动了另一个不动导致被替换
        //所以要在具体state中控制好
        protected int downMoveSingleCell(cellContainer cell)
        {
            return cellTranslator.safeMove(cell, cellInfo.MOVE_DIRECTION.DOWN);
        }

        protected int leftMoveSingleCell(cellContainer cell)
        {
            return cellTranslator.safeMove(cell, cellInfo.MOVE_DIRECTION.LEFT);
        }

        protected int rightMoveSingleCell(cellContainer cell)
        {
            return cellTranslator.safeMove(cell, cellInfo.MOVE_DIRECTION.RIGHT);
        }

        protected void OnTouchCallScanAndRandomGen()
        {
            OnCellTouchedButtom.OnTouchedCell();
        }

        #region Update Stuff

        protected float nextTime = 0;
        protected float timeInterval = 0.7f;
        protected void doUpdate()
        {
            if (Time.time > nextTime)
            {
                NatureDrop();
                nextTime = timeInterval;
            }
        }

        #endregion

        #endregion


        private bool isSplit;
        public void setIsSplit(bool b)
        {
            this.isSplit = b;
        }
        public bool getIsSplit()
        {
            return this.isSplit;
        }
    }
}