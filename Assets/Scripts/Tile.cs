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
    public TileType tileType;

    public GameObject maxResourceIcon;
    public GameObject halfResourceIcon;
    public GameObject quartResourceIcon;
    public GameObject minResourceIcon;

    private int resourceValue;
    private BoxCollider2D boxCollider2D;

    public SpriteRenderer spriteRenderer;

    public Color MaxColor;
    public Color HalfColor;
    public Color QuartColor;
    public Color MinimumColor;

    private int RowNum;
    private int ColumnNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetToMinimal()
    {
        spriteRenderer.color = MinimumColor;
        tileType = TileType.MIN;
    }

    public void ChangeToMax()
    {
        spriteRenderer.color = MaxColor;
        tileType = TileType.MAX;
    }

    public void ChangeToHalf()
    {
        spriteRenderer.color = HalfColor;
        tileType = TileType.HALF;
    }

    public void ChangeToQuart()
    {
        spriteRenderer.color = QuartColor;
        tileType = TileType.QUART;
    }
}
