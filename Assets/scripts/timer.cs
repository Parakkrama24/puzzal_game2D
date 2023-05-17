using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    public TextMeshProUGUI text;
   [SerializeField] private int  timerValue;
    void Start()
    {
        text.text = "00";
        StartCoroutine(timerCoroutine());
    }

    IEnumerator timerCoroutine()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(1);//return the value after 1 second
            timerValue += 1;
            text.text = timerValue.ToString();
        }
    }
}//class timer
