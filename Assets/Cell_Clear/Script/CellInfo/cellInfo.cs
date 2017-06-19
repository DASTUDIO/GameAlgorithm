using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DA.STUDIO
{
    public class cellInfo : MonoBehaviour
    {
        public List<cellContainer> cellWholeSet;

        public static int CellSetsWidth = 6;
        public static int CellSetsHeigh = 11;

        public enum CELL_COLOR
        {
            RED,
            YELLOW,
            BLUE,
            GREEN,
            SUPER,
            NONE,
            var
        }

        public enum RANDOM_WINDOW_SIDE
        {
            LEFT,
            RIGHT
        }

        public enum MOVE_DIRECTION
        {
            DOWN,
            LEFT,
            RIGHT,
            STOP
        }

        public enum POSITION_FLAG
        {
            A,
            B,
            C,
            D
        }

        public enum CELL_TYPE
        {
            None,
            HideInBig,
            Freeze,
            Normal,
            Special,
            Super
        }

        public struct cellPropety
        {
            public cellInfo.CELL_COLOR color;
            
            public cellInfo.CELL_TYPE cubeType;

            public bool beDigged;

            public bool willClear;

            public bool canMove;

            public bool isAirCube;

            public bool isCombineAnchor;

            //这属性有专用的的Scanner
            public bool isFreeze;

            public int freezeTime;

        }


        #region prefabPropety

        //预制 cell Propety

        public static cellPropety RedNormal = new cellPropety
        {
            color = cellInfo.CELL_COLOR.RED,
            cubeType = cellInfo.CELL_TYPE.Normal,
            beDigged = false,
            willClear = false,
            canMove = true,
            isAirCube = false,
            isCombineAnchor = false,
            isFreeze = false

        };


        public static cellPropety YellowNormal = new cellPropety
        {
            color = cellInfo.CELL_COLOR.YELLOW,
            cubeType = cellInfo.CELL_TYPE.Normal,
            beDigged = false,
            willClear = false,
            canMove = true,
            isAirCube = false,
            isCombineAnchor = false,
            isFreeze = false
        };


        public static cellPropety GreenNormal = new cellPropety
        {
            color = cellInfo.CELL_COLOR.GREEN,
            cubeType = cellInfo.CELL_TYPE.Normal,
            beDigged = false,
            willClear = false,
            canMove = true,
            isAirCube = false,
            isCombineAnchor = false,
            isFreeze = false
        };


        public static cellPropety BlueNormal = new cellPropety
        {
            color = cellInfo.CELL_COLOR.BLUE,
            cubeType = cellInfo.CELL_TYPE.Normal,
            beDigged = false,
            willClear = false,
            canMove = true,
            isAirCube = false,
            isCombineAnchor = false,
            isFreeze = false
        };


        public static cellPropety RedSpecial = new cellPropety
        {
            color = cellInfo.CELL_COLOR.RED,
            cubeType = cellInfo.CELL_TYPE.Special,
            beDigged = false,
            willClear = false,
            canMove = true,
            isAirCube = false,
            isCombineAnchor = false,
            isFreeze = false
        };


        public static cellPropety YellowSpecial = new cellPropety
        {
            color = cellInfo.CELL_COLOR.YELLOW,
            cubeType = cellInfo.CELL_TYPE.Special,
            beDigged = false,
            willClear = false,
            canMove = true,
            isAirCube = false,
            isCombineAnchor = false,
            isFreeze = false

        };


        public static cellPropety GreenSpecial = new cellPropety
        {
            color = cellInfo.CELL_COLOR.GREEN,
            cubeType = cellInfo.CELL_TYPE.Special,
            beDigged = false,
            willClear = false,
            canMove = true,
            isAirCube = false,
            isCombineAnchor = false,
            isFreeze = false
        };


        public static cellPropety BlueSpecial = new cellPropety
        {
            color = cellInfo.CELL_COLOR.BLUE,
            cubeType = cellInfo.CELL_TYPE.Special,
            beDigged = false,
            willClear = false,
            canMove = true,
            isAirCube = false,
            isCombineAnchor = false,
            isFreeze = false
        };


        public static cellPropety Super = new cellPropety
        {
            color = cellInfo.CELL_COLOR.SUPER,
            cubeType = cellInfo.CELL_TYPE.Super,
            beDigged = false,
            willClear = false,
            canMove = true,
            isAirCube = false,
            isCombineAnchor = false,
            isFreeze = false
        };


        public static cellPropety noneInfo = new cellPropety
        {
            color = cellInfo.CELL_COLOR.NONE,
            cubeType = cellInfo.CELL_TYPE.None,
            beDigged = true,
            willClear = false,
            canMove = true,
            isAirCube = false,
            isCombineAnchor = false,
            isFreeze = false
        };


        public static cellPropety HideInBig = new cellPropety
        {
            color = cellInfo.CELL_COLOR.var,
            cubeType = cellInfo.CELL_TYPE.HideInBig,
            beDigged = false,
            willClear = false,
            canMove = false,
            isAirCube = false,
            isCombineAnchor = false,
            isFreeze = false

        };

        public static cellPropety RedNormalFreezed = new cellPropety
        {
            color = cellInfo.CELL_COLOR.RED,
            cubeType = cellInfo.CELL_TYPE.Normal,
            beDigged = false,
            willClear = false,
            canMove = false,
            isAirCube = false,
            isCombineAnchor = false,
            isFreeze = true,
            freezeTime = 3

        };


        public static cellPropety YellowNormalFreezed = new cellPropety
        {
            color = cellInfo.CELL_COLOR.YELLOW,
            cubeType = cellInfo.CELL_TYPE.Normal,
            beDigged = false,
            willClear = false,
            canMove = false,
            isAirCube = false,
            isCombineAnchor = false,
            isFreeze = true,
            freezeTime = 3
        };


        public static cellPropety GreenNormalFreezed = new cellPropety
        {
            color = cellInfo.CELL_COLOR.GREEN,
            cubeType = cellInfo.CELL_TYPE.Normal,
            beDigged = false,
            willClear = false,
            canMove = false,
            isAirCube = false,
            isCombineAnchor = false,
            isFreeze = true,
            freezeTime = 3
        };


        public static cellPropety BlueNormalFreezed = new cellPropety
        {
            color = cellInfo.CELL_COLOR.BLUE,
            cubeType = cellInfo.CELL_TYPE.Normal,
            beDigged = false,
            willClear = false,
            canMove = false,
            isAirCube = false,
            isCombineAnchor = false,
            isFreeze = true,
            freezeTime = 3
        };


        #endregion


        public static cellInfo instance;
        public static cellInfo getCellInfo()
        {
            return instance;
        }
        void Awake()
        {
            instance = this;
        }

    }
}