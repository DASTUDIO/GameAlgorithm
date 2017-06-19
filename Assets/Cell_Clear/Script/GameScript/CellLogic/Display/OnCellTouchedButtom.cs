using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace DA.STUDIO
{
    public class OnCellTouchedButtom
    {
        private List<cellContainer> list;

        public static void OnTouchedCell()
        {
            //还原DropTima
            TimeTrigger.setTimeInterval(0.5f);

            //锁定空中A块
            GameController.getResource().getAirCubeBuffer().getCell_A().setCanMove(false);
            GameController.getResource().getAirCubeBuffer().getCell_A().setIsAirCube(false);
            
            //锁定空中B块
            GameController.getResource().getAirCubeBuffer().getCell_B().setCanMove(false);
            GameController.getResource().getAirCubeBuffer().getCell_B().setIsAirCube(false);

            //扫一次全套
            GameManager.doClearScan();

            //拉一次随机
            GameManager.doRandomWindowToCellSets();                 //从随机窗载入新方块到AIR 中会重刷入缓冲区 所以放最后

            //触发血条
            //UIManager.setSelfHpValue(CELLSLIST_TO_HP.GET_HP());     //每次方块落地触发设置血条

            //减一扫描 
            //doSomeFreezeScan for substract 1
            //SkillSwitcher.Auto_Trigger_Skill();


        }
    }
}