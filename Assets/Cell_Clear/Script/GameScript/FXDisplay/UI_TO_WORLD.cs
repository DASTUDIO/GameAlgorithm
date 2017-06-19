using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{
    public class UI_TO_WORLD
    {

        //这里设置两个锚点 左下角和右上角
        static Vector3 startPosition = new Vector3(-2.61f, -4.03f, 0f);
        static Vector3 endPosition = new Vector3(2.51f, 6.19f, 0f);


        public static Vector3 getPosition(cellContainer cell)
        {

            float width = cellInfo.CellSetsWidth;
            float height = cellInfo.CellSetsHeigh;

            float xDistance = (endPosition.x - startPosition.x) / (width - 1);
            float yDistance = (endPosition.y - startPosition.y) / (height - 1);

            float zPosition = startPosition.z;

            float x = 0;
            float y = 0;

            float id = cell.id;

            x = cell.id % cellInfo.CellSetsWidth;
            y = (cell.id / cellInfo.CellSetsWidth) + 1;


            float xPosition = startPosition.x + (x - 1) * xDistance;
            float yPosition = startPosition.y + (y - 1) * yDistance;

            if (x == 0)
            {
                xPosition = startPosition.x + (width - 1) * xDistance;
            }

            return new Vector3(xPosition, yPosition, zPosition);

        }

    }
}