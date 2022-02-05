using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    NONE,
    MIN,
    QUART,
    HALF,
    MAX
}

public class Tile : MonoBehaviour
{

    private TileManager tileManager;


    public TileType tileType;

    //public GameObject resourceIcon;
    public SpriteRenderer resourceIconSpriteRender;
    public GameObject coverGameObject;

    public Sprite maxResourceSprite;
    public Sprite halfResourceSprite;
    public Sprite quartResourceSprite;
    public Sprite minResourceSprite;

    private int resourceValue;
  
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider2D;

    public Color MaxColor;
    public Color HalfColor;
    public Color QuartColor;
    public Color MinimumColor;

    private int RowNum;
    private int ColumnNum;

    private bool Revealed;

    // Start is called before the first frame update
    void Start()
    {
        // resourceIconSpriteRender = resourceIcon.GetComponent<SpriteRenderer>();

        tileManager = TileManager.tileManagerInstance;
        Revealed = false;
    }

    // Update is called once per frame
    void Update()
    {

        GameStateId gameStateId = tileManager.gameController.stateMachine.currentState;

        if (gameStateId != GameStateId.IdleState)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos = new Vector2(mousePosition.x, mousePosition.y);

                if (boxCollider2D.bounds.Contains(mousePos))
                {
                    if (gameStateId == GameStateId.ScanState && tileManager.remainingScans > 0)
                    {
                        tileManager.RevealSurroundingTiles(GetRow(), GetColumn());
                    }
                    else if (gameStateId == GameStateId.ExtractState && tileManager.remainingExtracts > 0)
                    {
                        tileManager.ExtractSurroundingTiles(GetRow(), GetColumn());
                    }
                }
            }
        }
    }

    public void SetRowAndColumn(int row, int column)
    {
        RowNum = row;
        ColumnNum = column;
    }

    public int GetRow()
    {
        return RowNum;
    }

    public int GetColumn()
    {
        return ColumnNum;
    }

    public void SetToMinimal(int row, int col)
    {
        SetRowAndColumn(row, col);

        spriteRenderer.color = MinimumColor;
        resourceValue = 25;

        tileType = TileType.MIN;
        resourceIconSpriteRender.sprite = minResourceSprite;
    }

    public void ChangeToMax()
    {
        spriteRenderer.color = MaxColor;
        resourceValue = 400;
        tileType = TileType.MAX;
        resourceIconSpriteRender.sprite = maxResourceSprite;
    }

    public void ChangeToHalf()
    {
        spriteRenderer.color = HalfColor;
        resourceValue = 200;
        tileType = TileType.HALF;
        resourceIconSpriteRender.sprite = halfResourceSprite;
    }

    public void ChangeToQuart()
    {
        spriteRenderer.color = QuartColor;
        tileType = TileType.QUART;
        resourceValue = 100;
        resourceIconSpriteRender.sprite = quartResourceSprite;
    }

    public void ChangeToMinimal()
    {
        spriteRenderer.color = MinimumColor;
        resourceValue = 25;
        tileType = TileType.QUART;
        resourceIconSpriteRender.sprite = minResourceSprite;
    }

    public void RevealTile()
    {
        coverGameObject.SetActive(false);
        Revealed = true;
    }

    public int ExtractResoures()
    {
        //DegradeTile();
        return resourceValue;
    }

    public void DegradeTile()
    {
        if (tileType == TileType.MAX)
        {
            ChangeToHalf();
        }
        else if (tileType == TileType.HALF)
        {
            ChangeToQuart();
        }
        else if (tileType == TileType.QUART)
        {
            ChangeToMinimal();
        }
    }
}
