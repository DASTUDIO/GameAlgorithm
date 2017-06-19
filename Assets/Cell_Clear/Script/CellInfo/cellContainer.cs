using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

namespace DA.STUDIO
{
    public class cellContainer : MonoBehaviour {

        //id
        public int id;

        //cellPropety
        private cellInfo.cellPropety cellPropety;
        public void setCellInfo(cellInfo.cellPropety cellPropety)
        {
            this.cellPropety = cellPropety;
        }
        public cellInfo.cellPropety getCellPropety()
        {
            return this.cellPropety;
        }

        //CanMove
        public void setCanMove(bool b)
        {
            this.cellPropety.canMove = b;
        }
        public bool getCanMove()
        {
            return this.cellPropety.canMove;
        }

        //WillClear
        public void setWillClear(bool b)
        {
            this.cellPropety.willClear = b;
        }
        public bool getWillClear()
        {
            return this.cellPropety.willClear;
        }

        //Color
        public void setColor(cellInfo.CELL_COLOR color)
        {
            this.cellPropety.color = color;
        }
        public cellInfo.CELL_COLOR getColor()
        {
            return this.cellPropety.color;
        }

        //beDigged
        public void setBeDigged(bool b)
        {
            this.cellPropety.beDigged = b;
        }
        public bool getBeDigged()
        {
            return this.cellPropety.beDigged;
        }

        //type
        public void setType(cellInfo.CELL_TYPE type)
        {
            this.cellPropety.cubeType = type;
        }
        public cellInfo.CELL_TYPE getType()
        {
            return this.cellPropety.cubeType;
        }

        ////MatrixLevel
        //public void setMatrixLevel(cellInfo.MATRIX_LEVEL level)
        //{
        //    this.cellPropety.matrix_level = level;
        //}
        //public cellInfo.MATRIX_LEVEL getMatrix_Level()
        //{
        //    return this.cellPropety.matrix_level;
        //}


        //isCombineAnchor
        public void setIsCombineAnchor(bool b)
        {
            this.cellPropety.isCombineAnchor = b;
        }
        public bool getIsCombineAnchor()
        {
            return this.cellPropety.isCombineAnchor;
        }


        //isFreeze
        public void setIsFreeze(bool b)
        {
            this.cellPropety.isFreeze = b;
        }

        public bool getIsFreeze()
        {
            return this.cellPropety.isFreeze;
        }



        //FreezeTime  这里是回合数 不是浮点的时间
        //这里封装了图形上的替换
        public void setFreezeTime(int freeTime)
        {
            this.cellPropety.freezeTime = freeTime;
            this.gameObject.GetComponent<Image>().sprite =
                Resource.getResource().getCurrentTheme().getLeveledFreezeSprite(this.getColor(), freeTime);
    

    }

        public int getFreezeTime()
        {
            return this.cellPropety.freezeTime;
        }

        //lists
        public List<cellContainer> horizontalSets = new List<cellContainer>();
        public List<cellContainer> verticalSets = new List<cellContainer>();


        //Display
        #region DisPlay Module

        //设置显示的方块  为null自动化清空方块
        public void setSprite(Sprite sp)
        {
            if (sp != null)
            {
                this.gameObject.GetComponent<Image>()
                    .sprite = sp;

                this.gameObject.GetComponent<Image>()
                    .color = new Color(0.61176470588235294117647058823529f, 0.61176470588235294117647058823529f, 0.61176470588235294117647058823529f, 1);
            }
            else if (sp == null)
            {

                this.gameObject.GetComponent<Image>()
                    .sprite = null;

                this.gameObject.GetComponent<Image>()
                    .color = new Color(0, 0, 0, 0);
            }
            else
            {
#if UNITY_EDITOR

                Debug.Log("Cell Set Sprite Error");

#endif
            }

        }

        //得到显示的方块Sprite 多用于现实上的传递移动
        public Sprite getSprite()
        {
            return this.gameObject.GetComponent<Image>().sprite;
        }

        #endregion


        //isAirCube
        public void setIsAirCube(bool b)
        {
            this.cellPropety.isAirCube = b;
        }
        public bool getIsAirCube()
        {
            return this.cellPropety.isAirCube;
        }


    }
}