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
        if(obj.gameObject.tag == "Player") {
            m = obj.gameObject.GetComponent<Movement>();
            m.finished = true;
        }
    }
}
