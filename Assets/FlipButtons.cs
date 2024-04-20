using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlipButtons : MonoBehaviour
{
    public Movement playerMovement;
    // Ticks left until the player can start moving
    public int ticksLeft = -1;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (ticksLeft > -1) {
            ticksLeft -= 1;
        }
    }

    void OnCollisionStay2D(Collision2D obj) {
        if (obj.gameObject.tag == "Player") {            
            if (ticksLeft == -1) {
                obj.GetComponent<Rigidbody2D>().gravityScale *= -1;
            }            
        }
    }
}
