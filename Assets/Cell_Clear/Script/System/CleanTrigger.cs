using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DA.STUDIO
{
    public class CleanTrigger : MonoBehaviour
    {
        public Animator amr;

        public int[] stage; //不同消除等级的 分数界限

        public float scoreOperator;

        public void doCleanTrigger(int cleanNumber)
        {
            #region fx
            //fx    这里是消除大量方块后的全屏特效 不涉及定位
            for (int i = 0; i < stage.Length - 1; i++)
            {
                if (cleanNumber > stage[i] && cleanNumber < stage[i - 1])
                {

                }
            }
            #endregion
            
            #region skillBlock
            //skill
            for (int i = 0; i < stage.Length - 1; i++)
            {
                if (cleanNumber > stage[i] && cleanNumber < stage[i + 1])
                {
                    string index = @"stage" + i;
                    Debug.Log("trigger : " + index);
                    amr.SetTrigger("index");
                }
            }
            #endregion

            #region score & networt
            //score & network
            //GameManager.setScore((float)cleanNumber * scoreOperator);

            #endregion

        }


    }
}