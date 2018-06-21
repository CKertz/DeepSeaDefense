using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
	public Sprite floorSprite;
	private World world;
	// Use this for initialization
	void Start()
	{
		world = new World();
		
		//Create GameObject for each tile
		for (int x = 0; x < world.Width; x++)
		{
			for (int y = 0; y < world.Height; y++)
			{			
				Tile tileData = world.GetTileAt(x, y);
				
				GameObject tile_go = new GameObject();
				tile_go.name = "Tile_" + x + "_" + y;
				tile_go.transform.position = new Vector3(tileData.X,tileData.Y,0);
				
				tile_go.AddComponent<SpriteRenderer>();
				
				tileData.RegisterTileTypeChangedCallback((tile) => {OnTileTypeChanged(tile,tile_go);});
			}
		}
		world.RandomizeTiles();

	}

	private float randomizeTileTimer = 2f;
	// Update is called once per frame
	void Update ()
	{
		randomizeTileTimer -= Time.deltaTime;

		if (randomizeTileTimer < 0)
		{
			world.RandomizeTiles();
			randomizeTileTimer = 2f;
		}
	}

	void OnTileTypeChanged(Tile tileData, GameObject tileGameObject)
	{
		if (tileData.Type == Tile.TileType.Occupied)
		{
			tileGameObject.GetComponent<SpriteRenderer>().sprite = floorSprite;
		}
		else if (tileData.Type == Tile.TileType.Empty)
		{
			tileGameObject.GetComponent<SpriteRenderer>().sprite = null;
		}
		else
		{
			Debug.LogError("OnTileTypeChanged - Unrecognized tile type");
		}
	}
}
