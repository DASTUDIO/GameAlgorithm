using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{
    public class taskQuene : MonoBehaviour
    { 
        public float delaySpecialScanTime = 0.1f;

        public void executeDelayClearScan()
        {
            StartCoroutine(delayAdditionalScan(delaySpecialScanTime));
        }

        IEnumerator delayAdditionalScan(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            PreScan.doPreScan();
        }

    }
}