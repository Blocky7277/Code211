
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlowGravityPowerup : MonoBehaviour
{
    bool triggered = false;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player" && !triggered)
        {
            obj.gameObject.GetComponent<Rigidbody2D>().gravityScale *= 0.5f;
            StartCoroutine(Timer(obj));
            triggered = true;
            GetComponent<Renderer>().enabled = false;

        }
    }

    IEnumerator Timer(Collider2D obj)
    {
        yield return new WaitForSeconds(8f);
        obj.gameObject.GetComponent<Rigidbody2D>().gravityScale *= 2f;
        Destroy(gameObject);

    }
}
