using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlipButtons : MonoBehaviour
{
    public Movement playerMovement;
    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnCollisionStay2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            obj.gameObject.GetComponent<Rigidbody2D>().gravityScale *= -1;
            obj.gameObject.GetComponent<Rigidbody2D>().gravityScale *= -1;
        }
    }
}
