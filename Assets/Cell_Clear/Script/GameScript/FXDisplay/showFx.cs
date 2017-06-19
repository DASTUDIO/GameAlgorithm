using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DA.STUDIO
{ 

    public class showFx : MonoBehaviour
    {

        [SerializeField]
        fxObjectPool pool;

        public void doShowFx(cellContainer cell)
        {
            pool.getFx(cell);
            
        }

        
        
    }


}