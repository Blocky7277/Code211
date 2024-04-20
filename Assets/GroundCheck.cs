using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D obj) {
            if (obj.gameObject.layer == 3) {
                GetComponentInParent<Movement>().isGrounded = true;
            }
    }

    void OnTriggerExit2D(Collider2D obj) {
            if (obj.gameObject.layer == 3) {
                GetComponentInParent<Movement>().isGrounded = false;
            }
    }
}
