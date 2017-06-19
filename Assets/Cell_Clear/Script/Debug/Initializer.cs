using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{
    public class Initializer : MonoBehaviour
    {
        void Start()
        {
            initAllCellsPropetyAndSprite(GameManager.getWholeCellList());

            Resource.getResource().setCurrentTheme
                (GameObject.FindGameObjectWithTag("Themes").GetComponent<theme_Jelly>());

            GameManager.setCurrentAirState(new A_Block_State());

            GameManager.StartGame();
        }
        
        void initAllCellsPropetyAndSprite(List<cellContainer> list)
        {
            foreach (var cell in list)
            {
                cell.setSprite(null);
                cell.setCellInfo(cellInfo.noneInfo);
            }
        }
        
    }
}