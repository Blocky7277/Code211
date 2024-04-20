using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SpaceshipEndLevel : MonoBehaviour
{
    private bool triggered = false;

    private Movement m;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(triggered) {
            transform.position += new Vector3(0, .1f, 0);
        }
    }

        void OnTriggerEnter2D (Collider2D obj) {
        GameObject o = obj.gameObject;
        if(o.tag == "Player" && !triggered) {
            m = o.GetComponent<Movement>();
            m.finished = true;
            if(o.transform.position.x-10 > transform.position.x) {
                m.moveRight();
            }
            else {
                m.moveLeft();
            }
            StartCoroutine(End(o));
            
        }
    }
    IEnumerator End(GameObject o) {
        yield return new WaitForSeconds(.7f);
        if(!o.GetComponent<Movement>().isGrounded) yield return new WaitForSeconds(1.3f);
        o.GetComponent<Renderer>().enabled = false;
        triggered = true;

    }
}
