using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public Texture2D mapTexture;
    public MapTile[] tileTypes;
    public GameObject floor;

    private Color[,] colorTexture;

    void Start()
    {
        colorTexture = GenerateColorTexture(mapTexture);
        Instatiate3DMap(GenerateMapTiles(colorTexture));
        InstantiateFloor();
    }

    void InstantiateFloor()
    {
        Instantiate(floor, transform.position + new Vector3(mapTexture.width / 2f, 0, mapTexture.height / 2f), Quaternion.identity);
    }

    Color[,] GenerateColorTexture(Texture2D tex)
    {
        Color[,] colors = new Color[tex.width, tex.height];
        for (int x = 0; x < tex.width; x++)
        {
            for (int y = 0; y < tex.height; y++)
            {
                colors[x, y] = tex.GetPixel(x, y);
                print(colors[x, y]);

            }
        }
        return colors;
    }

    MapTile[,] GenerateMapTiles(Color[,] colorTexture)
    {
        MapTile[,] mapTiles = new MapTile[colorTexture.GetLength(0), colorTexture.GetLength(1)];

        for (int x = 0; x < colorTexture.GetLength(0); x++)
        {
            for (int y = 0; y < colorTexture.GetLength(1); y++)
            {
                for (int i = 0; i < tileTypes.Length; i++)
                {
                    if (colorTexture[x, y] == tileTypes[i].color)
                    {
                        print("Tile found");
                        mapTiles[x, y] = tileTypes[i];
                    }
                }

                if (mapTiles[x, y] == null)
                    mapTiles[x, y] = tileTypes[2];
            }
        }

        return mapTiles;
    }

    void Instatiate3DMap(MapTile[,] map)
    {
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                Instantiate(map[x, y].tilePrefab, new Vector3(x, 0, y), Quaternion.identity, transform);
            }
        }
    }


}

[System.Serializable]
public class MapTile
{
    public string name;
    public Color color;
    public GameObject tilePrefab;
}
