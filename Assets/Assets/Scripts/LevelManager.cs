using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] tilePrefabs;
    
    public Dictionary<Point,TileScript> Tiles { get; set; }
    private Point subSpawn, subWorkAreaSpawn;
    [SerializeField]
    private GameObject submarinePrefab;
    public float TileSize
    {
        get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }//we pick the first one in array, since all tiles are 32x32 
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
        Tiles = new Dictionary<Point, TileScript>();
        string[] mapData = readLevelText();

        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;
        
        //Lay gray ground tiles
        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        for (int y = 0; y < mapY; y++)
        {
            char[] newTiles = mapData[y].ToCharArray();//Take each character in mapData
            for (int x = 0; x < mapX; x++)
            {
                PlaceTile(newTiles[x].ToString(),x,y, worldStart);
            }
        }
        spawnSubMarine();//temp

    }
    private void PlaceTile(string tileType,int x, int y, Vector3 worldStart)
    {
        int tileIndex = int.Parse(tileType);
        TileScript newTile = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScript>();
        newTile.Setup(new Point(x,y),new Vector3(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y), 0));
        Tiles.Add(new Point(x,y),newTile);
        
    }

    private string[] readLevelText()
    {
        TextAsset data = Resources.Load("Room") as TextAsset;

        //Parsing Room.txt to give commands for level layout
        string tmp = data.text.Replace(Environment.NewLine, String.Empty);
        return tmp.Split('-');
    }

    private void spawnSubMarine()
    {
        subSpawn = new Point(10,4);
        Instantiate(submarinePrefab, Tiles[subSpawn].GetComponent<TileScript>().RoomPosition, Quaternion.identity);
    }
}
