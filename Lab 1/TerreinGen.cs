using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TerreinGen : MonoBehaviour
{
    public Text widthCan, heightCan, scaleCan, offsetXCan, offsetYCan, noiseIntensityCan;


    private int width = 512;       // Width of the terrain
    private int height = 512;      // Height of the terrain
    private float scale = 10f;     // Scale of the terrain
    private float offsetX = 100f;  // X offset for noise
    private float offsetY = 100f;  // Y offset for noise
    private float noiseIntensity = 0.1f; //Intensity of the noise
    Terrain terrain;
    //Renderer render;
   // public Material material;

    private void Start()
    {
        terrain = GetComponent<Terrain>();
        //render = GetComponent<Renderer>();
        //render.material = material;

        NewTerrain();

        OnRenameInfo();
    }
    private void NewTerrain() {

        // Створення нового екземпляра TerrainData
        TerrainData terrainData = new TerrainData();
        // Встановити роздільну здатність карти висот і розмір TerrainData
        terrainData.heightmapResolution = width;
        terrainData.size = new Vector3(width, 600, height);

        // Створення висот рельєфу
        float[,] heights = GenerateHeights();
        terrainData.SetHeights(0, 0, heights);

        terrain.terrainData = terrainData;

    }

    private void OnRenameInfo()
    {
        widthCan.text = width.ToString();
        heightCan.text = height.ToString();
        scaleCan.text = scale.ToString();
        offsetXCan.text = offsetX.ToString();
        offsetYCan.text = offsetY.ToString();
        noiseIntensityCan.text = noiseIntensity.ToString();
    }
    private float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Створення значення шуму Perlin для поточної позиції
                float xCoord = (float)x / width * scale + offsetX;
                float yCoord = (float)y / height * scale + offsetY;
                float noiseValue = Mathf.PerlinNoise(xCoord, yCoord);

                //Встановіть висоту рельєфу на основі рівня шуму
                heights[x, y] = noiseValue * noiseIntensity;
            }
        }

        return heights;
    }

    public void ButtonClick(bool triger, int inf)
    {
        switch (inf)
        {
            case 3: if (triger) scale++; else scale--; break;
            case 4: if (triger) offsetX++; else offsetX--; break;
            case 5: if (triger) offsetY++; else offsetY--; break;
            case 6: if (triger) noiseIntensity += 0.01f; else noiseIntensity -= 0.01f; break;
        }
        NewTerrain();

        OnRenameInfo();
    }
    public void ButtonNext(int inf)
    {
        ButtonClick(true, inf);
    }
    public void ButtonPrev(int inf)
    {
        ButtonClick(false, inf);
    }
}

