using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 
/// 添加一个主题 只需要使用dja命名空间
/// 继承自AbstractTheme
/// 然后拖动素材上去
/// 就可以直接在状态模式new出来了 再不用写一行代码 
/// 
/// (PS:这里继承 MonoBehaviour 是为了能够拖动素材上去)
/// 
/// </summary>


namespace DA.STUDIO
{

    public class AbstractTheme : MonoBehaviour, Itheme
    {

        #region Elemets

        [SerializeField]
        protected Sprite redNormal;

        [SerializeField]
        protected Sprite yellowNormal;

        [SerializeField]
        protected Sprite greenNormal;

        [SerializeField]
        protected Sprite blueNormal;



        [SerializeField]
        protected Sprite redFreeze5;

        [SerializeField]
        protected Sprite redFreeze4;

        [SerializeField]
        protected Sprite redFreeze;

        [SerializeField]
        protected Sprite redFreeze2;

        [SerializeField]
        protected Sprite redFreeze1;



        [SerializeField]
        protected Sprite yellowFreeze5;

        [SerializeField]
        protected Sprite yellowFreeze4;

        [SerializeField]
        protected Sprite yellowFreeze;

        [SerializeField]
        protected Sprite yellowFreeze2;

        [SerializeField]
        protected Sprite yellowFreeze1;



        [SerializeField]
        protected Sprite greenFreeze5;

        [SerializeField]
        protected Sprite greenFreeze4;

        [SerializeField]
        protected Sprite greenFreeze;

        [SerializeField]
        protected Sprite greenFreeze2;

        [SerializeField]
        protected Sprite greenFreeze1;



        [SerializeField]
        protected Sprite blueFreeze5;

        [SerializeField]
        protected Sprite blueFreeze4;

        [SerializeField]
        protected Sprite blueFreeze;

        [SerializeField]
        protected Sprite blueFreeze2;

        [SerializeField]
        protected Sprite blueFreeze1;



        [SerializeField]
        protected Sprite redSpecial;

        [SerializeField]
        protected Sprite yellowSpecial;

        [SerializeField]
        protected Sprite greenSpecail;

        [SerializeField]
        protected Sprite blueSpecial;


        [SerializeField]
        protected Sprite Super;

        [SerializeField]
        protected Sprite playBackGround;

        [SerializeField]
        protected Material senceBackGround;

        [SerializeField]
        protected GameObject clearFxObject;






        #endregion


        public GameObject getClearFx()
        {
            return clearFxObject;
        }


        public Sprite getGameBackGround()
        {
            return playBackGround;
        }


        public Material getSenceBackGround()
        {
            return senceBackGround;
        }


        public Sprite getShapeSprite(cellInfo.CELL_COLOR color, cellInfo.CELL_TYPE type)
        {
            if (type == cellInfo.CELL_TYPE.Normal)
            {
                switch (color)
                {
                    case cellInfo.CELL_COLOR.RED:
                        return redNormal;

                    case cellInfo.CELL_COLOR.YELLOW:
                        return yellowNormal;

                    case cellInfo.CELL_COLOR.GREEN:
                        return greenNormal;

                    case cellInfo.CELL_COLOR.BLUE:
                        return blueNormal;
                }
            }



            if (type == cellInfo.CELL_TYPE.Special)
            {
                switch (color)
                {
                    case cellInfo.CELL_COLOR.RED:
                        return redSpecial;

                    case cellInfo.CELL_COLOR.YELLOW:
                        return yellowSpecial;

                    case cellInfo.CELL_COLOR.GREEN:
                        return greenSpecail;

                    case cellInfo.CELL_COLOR.BLUE:
                        return blueSpecial;
                }
            }


            if (type == cellInfo.CELL_TYPE.Freeze)  //only return normal free (3 times) 
            {
                switch (color)
                {
                    case cellInfo.CELL_COLOR.RED:
                        return redFreeze;

                    case cellInfo.CELL_COLOR.YELLOW:
                        return yellowFreeze;

                    case cellInfo.CELL_COLOR.GREEN:
                        return greenFreeze;

                    case cellInfo.CELL_COLOR.BLUE:
                        return blueFreeze;
                }

            }


            if (type == cellInfo.CELL_TYPE.Super)
            {
                return Super;
            }
            

            Debug.LogError("getShapeSprite() ERROR");

            return null;
        }


        public Sprite getLeveledFreezeSprite(cellInfo.CELL_COLOR _color, int _level)
        {
            switch (_color)
            {
                case cellInfo.CELL_COLOR.RED:
                    {
                        switch (_level)
                        {
                            case 0:
                                return redNormal;
                            case 1:
                                return redFreeze1;
                            case 2:
                                return redFreeze2;
                            case 3:
                                return redFreeze;
                            case 4:
                                return redFreeze4;
                            case 5:
                                return redFreeze5;
                        }
                    }
                    break;

                case cellInfo.CELL_COLOR.YELLOW:
                    {
                        switch (_level)
                        {
                            case 0:
                                return yellowNormal;
                            case 1:
                                return yellowFreeze1;
                            case 2:
                                return yellowFreeze2;
                            case 3:
                                return yellowFreeze;
                            case 4:
                                return yellowFreeze4;
                            case 5:
                                return yellowFreeze5;
                        }
                    }
                    break;

                    case cellInfo.CELL_COLOR.GREEN:
                    {
                        switch (_level)
                        {
                            case 0:
                                return greenNormal;
                            case 1:
                                return greenFreeze1;
                            case 2:
                                return greenFreeze2;
                            case 3:
                                return greenFreeze;
                            case 4:
                                return greenFreeze4;
                            case 5:
                                return greenFreeze5;
                        }
                    }
                    break;

                case cellInfo.CELL_COLOR.BLUE:
                    {
                        switch (_level)
                        {
                            case 0:
                                return blueNormal;
                            case 1:
                                return blueFreeze1;
                            case 2:
                                return blueFreeze2;
                            case 3:
                                return blueFreeze;
                            case 4:
                                return blueFreeze4;
                            case 5:
                                return blueFreeze5;
                        }
                    }
                    break;
                    
            }
            return null;
        }


        public void applyBackGround()
        {
            //GameObject.FindGameObjectWithTag("themeBackGround")
            //    .GetComponent<Image>().sprite = this.playBackGround;
        }


    }


}
