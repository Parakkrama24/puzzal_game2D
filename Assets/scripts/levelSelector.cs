using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelector : MonoBehaviour
{
    public void selectL1()
    {
        SceneManager.LoadScene("level1");
    }
    public void selectL2()
    {
        SceneManager.LoadScene("level2");
    }

}
