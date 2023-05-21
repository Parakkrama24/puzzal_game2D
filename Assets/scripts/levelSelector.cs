using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelector : MonoBehaviour
{
    public Animator transision;
    [SerializeField]private float transisionTime=1f;    
    public void selectL1()
    {
        StartCoroutine(loadlevel1());
    }
    public void selectL2()
    {
        StartCoroutine(loadlevel2());
    }

    IEnumerator loadlevel1()
    {
        transision.SetTrigger("start");
        yield return new WaitForSeconds(transisionTime);
        SceneManager.LoadScene("level1");
    }
    IEnumerator loadlevel2()
    {
        transision.SetTrigger("start");
        yield return new WaitForSeconds(transisionTime);
        SceneManager.LoadScene("level1");
    }
}
