using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DA.STUDIO
{
    public class DragHandler : MonoBehaviour
    {
        #region Elements

        [SerializeField]

        float X_Min_Distance = 100f;
        float Y_Min_Distance = 200f;

        float Began_X;
        float Began_Y;

        float Delta_X;
        float Delta_Y;

        #endregion

        #region Drag Handler Function

        public void OnTouchPadDragBegan()
        {
            Began_X = Input.mousePosition.x;
            Began_Y = Input.mousePosition.y;
        }

        public void OnTouchPadEnd()
        {
            Delta_X = Input.mousePosition.x - Began_X;
            Delta_Y = Input.mousePosition.y - Began_Y;

            if (Mathf.Abs(Delta_Y) > Y_Min_Distance)
            {
                if (Delta_Y < 0)
                {
                    GameManager.fastDrop();

                }
            }
            else
            {
                if (Mathf.Abs(Delta_X) > X_Min_Distance)
                {
                    if (Delta_X < 0)
                    {
                        GameManager.getCurrentAirState().LeftMove();
                    }
                    else
                    {
                        GameManager.getCurrentAirState().RightMove();
                    }
                }
            }



        }

        #endregion

        #region Click Handler Function

        public void OnRotateButtonClicked()
        {
            GameManager.getCurrentAirState().Rotate();
        }

        #endregion

    }
}