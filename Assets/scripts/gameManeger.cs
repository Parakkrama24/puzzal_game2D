using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManeger : MonoBehaviour
{
    [SerializeField] private Transform gametransform;
    [SerializeField] private Transform piecePreFab;

    private int emptylocation;
    private int size;

    private void creategamePease(float gapThickness)
    {
        float width = 1/(float)size;    
        for(int raw=0;raw<size;raw++)
        {
            for(int colomn = 0; colomn < size; colomn++)
            {
                Transform piece=Instantiate(piecePreFab, gametransform);
                piece.localPosition=new Vector3(-1+(2*width*colomn)+width,
                    +1-(2*width*raw)+width,0);
                piece.localScale=((2*width)-gapThickness)*Vector3.one;
                piece.name=$"{(raw*size)+colomn}";
                if((raw==size-1)&&(colomn==size-1))
                {
                    emptylocation = (size * size) - 1;
                    piece.gameObject.SetActive(false);
                }
                
            }
        }
    }
    void Start()
    {
        size=3;
        creategamePease(0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
