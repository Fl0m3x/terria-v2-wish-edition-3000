using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class terraingeneral : MonoBehaviour
{
    public int dirtLayerHeight = 5;
   
    public Sprite dirt;
    public Sprite grass;
    public Sprite stone;

    public float surfaceValue = 0.25f;
    public Sprite tile;
    public int worldSize = 100;
    public float CaveFreq = 0.05f;
    public float terrainFreq = 0.05f;
    public float heightMultiplier = 4f;
    public float seed;
    public int heightaddition = 25;
    public Texture2D noiseTexture;


    void Start()
    {
        seed = Random.Range(-1000, 1000);
        GenerateNoiseTexture();
        generateTerrain();
    }
    //labas asdasdae qweqwe
    public void generateTerrain()
    {
        for (int x = 0; x < worldSize; x++)
        {
            float height = Mathf.PerlinNoise((x + seed) * terrainFreq, seed * terrainFreq) * heightMultiplier + heightaddition;
            for (int y = 0; y < height; y++)
            {
                Sprite tilesprite = stone;

                if (y < height - dirtLayerHeight)
                {
                
                }
                if (noiseTexture.GetPixel(x, y).r > surfaceValue)
                {
                    GameObject newTile = new GameObject();
                    newTile.transform.parent = this.transform;
                    newTile.AddComponent<SpriteRenderer>();
                    newTile.GetComponent<SpriteRenderer>().sprite = stone;
                   
                    newTile.transform.position = new Vector2(x, y);
                }
            }
        }
    }
    public void GenerateNoiseTexture()
    {
        noiseTexture = new Texture2D(worldSize, worldSize);
        for (int x = 0; x < noiseTexture.width; x++)
        {
            for (int y = 0; y < noiseTexture.height; y++)
            {
                float v = Mathf.PerlinNoise((x + seed) * CaveFreq, (y + seed) * CaveFreq);
                noiseTexture.SetPixel(x, y, new Color(v, v, v));
            }
        }
        noiseTexture.Apply();
    }
}