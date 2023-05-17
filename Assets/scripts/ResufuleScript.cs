using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResufuleScript : MonoBehaviour
{
   public gamescript2 gameScript;
    
   public void resuffle()
    {
        gameScript= GetComponent<gamescript2>();
        gameScript.shuffle();
    }
    
}
