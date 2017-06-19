using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{

    public class TimeTrigger : MonoBehaviour
    {
        [SerializeField]
        public static float timeInterval = 0.5f;
        public static void setTimeInterval(float ti)
        {
            timeInterval = ti;
            nextTime = 0;
            
        }
        public static float getTimeInterval()
        {
            return timeInterval;
        }
        
        private static float nextTime = 0f; 

        void Update()
        {
            if (Time.time > nextTime)
            {
                if (GameManager.getCurrentAirState() != null)
                {
                    GameManager.getCurrentAirState().NatureDrop();
                }
                nextTime = Time.time + timeInterval;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GameManager.getCurrentAirState().LeftMove();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                GameManager.getCurrentAirState().RightMove();
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                GameManager.getCurrentAirState().Rotate();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                setTimeInterval(0.01f);
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                List<cellContainer> cellsList = GameManager.getWholeCellList();

                for (int index = 0; index < cellsList.Count; index++)
                {
                    Debug.Log(cellsList[index].getType());
                }
            }
        }
    }
}