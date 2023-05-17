using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameMenuUi : MonoBehaviour
{
   public void loadscen()
    {
        SceneManager.LoadScene(0);
    }
    public void levelSelector()
    {
        SceneManager.LoadScene("levelSelector");
    }
}
