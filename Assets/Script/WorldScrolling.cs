using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScrolling : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector2Int currentTilePosition = new Vector2Int(0,0);
    [SerializeField] Vector2Int playerTilePosition;
    Vector2Int onTileGridPlayerPosition;
    [SerializeField] float tileSize = 20f;
    GameObject[,] terrainTiles;

    [SerializeField] int terrainTileHorizontal;
    [SerializeField] int terrainTileVertical;
    // Start is called before the first frame update

    private void Awake()
    {
        terrainTiles = new GameObject[terrainTileHorizontal, terrainTileVertical];
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        playerTilePosition.x = (int)(player.transform.position.x / tileSize);
        playerTilePosition.y = (int)(player.transform.position.y / tileSize);

        if (currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;
            UpdateOnTileGridPlayerPosition();
        }

    }

    private void UpdateOnTileGridPlayerPosition()
    {
        if (onTileGridPlayerPosition.x >= 0)
        {
            onTileGridPlayerPosition.x = playerTilePosition.x % terrainTileHorizontal;
        }
        else
        {
            onTileGridPlayerPosition.x = terrainTileHorizontal - 1 + playerTilePosition.x % terrainTileHorizontal;
        }

        if (onTileGridPlayerPosition.y >= 0)
        {
            onTileGridPlayerPosition.y = playerTilePosition.y % terrainTileVertical;
        }
        else
        {
            onTileGridPlayerPosition.y = terrainTileVertical - 1 + playerTilePosition.y % terrainTileVertical;
        }

    }

    public void Add(GameObject tileGameObject, Vector2Int tilePosition)
    {
        terrainTiles[tilePosition.x, tilePosition.y] = tileGameObject;
    }
}
