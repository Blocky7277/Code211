using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnCollisionStay2D(Collision2D obj) {
        if (obj.gameObject.tag == "Player") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
