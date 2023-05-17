using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilescript : MonoBehaviour
{

    public Vector2 targetPotion;
    public Vector2 currentPotiton;
    private SpriteRenderer sprender;
    public  int number;
    public bool inRightPosition;
    private void Awake()
    {
        targetPotion = transform.position;
        currentPotiton= transform.position;
        sprender= GetComponent<SpriteRenderer>();//get the sprite renderer component
    }
    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, targetPotion, 0.2f);//get smooth movement
        if(targetPotion==currentPotiton)
        {
            sprender.color = Color.green;//change the color of the tile to green
            inRightPosition= true;//assing  the bool to true
        }
        else
        {
            sprender.color = Color.red;//change the color of the tile to red
            inRightPosition= false;//assing the bool to false
        }
    }
}

