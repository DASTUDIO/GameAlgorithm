using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{
    public class CleanScan : MonoBehaviour
    {
        static bool hasCleanAction = false; //有否清除的flag

        public static void doCleanScan()
        {
            //锁定重力
            additionalDrop.freezeDrop = true;

            List<cellContainer> cellsList = GameManager.getWholeCellList();

            for (int index = 0; index < cellsList.Count; index++)
            {
                detectClean(cellsList[index]);
            }

            //清除后格局改变 清空所有格子记录周围颜色一样的信息 要重新录入
            resetAllCubeHnVSets();

            //如果有清楚 那么 清除后连锁消除效果 再扫一遍 只发生在已经发动清除之后
            if (hasCleanAction == true)
            {
                PreScan.doDelayPreScan();
                hasCleanAction = false;
            }
            
            //设置一次HP
            //UIManager.setSelfHpValue(CELLSLIST_TO_HP.GET_HP());

            //解锁重力
            additionalDrop.freezeDrop = false;

            //上传数据  有时间限制 避免阻塞网络
            if (Time.time > nextTime)
            {
                //MainGameInitialize.getNetWorkCompoent().sendScore((int)GameInfo.getDeltaCubeScore());
                Debug.Log("Alreally send socre: " + (int)GameInfo.getDeltaCubeScore());
                GameInfo.resetCubeScore();

                //nextTime = Time.time + MainGameInitialize.freezeMinTime;

        }
    }


        static float nextTime = 0;

        static void detectClean(cellContainer cell)
        {
            if (cell.getWillClear())
            {
                hasCleanAction = true;
                doCleanCube(cell);
            }
        }


        static void doCleanCube(cellContainer cell)
        {
            if (cell.getIsCombineAnchor())
            {
                BigCubeTransfer.reverseTransformFromBig(cell);
                GameInfo.addBigCubeScore();                             //加一个大块记分
            }


            //清除该块
            cell.setCellInfo(cellInfo.noneInfo);
            cell.setSprite(null);
            
            //播放特效
            GameManager.doShowFx(cell);

            //加一个普通方块记分
            GameInfo.addCubeScore();

        }

        static void resetAllCubeHnVSets()
        {
            List<cellContainer> cellsList = GameManager.getWholeCellList();

            for (int index = 0; index < cellsList.Count; index++)
            {
                cellsList[index].verticalSets.Clear();
                cellsList[index].horizontalSets.Clear();
            }
        }

    }
}