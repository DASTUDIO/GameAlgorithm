using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{
    public class fxObjectPool : MonoBehaviour
    {
        int MaxObjectInPool = 10;
        float autoRestoreTime = 0.7f;

        Stack<GameObject> pool = new Stack<GameObject>();

        public void getFx(cellContainer cell)
        {
            Vector3 fxPosition = UI_TO_WORLD.getPosition(cell);
            
            if (pool.Count > 0)
            {
                GameObject instantiatedObject = pool.Pop();
                instantiatedObject.SetActive(true);
                instantiatedObject.transform.position = fxPosition;
                
                StartCoroutine(AutoRestore(instantiatedObject));
            }
            else
            {
                GameObject fxObject =  GameController.getResource().getCurrentTheme().getClearFx();
                GameObject instantiatedObject =  Instantiate(fxObject, fxPosition, Quaternion.identity);
                
                StartCoroutine(AutoRestore(instantiatedObject));

            }
        }


        public void restoreFx(GameObject fxObject)
        {
                //Debug.Log(pool.Count);

            if (pool.Count < MaxObjectInPool)
            {
                //push
                pool.Push(fxObject);
                //reset
                fxObject.transform.position = Vector3.zero;
                fxObject.SetActive(false);

            }
            else
            {
                Destroy(fxObject);
            }

        }


        IEnumerator AutoRestore(GameObject fxObject)
        {
            yield return new WaitForSeconds(autoRestoreTime);
            restoreFx(fxObject);

        }


    }
}