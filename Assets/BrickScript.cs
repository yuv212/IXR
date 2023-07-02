using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public int points=1;  // after hitting the brick getting 
    public int hitsToBreak;
    public Sprite hitsprite;

    public void BreakBrick ()
    {
        hitsToBreak--;
        GetComponent<SpriteRenderer>().sprite = hitsprite;
    }
}
