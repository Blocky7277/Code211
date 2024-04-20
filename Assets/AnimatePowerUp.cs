using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFunctionality : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    private SpriteRenderer spriteRenderer;
    private float frameCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 20 == 0){
            if (frameCount == 1){
                spriteRenderer.sprite = sprite1;
                frameCount++;
            }
            else if (frameCount == 2){
                spriteRenderer.sprite = sprite2;
                frameCount++;
            }
            else if (frameCount == 3){
                spriteRenderer.sprite = sprite3;
                frameCount++;
            }
            else if (frameCount == 4){
                spriteRenderer.sprite = sprite4;
                frameCount++;
            }
            else if (frameCount == 5){
                spriteRenderer.sprite = sprite5;
                frameCount++;
            }
            else if (frameCount == 6){
                spriteRenderer.sprite = sprite6;
                frameCount++;
            }
            else if (frameCount == 7){
                spriteRenderer.sprite = sprite7;
                frameCount = 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            obj.gameObject.GetComponent<Movement>().canFlip = true;
            Destroy(gameObject);
        }
    }
}
