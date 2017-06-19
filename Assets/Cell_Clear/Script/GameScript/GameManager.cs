using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// facade pattern
/// </summary>

namespace DA.STUDIO
{

    public class GameManager
    {
        public static List<cellContainer> getWholeCellList()
        {
            return cellInfo.getCellInfo().cellWholeSet;
        }
        public static randomWindowDisplayer getRandomWindowDisplayer()
        {
            return randomWindowDisplayer.getInstance();
        }
        
        private static IAirState airState = null;
        public static IAirState getCurrentAirState()
        {
            return airState;
        }
        public static void setCurrentAirState(IAirState state)
        {
            airState = state;
        }
        
        public static void fastDrop()
        {
            TimeTrigger.setTimeInterval(0.01f);
        }
        public static void doClearScan()
        {
            PreScan.doPreScan();
        }
        public static void doRandomWindowToCellSets()
        {
            RandomWindowToCellSets.doRandomWindowToCellSet();
        }

        public static void doShowFx(cellContainer cell)
        {
            GameObject.FindGameObjectWithTag("showFx").GetComponent<showFx>().doShowFx(cell);
        }

        public static void doAddFreeze(int cubeCount,int FreezeTimes)
        {
            FreezeCubeGenerator.genRandomFreezeCube(cubeCount,FreezeTimes);

        }



        #region Hp Stuff

        public static void setSelfHpValue(float value)
        {
            GameObject.FindGameObjectWithTag("LeftHp").GetComponent<Slider>().value = value;
        }

        public static float getSelfHpValue()
        {
            return GameObject.FindGameObjectWithTag("LeftHp").GetComponent<Slider>().value;
        }

        public static void setEnemyHpValue(float value)
        {
            GameObject.FindGameObjectWithTag("RightHp").GetComponent<Slider>().value = value;
        }

        public static float getEnemyHpValue()
        {
            return GameObject.FindGameObjectWithTag("RightHp").GetComponent<Slider>().value;
        }

        #endregion



        public static void StartGame()
        {
            GameManager.doRandomWindowToCellSets();
            GameManager.doRandomWindowToCellSets();
        }



    }
}