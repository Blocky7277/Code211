using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpaceshipEndLevel : MonoBehaviour
{
    private bool triggered = false;
    public int nextSceneIndex = 0;

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
            StartCoroutine(NextLevel());
        }
    }
    IEnumerator End(GameObject o) {
        yield return new WaitForSeconds(.7f);
        if(!o.GetComponent<Movement>().isGrounded) yield return new WaitForSeconds(1.3f);
        o.GetComponent<Renderer>().enabled = false;
        triggered = true;
        
    }

    IEnumerator NextLevel() {
        yield return new WaitForSeconds(2.4f);
        SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(nextSceneIndex).name);
    }
}
