using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public Texture terrainTexture;

    public GameObject water;

    public int textureXtiling = 20;
    public int textureYtiling = 20;

    public int depth = 20;

    public int width = 256;
    public int height = 256;

    public float scale = 20;

    public float offsetX = 100f;
    public float offsetY = 100f;

    public float waterheight;

    private void Start()
    {
        offsetX = Random.Range(0f, 9999f);
        offsetY = Random.Range(0f, 9999f);

        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);

        GenerateWater();
    }
    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;

        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }
    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }
        return heights;
    }
    float CalculateHeight (int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }

    Texture GenerateTexture(int Xtiling, int Ytiling)
    {
        Texture generatedTexture = terrainTexture;
        return generatedTexture;
    }
    void GenerateWater()
    {
        water.transform.localScale= new Vector3(width / 10, 1, height / 10);
        water.transform.position = transform.position + new Vector3(width /2, waterheight, height/2);
    }
}
