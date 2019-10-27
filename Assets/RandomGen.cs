using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGen : MonoBehaviour {
    public Transform treePreFab1;
    public Transform treePreFab2;
    public Transform treePreFab3;
    public Transform treePreFab4;
    public Transform treePinePreFab1;
    public Transform treePinePreFab2;
    public Transform treePinePreFab3;
    public Transform treePinePreFab4;
    public Transform treeDeadPreFab1;
    public Transform treeDeadPreFab2;
    public Transform treeDeadPreFab3;
    public Transform treeDeadPreFab4;
    public Transform rockPreFab1;
    public Transform rockPreFab2;
    public Transform rockPreFab3;
    public Transform rockPreFab4;
    public Transform plantPreFab1;
    public Transform plantPreFab2;
    public Transform plantPreFab3;
    public Transform plantPreFab4;
    public Transform tallPlantPreFab1;
    public Transform tallPlantPreFab2;
    public Transform PlanePrefab;
    public Transform SwampPrefab;
    public Transform BeaverLodgePrefab;
    public Transform RabbitWarrenPrefab;
    public Transform CampGroundPrefab;
    public Transform BeaverPrefab;
    public Transform RabbitPrefab;
    public Transform MoosePrefab;
    public Transform WolfPrefab;
    public Transform skyboxPrefab;
    public Transform WolfDenPrefab;
    public float  GenerationDimensionCal = 150;
    public float MapScaleFactor = 40;
    public int NumberOfPlantsCal = 3000;
    public int NumberOfTreesCal = 150;
    public int NumberOfRocksCal = 400;
    public int NoOfBeaverGroupsCal = 5;
    public int BeaversPerGroupCal = 8;
    public int NoOfRabbitsGroupsCal = 5;
    public int RabbitsPerGroupCal = 8;
    public int NoOfMooseGroupsCal = 5;
    public int MoosePerGroupCal = 8;
    public int NoOfWolvesGroupsCal = 5;
    public int WolvesPerGroupCal = 8;
    public float POIDistanceCal = 200;
    public static int gameStartOverFlag = 0;
    float gameTimeCounter = 0;


    List<Vector3> POIList = new List<Vector3>();    // list of POI locations

    // generate a random location on the map and search through list of existing POIs to be sure it is far enough away
    // from existing POIs
    private Vector3 GetNewPOILocation(float rangeScale)
    {
        int k, l, m = 0;
        Vector3 position = new Vector3(0f,0f,0f);

        k = 0;
        while (k <= 10)                  // use proposed position after 10 tries (give up finding open space)
        {
            // generate proposed POI location
            position = new Vector3(Random.Range(GenerationDimensionCal * -rangeScale, GenerationDimensionCal * rangeScale), 0, Random.Range(GenerationDimensionCal * -rangeScale, GenerationDimensionCal * rangeScale));
            // determine if any existing POI is too close to the proposed new POI location
            // print("DEBUG1 List Size " + POIList.Count);
            m = 1;
            for (l = 0; l < POIList.Count; l++)
            {
                if (Vector3.Distance(position, POIList[l]) < POIDistanceCal)
                {
                    m = 0;
                    // print("Position " + position + " Existing POI: " + POIList[l] + " Distance " + Vector3.Distance(position, POIList[l]));
                }
            }

            // use proposed position if no POIs have been found to be too close
            if (m == 1)
            {
                print("Valid POI Location Found " + (k+1) + " Tries");
                break;
            }
            k++;
        }

        if (m != 1) print("No Valid POI Location Found");
        return position;
    }

    // Use this for initialization
    void Start () {
        int i, j, k, l, m;
        int biome = 0;  // binary to choose tree type for transition biomes
        float offsetX, offsetZ;
        float TopBiome, TopTransBiome, MiddleBiome, BottomTransBiome;
        Vector3 position, groupPosition;
        Transform GroundPlane;

        for (i = 0; i < POIList.Count; i++)
            print("List Example " + i + " " + POIList[i]);

        TopBiome = GenerationDimensionCal * 0.7f;           // top 15% of map
        TopTransBiome = GenerationDimensionCal * 0.2f;      // Next 15% of map
        MiddleBiome = GenerationDimensionCal * -0.6f;       // middle 40% of map
        BottomTransBiome = GenerationDimensionCal * -0.9f;  // next 15% of map


        position = new Vector3(0, 150f, 0);
        Instantiate(skyboxPrefab, position, Quaternion.identity);
        position = new Vector3(0, 0, 0);
        GroundPlane = Instantiate(PlanePrefab, position, Quaternion.identity);
        GroundPlane.localScale = new Vector3(MapScaleFactor, 5.81f, MapScaleFactor);

        for (i = 1; i <= NumberOfPlantsCal; i++)
        {
            j = Random.Range(1, 7);
            switch (j)
            {
                case 1:
                    position = new Vector3(Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal), 0, Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal));
                    Instantiate(plantPreFab1, position, Quaternion.identity);
                    break;
                case 2:
                    position = new Vector3(Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal), 0, Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal));
                    Instantiate(plantPreFab2, position, Quaternion.identity);
                    break;
                case 3:
                    position = new Vector3(Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal), 0, Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal));
                    Instantiate(plantPreFab3, position, Quaternion.identity);
                    break;
                case 4:
                    position = new Vector3(Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal), 0, Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal));
                    Instantiate(plantPreFab4, position, Quaternion.identity);
                    break;
                case 5:
                    position = new Vector3(Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal), 0, Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal));
                    Instantiate(tallPlantPreFab1, position, Quaternion.identity);
                    break;
                case 6:
                    position = new Vector3(Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal), 0, Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal));
                    Instantiate(tallPlantPreFab2, position, Quaternion.identity);
                    break;
            }
        }

        for (i = 1; i <= NumberOfTreesCal; i++)
        {
            j = Random.Range(1, 5);
            switch (j)
            {
                case 1:
                    position = new Vector3(Random.Range(GenerationDimensionCal * -1.3f, GenerationDimensionCal * 1.3f), 0, Random.Range(GenerationDimensionCal * -1.3f, GenerationDimensionCal) * 1.3f);
                    if (position.x >= TopBiome) 
                        Instantiate(treePinePreFab1, position, Quaternion.identity);
                    else if (position.x >= TopTransBiome)
                    {
                        biome = Random.Range(0, 2);
                        if (biome == 0)
                            Instantiate(treePreFab1, position, Quaternion.identity);
                        else
                            Instantiate(treePinePreFab1, position, Quaternion.identity);
                    }
                    else if (position.x >= MiddleBiome)
                        Instantiate(treePreFab1, position, Quaternion.identity);
                    else if (position.x >= BottomTransBiome)
                    {
                        biome = Random.Range(0, 2);
                        if (biome == 0)
                            Instantiate(treePreFab1, position, Quaternion.identity);
                        else
                            Instantiate(treeDeadPreFab1, position, Quaternion.identity);
                    }
                    else
                        Instantiate(treeDeadPreFab1, position, Quaternion.identity);
                    break;
                case 2:
                    position = new Vector3(Random.Range(GenerationDimensionCal * -1.3f, GenerationDimensionCal * 1.3f), 0, Random.Range(GenerationDimensionCal * -1.3f, GenerationDimensionCal) * 1.3f);
                    if (position.x >= TopBiome)
                        Instantiate(treePinePreFab2, position, Quaternion.identity);
                    else if (position.x >= TopTransBiome)
                    {
                        biome = Random.Range(0, 2);
                        if (biome == 0)
                            Instantiate(treePreFab2, position, Quaternion.identity);
                        else
                            Instantiate(treePinePreFab2, position, Quaternion.identity);
                    }
                    else if (position.x >= MiddleBiome)
                        Instantiate(treePreFab2, position, Quaternion.identity);
                    else if (position.x >= BottomTransBiome)
                    {
                        biome = Random.Range(0, 2);
                        if (biome == 0)
                            Instantiate(treePreFab2, position, Quaternion.identity);
                        else
                            Instantiate(treeDeadPreFab2, position, Quaternion.identity);
                    }
                    else
                        Instantiate(treeDeadPreFab2, position, Quaternion.identity);
                    break;
                case 3:
                    position = new Vector3(Random.Range(GenerationDimensionCal * -1.3f, GenerationDimensionCal * 1.3f), 0, Random.Range(GenerationDimensionCal * -1.3f, GenerationDimensionCal * 1.3f));
                    if (position.x >= TopBiome)
                        Instantiate(treePinePreFab3, position, Quaternion.identity);
                    else if (position.x >= TopTransBiome)
                    {
                        biome = Random.Range(0, 2);
                        if (biome == 0)
                            Instantiate(treePreFab3, position, Quaternion.identity);
                        else
                            Instantiate(treePinePreFab3, position, Quaternion.identity); 
                    }
                    else if (position.x >= MiddleBiome)
                        Instantiate(treePreFab3, position, Quaternion.identity);
                    else if (position.x >= BottomTransBiome)
                    {
                        biome = Random.Range(0, 2);
                        if (biome == 0)
                            Instantiate(treePreFab3, position, Quaternion.identity);
                        else
                            Instantiate(treeDeadPreFab3, position, Quaternion.identity); 
                    }
                    else
                        Instantiate(treeDeadPreFab3, position, Quaternion.identity);
                    break;
                case 4:
                    position = new Vector3(Random.Range(GenerationDimensionCal * -1.3f, GenerationDimensionCal * 1.3f), 0, Random.Range(GenerationDimensionCal * -1.3f, GenerationDimensionCal * 1.3f));
                    if (position.x >= TopBiome)
                        Instantiate(treePinePreFab4, position, Quaternion.identity);
                    else if (position.x >= TopTransBiome)
                    {
                        biome = Random.Range(0, 2);
                        if (biome == 0)
                            Instantiate(treePreFab4, position, Quaternion.identity);
                        else
                            Instantiate(treePinePreFab4, position, Quaternion.identity);
                    }
                    else if (position.x >= MiddleBiome)
                        Instantiate(treePreFab4, position, Quaternion.identity);
                    else if (position.x >= BottomTransBiome)
                    {
                        biome = Random.Range(0, 2);
                        if (biome == 0)
                            Instantiate(treePreFab4, position, Quaternion.identity);
                        else
                            Instantiate(treeDeadPreFab4, position, Quaternion.identity);
                    }
                    else
                        Instantiate(treeDeadPreFab4, position, Quaternion.identity);
                    break;
            }
        }

        for (i = 1; i <= NumberOfRocksCal; i++)
        {
            j = Random.Range(1, 5);
            switch (j)
            {
                case 1:
                    position = new Vector3(Random.Range(GenerationDimensionCal * -1.3f, GenerationDimensionCal * 1.3f), 0, Random.Range(GenerationDimensionCal * -1.3f, GenerationDimensionCal * 1.3f));
                    Instantiate(rockPreFab1, position, Quaternion.identity);
                    break;
                case 2:
                    position = new Vector3(Random.Range(GenerationDimensionCal * -1.3f, GenerationDimensionCal * 1.3f), 0, Random.Range(GenerationDimensionCal * -1.3f, GenerationDimensionCal * 1.3f));
                    Instantiate(rockPreFab2, position, Quaternion.identity);
                    break;
                case 3:
                    position = new Vector3(Random.Range(GenerationDimensionCal * -1.3f, GenerationDimensionCal * 1.3f), 0, Random.Range(GenerationDimensionCal * -1.3f, GenerationDimensionCal * 1.3f));
                    Instantiate(rockPreFab3, position, Quaternion.identity);
                    break;
                case 4:
                    position = new Vector3(Random.Range(GenerationDimensionCal * -1.3f, GenerationDimensionCal * 1.3f), 0, Random.Range(GenerationDimensionCal * -1.3f, GenerationDimensionCal * 1.3f));
                    Instantiate(rockPreFab4, position, Quaternion.identity);
                    break;
            }
        }

        // Add POIs that are not directly associated with a type of animal 
        position = new Vector3(Random.Range(GenerationDimensionCal * -.8f, GenerationDimensionCal * 0.8f), 0, Random.Range(GenerationDimensionCal * -.8f, GenerationDimensionCal * 0.8f));
        POIList.Add(position);
        Instantiate(SwampPrefab, position, Quaternion.identity);

        position = GetNewPOILocation(0.8f);
        POIList.Add(position);
        Instantiate(SwampPrefab, position, Quaternion.identity);

        position = GetNewPOILocation(0.8f);
        POIList.Add(position);
        Instantiate(SwampPrefab, position, Quaternion.identity);

        position = GetNewPOILocation(0.8f);
        POIList.Add(position);
        Instantiate(CampGroundPrefab, position, Quaternion.identity);

        for (i = 1; i <= NoOfBeaverGroupsCal; i++)
        {
            // groupPosition = new Vector3(Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal), 0, Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal));
            groupPosition = GetNewPOILocation(1.0f);
            POIList.Add(groupPosition);
            Vector3 lodgePosition = new Vector3(groupPosition.x + 40.0f, groupPosition.y, groupPosition.z);
            Instantiate(BeaverLodgePrefab, lodgePosition, Quaternion.identity);
            for (j =  1; j <= BeaversPerGroupCal; j++)
            {
                offsetX = (float) Random.Range(-4, 4);
                offsetZ = (float)Random.Range(-4, 4);
                position = new Vector3(groupPosition.x + offsetX, 0.4f, groupPosition.z + offsetZ);
                Instantiate(BeaverPrefab, position, Quaternion.identity);
            }
        }

        for (i = 1; i <= NoOfRabbitsGroupsCal; i++)
        {
            // groupPosition = new Vector3(Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal), 0, Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal));
            groupPosition = GetNewPOILocation(1.0f);
            POIList.Add(groupPosition);
            Vector3 warrenPosition = new Vector3(groupPosition.x, groupPosition.y+0.3f, groupPosition.z);
            Instantiate(RabbitWarrenPrefab, warrenPosition, Quaternion.identity);
            for (j = 1; j <= RabbitsPerGroupCal; j++)
            {
                offsetX = (float)Random.Range(-4, 4);
                offsetZ = (float)Random.Range(-4, 4);
                position = new Vector3(groupPosition.x + offsetX, 0.4f, groupPosition.z + offsetZ);
                Instantiate(RabbitPrefab, position, Quaternion.identity);
            }
        }

        for (i = 1; i <= NoOfMooseGroupsCal; i++)
        {
            // groupPosition = new Vector3(Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal), 0, Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal));
            groupPosition = GetNewPOILocation(1.0f);
            POIList.Add(groupPosition);
            for (j = 1; j <= MoosePerGroupCal; j++)
            {
                offsetX = (float)Random.Range(-5, 5);
                offsetZ = (float)Random.Range(-5, 5);
                position = new Vector3(groupPosition.x + offsetX, -0.2f, groupPosition.z + offsetZ);
                Instantiate(MoosePrefab, position, Quaternion.identity);
            }
        }

        for (i = 1; i <= NoOfWolvesGroupsCal; i++)
        {
            // groupPosition = new Vector3(Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal), 0, Random.Range(GenerationDimensionCal * -1, GenerationDimensionCal));
            groupPosition = GetNewPOILocation(1.0f);
            POIList.Add(groupPosition);
            Vector3 denPosition = new Vector3(groupPosition.x, groupPosition.y + 0.3f, groupPosition.z);
            Instantiate(WolfDenPrefab, denPosition, Quaternion.identity);
            for (j = 1; j <= WolvesPerGroupCal; j++)
            {
                offsetX = (float)Random.Range(-4, 4);
                offsetZ = (float)Random.Range(-4, 4);
                position = new Vector3(groupPosition.x + offsetX, -0.4f, groupPosition.z + offsetZ);
                Instantiate(WolfPrefab, position, Quaternion.identity);
            }
        }
    }

    private void Update()
    {
        gameTimeCounter += Time.deltaTime;
        if (gameTimeCounter > 180)
            gameStartOverFlag = 1;
    }
}
