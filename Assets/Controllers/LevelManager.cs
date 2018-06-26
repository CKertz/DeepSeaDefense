﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private GameObject tile;

    public float TileSize
    {
        get { return tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }
	// Use this for initialization
	void Start () {
        CreateLevel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CreateLevel()
    {
        //Lay gray ground tiles
        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        for (int y = 0; y < 30; y++)
        {
            for (int x = 0; x < 30; x++)
            {
                PlaceTile(x,y, worldStart);
            }
        }
        //Lay hotspot tiles

    }
    private void PlaceTile(int x, int y, Vector3 worldStart)
    {
        GameObject newTile = Instantiate(tile);
        newTile.transform.position = new Vector3(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y), 0);
    }          
}