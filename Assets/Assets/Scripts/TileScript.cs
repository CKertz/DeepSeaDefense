﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

	public Point GridPosition { get; private set; }

	public Vector2 RoomPosition
	{
		get
		{
			return new Vector2(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x/2), transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y/2));
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Setup(Point gridPos, Vector3 roomPos)
	{
		this.GridPosition = gridPos;
		transform.position = roomPos;
	}
}
