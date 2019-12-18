using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChanger : MonoBehaviour
{
    public Tilemap tileMap;
    public Sprite[] builderBlocks;

    public void Update()
    {
        bool isBuilderModeEnable = GameObject.FindGameObjectWithTag("BuilderStatus").GetComponent<BuilderStatus>().IsBuilderModeEnable;
        if (Input.GetMouseButtonDown(0) && isBuilderModeEnable) {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = tileMap.WorldToCell(mouseWorldPos);


            var tile = ScriptableObject.CreateInstance<Tile>();
            tile.sprite = builderBlocks[0];
            
            tileMap.SetTile(coordinate, tile);
        }
    }
}
