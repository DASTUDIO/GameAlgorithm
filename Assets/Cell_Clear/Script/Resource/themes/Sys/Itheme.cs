using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO {

    public interface Itheme
    {

        Sprite getShapeSprite(cellInfo.CELL_COLOR color, cellInfo.CELL_TYPE type);

        Sprite getGameBackGround();

        Sprite getLeveledFreezeSprite(cellInfo.CELL_COLOR _color, int _level);

        Material getSenceBackGround();

        GameObject getClearFx();

        void applyBackGround();

    }
}