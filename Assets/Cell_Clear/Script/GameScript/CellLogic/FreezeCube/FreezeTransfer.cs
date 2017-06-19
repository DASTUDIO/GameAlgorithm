using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{
    public class FreezeTransfer : MonoBehaviour
    {
        Sprite freezeSix;
        Sprite freezeFive;
        Sprite freezeFour;
        Sprite freezeThree;
        Sprite freezeTwo;
        Sprite freezeOne;

        public static void doTransferFreezeOneTime(cellContainer cell)
        {
            if (cell.getIsFreeze())
            {
                if (cell.getFreezeTime() > 0)
                {
                    cell.setFreezeTime(cell.getFreezeTime() - 1);
                }
            } 
        }

        //public static void InverseTransferFreezeOneTime(cellContainer cell)
        //{
        //    cell.setIsFreeze(false);
        //    cell.setFreezeTime(-1);
        //}


    }
}