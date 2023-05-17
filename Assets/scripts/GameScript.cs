using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] private Transform emptySpace=null;
    private Camera _maincamara;
    void Start()
    {
        _maincamara = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _maincamara.ScreenPointToRay(Input.mousePosition);//getMouse potition
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if (Vector2.Distance(emptySpace.position, hit.transform.position) <= 1.25)
                {
                    Vector2 temp = emptySpace.position;
                    emptySpace.position = hit.transform.position;
                    hit.transform.position = temp;
                }
                else
                {
                    Debug.Log("Not a valid move");
                }
            }
        }
    }
}
