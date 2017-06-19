using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{

    public interface IAirState
    {

        void NatureDrop();

        void LeftMove();

        void RightMove();

        void Rotate();

        void AutoSwitchState();         //内部调用


    }

}