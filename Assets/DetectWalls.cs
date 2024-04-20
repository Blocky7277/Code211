using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWalls : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D obj) {
            if (obj.gameObject.layer == 3 && !GetComponentInParent<Movement>().isGrounded) {
                Debug.Log("SADF"); 
                GetComponentInParent<Movement>().immobile = true;
            }
            else {
                GetComponentInParent<Movement>().immobile = false;
            }
    }

    void OnTriggerExit2D(Collider2D obj) {
            if (obj.gameObject.layer == 3) {
                GetComponentInParent<Movement>().immobile = false;
            }
    }
}
