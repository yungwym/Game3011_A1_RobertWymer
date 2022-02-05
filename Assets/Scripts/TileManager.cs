using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{

    public static TileManager tileManagerInstance;

    //Grid Variables 
    public GameObject[,] grid;

    private float tileSize = 0.25f;

    public Transform startPosition;

    public GameObject emptyTilePrefab;


    private int GridRowSize;
    private int GridColumnSize;


    private void Awake()
    {
        if (tileManagerInstance != null)
        {
            return;
        }
        tileManagerInstance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateEmptyGrid(int rows, int columns)
    {
        GridRowSize = rows;
        GridColumnSize = columns;

        grid = new GameObject[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for  (int col = 0; col < columns; col++)
            {
                Debug.Log("Tile at Row: " + row + " , Column: " + col);

                float posY = (startPosition.position.y) - row * tileSize;
                float posX = (startPosition.position.x) + col * tileSize;
              
                grid[row, col] = SpawnEmptyTile(row, col, posX, posY);
                
            }
        }
        SpawnMaxResourceTile();
    }

    public GameObject SpawnEmptyTile(int row, int col, float x, float y)
    {
        GameObject newTile = Instantiate(emptyTilePrefab, new Vector2(x, y), Quaternion.identity);
        newTile.GetComponent<Tile>().SetToMinimal(row, col);
        newTile.transform.parent = gameObject.transform;
        return newTile;
    }


    public void SpawnMaxResourceTile()
    {
        for (int i = 0; i < 14; i++)
        {
            int randCol = Random.Range(4, 61);
            int randRow = Random.Range(4, 29);

            Debug.Log("MAX Tile at Row: " + randRow + ", Column: " + randCol);

            grid[randRow, randCol].GetComponent<Tile>().ChangeToMax();

            SpawnHalfResourceTile(randRow, randCol);
        }
    }

    public void SpawnHalfResourceTile(int MaxOriginRow, int MaxOriginCol)
    {
        //9 Tiles to Change to Half
        List<GameObject> halfTiles = new List<GameObject>();

        halfTiles.Add(grid[MaxOriginRow - 1, MaxOriginCol - 1]);
        halfTiles.Add(grid[MaxOriginRow - 1, MaxOriginCol]);
        halfTiles.Add(grid[MaxOriginRow - 1, MaxOriginCol + 1]);
        halfTiles.Add(grid[MaxOriginRow, MaxOriginCol - 1]);
        halfTiles.Add(grid[MaxOriginRow, MaxOriginCol + 1]);
        halfTiles.Add(grid[MaxOriginRow +1 , MaxOriginCol - 1]);
        halfTiles.Add(grid[MaxOriginRow + 1, MaxOriginCol]);
        halfTiles.Add(grid[MaxOriginRow + 1, MaxOriginCol + 1]);

        foreach (GameObject tile in halfTiles)
        {
            Tile tileComp = tile.GetComponent<Tile>();

            if (tileComp.tileType != TileType.MAX)
            {
                tileComp.ChangeToHalf();
            }
        }
        SpawnQuarterResourceTile(MaxOriginRow, MaxOriginCol);
    }

    public void SpawnQuarterResourceTile(int MaxOriginRow, int MaxOriginCol)
    {
        List<GameObject> quartTiles = new List<GameObject>();

        quartTiles.Add(grid[MaxOriginRow - 2, MaxOriginCol - 2]);
        quartTiles.Add(grid[MaxOriginRow - 2, MaxOriginCol - 1]);
        quartTiles.Add(grid[MaxOriginRow - 2, MaxOriginCol]);
        quartTiles.Add(grid[MaxOriginRow - 2, MaxOriginCol + 1]);
        quartTiles.Add(grid[MaxOriginRow - 2, MaxOriginCol + 2]);

        quartTiles.Add(grid[MaxOriginRow - 1, MaxOriginCol - 2]);
        quartTiles.Add(grid[MaxOriginRow - 1, MaxOriginCol + 2]);

        quartTiles.Add(grid[MaxOriginRow, MaxOriginCol - 2]);
        quartTiles.Add(grid[MaxOriginRow, MaxOriginCol + 2]);

        quartTiles.Add(grid[MaxOriginRow + 1, MaxOriginCol - 2]);
        quartTiles.Add(grid[MaxOriginRow + 1, MaxOriginCol + 2]);

        quartTiles.Add(grid[MaxOriginRow + 2, MaxOriginCol - 2]);
        quartTiles.Add(grid[MaxOriginRow + 2, MaxOriginCol - 1]);
        quartTiles.Add(grid[MaxOriginRow + 2, MaxOriginCol]);
        quartTiles.Add(grid[MaxOriginRow + 2, MaxOriginCol + 1]);
        quartTiles.Add(grid[MaxOriginRow + 2, MaxOriginCol + 2]);

        foreach (GameObject tile in quartTiles)
        {
            Tile tileComp = tile.GetComponent<Tile>();

            if (tileComp.tileType != TileType.MAX && tileComp.tileType != TileType.HALF)
            {
                tileComp.ChangeToQuart();
            }
        }
    }


    public void RevealSurroundingTiles(int selectedTileRow, int selectedTileCol)
    {
        List<GameObject> revealTiles = new List<GameObject>();

        int rowStart = (selectedTileRow - 2);
        int rowEnd = (selectedTileRow + 2);

        int colStart = (selectedTileCol - 2);
        int colEnd = (selectedTileCol + 2);

        Debug.Log("Selected Row: " + selectedTileRow);
        Debug.Log("Selected Column: + " + selectedTileCol);

        Debug.Log("Row Start: " + rowStart + " Row End: " + rowEnd);
        Debug.Log("Col Start: " + colStart + " Col End: " + colEnd);


        for (int i = rowStart; i <= rowEnd; i++)
        {
            for (int j = colStart; j <= colEnd; j++)
            {

                Debug.Log("I :" + i + " J: " + j);


                if (i >= 0 && i < GridRowSize && j >= 0 && j < GridColumnSize)
                {
                    revealTiles.Add(grid[i, j]);
                }
            }
        }

        foreach (GameObject tile in revealTiles)
        {
            Tile tileComp = tile.GetComponent<Tile>();
                tileComp.RevealTile();
        }
    }
}
