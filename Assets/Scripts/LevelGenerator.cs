using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float levelY = -3f;
    private float levelYlast = -3f;
    public int levelType = 0;

    public GameObject floorPrefab;    
    public GameObject ball;
    public CloudSpawner cloudSpawnerScript;
    public float minX = -11.5f;
    public float maxX = 11.5f;
    public float gapLength = 2.0f;

    public GameObject liftLevelPrefab;

    public GameObject liftPressLevelPrefab;

    private void Update()
    {
        if (levelY != levelYlast)
        {
            levelYlast = levelY;
            levelType = Random.Range(0, 3);
        }

        if (ball.transform.position.y < levelY + 12.0f)
        {
            cloudSpawnerScript.SpawnCloud();
            switch (levelType)
            {
                case 0:
                    FloorSpawn();
                    levelY -= 3.0f;
                    break;
                case 1:
                    LiftSpawn();
                    levelY -= 3.0f;
                    cloudSpawnerScript.SpawnCloud();
                    levelY -= 3.0f;
                    cloudSpawnerScript.SpawnCloud();
                    levelY -= 3.0f;
                    break;
                case 2:
                    LiftPressSpawn();
                    levelY -= 3.0f;
                    cloudSpawnerScript.SpawnCloud();
                    levelY -= 3.0f;
                    cloudSpawnerScript.SpawnCloud();
                    levelY -= 3.0f;
                    break;
            }
                        
        }
    }

    private void LiftSpawn()
    {
        float randomValue = Random.Range(0, 2);
        float xPos = (randomValue == 0) ? -15f : 15f;
        GameObject lift = Instantiate(liftLevelPrefab, new Vector3(xPos, levelY, 0), Quaternion.identity);
        if (xPos == -15f)
        {
            lift.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void LiftPressSpawn()
    {
        float randomValue = Random.Range(0, 2);
        float xPos = (randomValue == 0) ? -15f : 15f;
        GameObject lift = Instantiate(liftPressLevelPrefab, new Vector3(xPos, levelY, 0), Quaternion.identity);
        if (xPos == -15f)
        {
            lift.transform.rotation = Quaternion.Euler(0, 180, 0);
        }        
    }

    private void FloorSpawn()
    {
        float y = levelY;

        // Generate the first cube
        float sizeX = Random.Range(0, maxX - minX - gapLength);
        sizeX = Mathf.Round(sizeX * 2) / 2;

        if (sizeX != 0f)
        {
            // Calculate the position for the cube
            Vector3 firstCubePosition = new Vector3((sizeX / -2 + 11.5f) * -1, y, 0);

            // Create a new cube GameObject at the desired position
            GameObject firstCube = Instantiate(floorPrefab, firstCubePosition, Quaternion.identity);

            // Scale the cube along the X axis based on the random size
            firstCube.transform.localScale = new Vector3(sizeX, firstCube.transform.localScale.y, firstCube.transform.localScale.z);
        }



        // Generate the second cube

        sizeX = maxX - minX - gapLength - sizeX;


        if (sizeX != 0f)
        {
            // Calculate the position for the cube
            Vector3 secondCubePosition = new Vector3((sizeX / -2 + 11.5f), y, 0);

            // Create a new cube GameObject at the desired position
            GameObject secondCube = Instantiate(floorPrefab, secondCubePosition, Quaternion.identity);

            // Scale the cube along the X axis based on the random size
            secondCube.transform.localScale = new Vector3(sizeX, secondCube.transform.localScale.y, secondCube.transform.localScale.z);
        }        
    }
}