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
        
    }

    void OnCollisionEnter2D(Collision2D obj) {
        GameObject o = obj.gameObject;
        if(o.tag == "Player" && !triggered) {
            triggered = true;
            m = o.GetComponent<Movement>();
            m.finished = true;
            if(o.transform.position.x-10 < transform.position.x) {
                m.moveLeft();
            }
            else {
                m.moveRight();
            }
            StartCoroutine(End(o));
            
        }
    }
    IEnumerator End(GameObject o) {
        yield return new WaitForSeconds(.7f);
        o.SetActive(false);
    }
}
