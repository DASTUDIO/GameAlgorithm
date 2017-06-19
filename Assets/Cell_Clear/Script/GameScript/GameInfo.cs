using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{
    public class GameInfo : MonoBehaviour
    {
        static float deltaCubeScore = 0;
        static float deltaBigCubeScore = 0;

        static float totalCubeScore = 0;
        static float totalBigCubeScore = 0;
         
        public static void resetCubeScore()
        {
            deltaCubeScore = 0;
        }                   //只在下次写入之前清空
        public static void resetBigCubeScore()
        {
            deltaBigCubeScore = 0;
        }                //只在下次写入之前清空

        public static void addCubeScore()
        {
            deltaCubeScore += 1;
            totalCubeScore += 1;

            //UIManager.setScoreBoard(totalCubeScore.ToString());

        }
        public static void addBigCubeScore()
        {
            deltaBigCubeScore += 1;
            totalBigCubeScore += 1;

            #region 鉴于大块对普通是 1:6 所以这里加2就好 因为本来就是4
            
            deltaCubeScore += 2;
            totalCubeScore += 2;

            #endregion

            //UIManager.doVisualAddBigCubeScore();

        }

        public static float getDeltaCubeScore()
        {
            return deltaCubeScore;
        }
        public static float getDeltaBigCubeScore()
        {
            return deltaBigCubeScore;
        }

        public static float getTotalCubeScore()
        {
            return totalCubeScore;
        }
        public static float getTotalBigCubeScore()
        {
            return totalBigCubeScore;
        }
        

        static float myHp = 0;
        static float enemyHp = 0;

        public static void setMyHp(float value)
        {
            myHp = value;
        }

        public static void setEnemyHp(float value)
        {
            enemyHp = value;
        }

        public static float getMyHp()
        {
            return myHp;
        }

        public static float getEnemyHp()
        {
            return enemyHp;
        }


    }
}