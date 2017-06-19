using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace DA.STUDIO
{
    public class randomWindowDisplayer : MonoBehaviour
    {

        [SerializeField]
        private int SpecialChanceDenominator = 9;           //means 1/9
        [SerializeField]
        private int SuperChanceDenominator = 500;           //means 1/500
        
        public cellContainer upRandomCell = new cellContainer();
        public cellContainer downRandomCell = new cellContainer();

        Resource r;
        cellInfo info;

        public void doDisplayRandomsCube()
        {
           
            #region Initalize

            r = Resource.getResource();

            info = cellInfo.getCellInfo();

            #endregion

            #region 随机颜色 默认NormalPropety应用

            int upColorRandom = Random.Range(1, 4);

            int downColorRandom = Random.Range(1, 4);

            switch (upColorRandom)
            {
                case 1:

                    // means red
                    upRandomCell.setSprite
                        (r.getCurrentTheme()
                        .getShapeSprite(cellInfo.CELL_COLOR.RED, cellInfo.CELL_TYPE.Normal));

                    //容器
                    upRandomCell.setCellInfo(cellInfo.RedNormal);

                    break;


                case 2:

                    // means yellow
                    upRandomCell.setSprite
                        (r.getCurrentTheme()
                        .getShapeSprite(cellInfo.CELL_COLOR.YELLOW, cellInfo.CELL_TYPE.Normal));

                    //容器
                    upRandomCell.setCellInfo(cellInfo.YellowNormal);

                    break;


                case 3:

                    //means green
                    upRandomCell.setSprite
                        (r.getCurrentTheme()
                        .getShapeSprite(cellInfo.CELL_COLOR.GREEN, cellInfo.CELL_TYPE.Normal));

                    //容器
                    upRandomCell.setCellInfo(cellInfo.GreenNormal);

                    break;


                case 4:

                    // means blue
                    upRandomCell.setSprite
                        (r.getCurrentTheme()
                        .getShapeSprite(cellInfo.CELL_COLOR.BLUE, cellInfo.CELL_TYPE.Normal));

                    //容器
                    upRandomCell.setCellInfo(cellInfo.BlueNormal);

                    break;

            }

            switch (downColorRandom)
            {


                case 1:

                    // means red
                    downRandomCell.setSprite
                        (r.getCurrentTheme()
                        .getShapeSprite(cellInfo.CELL_COLOR.RED, cellInfo.CELL_TYPE.Normal));

                    //容器
                    downRandomCell.setCellInfo(cellInfo.RedNormal);

                    break;


                case 2:

                    //means yellow
                    downRandomCell.setSprite
                        (r.getCurrentTheme()
                        .getShapeSprite(cellInfo.CELL_COLOR.YELLOW, cellInfo.CELL_TYPE.Normal));

                    //容器
                    downRandomCell.setCellInfo(cellInfo.YellowNormal);

                    break;


                case 3:

                    //means green
                    downRandomCell.setSprite
                        (r.getCurrentTheme()
                        .getShapeSprite(cellInfo.CELL_COLOR.GREEN, cellInfo.CELL_TYPE.Normal));

                    //容器
                    downRandomCell.setCellInfo(cellInfo.GreenNormal);

                    break;


                case 4:

                    //means blue
                    downRandomCell.setSprite
                        (r.getCurrentTheme()
                        .getShapeSprite(cellInfo.CELL_COLOR.BLUE, cellInfo.CELL_TYPE.Normal));

                    //容器
                    downRandomCell.setCellInfo(cellInfo.BlueNormal);

                    break;
            }

            #endregion

            #region up随机异化操作

            //一定概率下special化
            int upSpecialChance = Random.Range(1, this.SpecialChanceDenominator);

            if (upSpecialChance == 5)
            {
                //根据本来的颜色属性变换图标 为 special 的 sprite
                switch (upRandomCell.getCellPropety().color)
                {

                    case cellInfo.CELL_COLOR.RED:

                        upRandomCell.setCellInfo(cellInfo.RedSpecial);

                        upRandomCell.setSprite
                            (r.getCurrentTheme()
                            .getShapeSprite(cellInfo.CELL_COLOR.RED, cellInfo.CELL_TYPE.Special));

                        break;

                    case cellInfo.CELL_COLOR.YELLOW:

                        upRandomCell.setCellInfo(cellInfo.YellowSpecial);

                        upRandomCell.setSprite
                            (r.getCurrentTheme()
                            .getShapeSprite(cellInfo.CELL_COLOR.YELLOW, cellInfo.CELL_TYPE.Special));

                        break;

                    case cellInfo.CELL_COLOR.GREEN:

                        upRandomCell.setCellInfo(cellInfo.GreenSpecial);

                        upRandomCell.setSprite
                            (r.getCurrentTheme()
                            .getShapeSprite(cellInfo.CELL_COLOR.GREEN, cellInfo.CELL_TYPE.Special));

                        break;

                    case cellInfo.CELL_COLOR.BLUE:

                        upRandomCell.setCellInfo(cellInfo.BlueSpecial);

                        upRandomCell.setSprite
                            (r.getCurrentTheme()
                            .getShapeSprite(cellInfo.CELL_COLOR.BLUE, cellInfo.CELL_TYPE.Special));

                        break;

                }
            }


            //一旦概率super化 如果super了 就不再special了

            int upSuperChance = Random.Range(1, this.SuperChanceDenominator);

            if (upSuperChance == 200)
            {

                upRandomCell.setCellInfo(cellInfo.Super);

                upRandomCell.setSprite
                    (r.getCurrentTheme()
                    .getShapeSprite(cellInfo.CELL_COLOR.SUPER, cellInfo.CELL_TYPE.Super));
            }

            #endregion

            #region down随机异化操作

            //一定概率下special化
            int downSpecialChance = Random.Range(1, SpecialChanceDenominator);

            if (downSpecialChance == 1)
            {
                switch (downRandomCell.getCellPropety().color)
                {
                    case cellInfo.CELL_COLOR.RED:

                        downRandomCell.setCellInfo(cellInfo.RedSpecial);

                        downRandomCell.setSprite
                             (r.getCurrentTheme()
                            .getShapeSprite(cellInfo.CELL_COLOR.RED, cellInfo.CELL_TYPE.Special));

                        break;

                    case cellInfo.CELL_COLOR.YELLOW:

                        downRandomCell.setCellInfo(cellInfo.YellowSpecial);

                        downRandomCell.setSprite
                            (r.getCurrentTheme()
                            .getShapeSprite(cellInfo.CELL_COLOR.YELLOW, cellInfo.CELL_TYPE.Special));

                        break;

                    case cellInfo.CELL_COLOR.GREEN:

                        downRandomCell.setCellInfo(cellInfo.GreenSpecial);

                        downRandomCell.setSprite
                            (r.getCurrentTheme()
                            .getShapeSprite(cellInfo.CELL_COLOR.GREEN, cellInfo.CELL_TYPE.Special));

                        break;

                    case cellInfo.CELL_COLOR.BLUE:

                        downRandomCell.setCellInfo(cellInfo.BlueSpecial);

                        downRandomCell.setSprite
                            (r.getCurrentTheme()
                            .getShapeSprite(cellInfo.CELL_COLOR.BLUE, cellInfo.CELL_TYPE.Special));

                        break;

                }
            }

            //一定概率super化 如果super了 就不再special了
            int downSuperChance = Random.Range(1, SuperChanceDenominator);

            if (downSuperChance == 1)
            {
                downRandomCell.setCellInfo(cellInfo.Super);

                downRandomCell.setSprite
                    (r.getCurrentTheme()
                    .getShapeSprite(cellInfo.CELL_COLOR.SUPER, cellInfo.CELL_TYPE.Super));

            }

            #endregion
        }

        private static randomWindowDisplayer rwd = null;

        public static randomWindowDisplayer getInstance()
        {
            return rwd;
        }

        void Awake()
        {
            rwd = this;
        }
    }
}