using UnityEngine;
using UnityEngine.SceneManagement;

public class gamescript2 : MonoBehaviour
{
    [Header("SerializeField")]
    [SerializeField] private Transform Emptyspace;
    [SerializeField] private Tilescript[] tiles;
    [SerializeField] private GameObject winPanal;

    private Camera Maincamara;
    private bool _isFinished;
    private int EmptyspaceIndex=8;

    // Start is called before the first frame update
    void Start()
    {winPanal.SetActive(false);
        shuffle();//call the shuffle function
        Maincamara = Camera.main;//assign the main camera to the main camera variable
    }

    public void restart()//restart the game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//load the current scene
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Maincamara.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit)
            {
                if (Vector2.Distance(Emptyspace.position, hit.transform.position) <= 1.25)
                {
                    Vector2 temp = Emptyspace.position;//assinge the position of the empty space to a temp variable
                    Tilescript thistile=hit.transform.GetComponent<Tilescript>();//get the tilescript of the tile that was clicked
                    Emptyspace.position = thistile.targetPotion;//asign the target position of the tile that was clicked to the empty space
                    thistile.targetPotion = temp;//asgin the temp variable to the target position of the tile that was clicked
                    int tileIndex = findTileIndex(thistile);// call the findTileIndex function to find the index of the tile that was clicked
                    tiles[EmptyspaceIndex] = tiles[tileIndex];//asign the tile that was clicked to the empty space index
                    tiles[tileIndex] = null; //asgin null to the tile that was clicked
                    EmptyspaceIndex = tileIndex;// asgin the index of the tile that was clicked to the empty space index
                }
                else
                {
                    Debug.Log("Not a valid move");
                }
            }
        }
        if (!_isFinished)
        {


            int correctTiles = 0;
            foreach (var tile in tiles)
            {
                if (tile != null)
                {
                    if (tile.inRightPosition)
                    {
                        correctTiles++;//count the number of tiles that are in the right position
                    }
                }
            }

            if (correctTiles == tiles.Length - 1)//check if all the tiles are in the right position
            {
                _isFinished = true;
                winPanal.SetActive(true);//activate the win panal
                Debug.Log("You win");
            }
        }
    }
    public void shuffle()//shuffle the tiles
    {if(EmptyspaceIndex!=8)
        {
            var tileOn8lastPos= tiles[8].targetPotion;//assign the target position of the tile in the 8th index to a variable
            tiles[8].targetPotion = Emptyspace.position;//assign the position of the empty space to the target position of the tile in the 15th index
            Emptyspace.position = tileOn8lastPos;//assing the variable to the position of the empty space
            tiles[EmptyspaceIndex] =tiles[8];//assign the tile in the empty space index to the tile in the 8th index
            tiles[8] =null;//assing null to the tile in the 8th index
            EmptyspaceIndex = 8;//assign 15 to the empty space index
        }
        int invertion;
        do
        {
            for (int i = 0; i < 8; i++)
            {
                var lastpos = tiles[i].targetPotion;//assign the target position of the tile to a variable
                int randomNumber = Random.Range(0, 6);
                tiles[i].targetPotion = tiles[randomNumber].targetPotion;
                tiles[randomNumber].targetPotion = lastpos;
                var tile = tiles[i];
                tiles[i] = tiles[randomNumber];
                tiles[randomNumber] = tile;

            }
            invertion = GetInversions();//call and get the count of inversions
            Debug.Log(invertion);//print the count of inversions
        }while(invertion%2 !=0 );
    }
   public int findTileIndex(Tilescript ts)
    {
        for (int i = 0; i < tiles.Length;i++)
        {
            if (tiles[i]!= null)
            {
                if (tiles[i] == ts) { return i; }//return the index of the tile if the tile is found
            }
        }
        return -1;//return -1 if the tile is not found
    }
    int GetInversions()//calculate the inversions
    {
        int inversionsSum = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            int thisTileInvertion = 0;
            for (int j = i; j < tiles.Length; j++)
            {
                if (tiles[j] != null)
                {
                    if (tiles[i].number > tiles[j].number)
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum += thisTileInvertion;
        }
        return inversionsSum;//return the sum of inversions
    }
}
