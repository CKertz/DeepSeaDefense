using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile
{
    private Action<Tile> tileTypeChangedCallBack;
    
    public enum TileType
    {     
        Empty,
        Occupied,
        HotSpot
    };

    public TileType Type
    {
        get { return type; }
        set
        {
            type = value;
            //Call the callback
            if(tileTypeChangedCallBack!= null)
                tileTypeChangedCallBack(this);
        }
    }

    private InstalledObject _installedObject;
    TileType type = TileType.Empty;
    private int x;

    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    private int y;
    private World world;
    public Tile(World world,int x, int y)
    {
        this.world = world;
        this.x = x;
        this.y = y;
    }

    public void RegisterTileTypeChangedCallback(Action<Tile> callback)
    {
        tileTypeChangedCallBack += callback;
    }

    public void UnregisterTileTypeChangedCallback(Action<Tile> callback)
    {
        tileTypeChangedCallBack -= callback;
    }
}
