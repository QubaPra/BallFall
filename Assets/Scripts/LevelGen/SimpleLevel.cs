using UnityEngine;

public class SimpleLevel : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject ball;
    public CurrentLevel currentLevelScript;    
    public CloudSpawner cloudSpawnerScript;    
    public float minX = -11.5f;
    public float maxX = 11.5f;
    public float gapLength = 2.0f;

    private void Start()
    {
        CubesGenerator();
    }
    private void Update()
    {
        if (ball.transform.position.y < currentLevelScript.levelY + 12.0f && currentLevelScript.levelType==0)
        {
            cloudSpawnerScript.SpawnCloud();
            CubesGenerator();            
        }
    }

    private void CubesGenerator()
    {
        float levelY = currentLevelScript.levelY;

        // Generate the first cube
        float sizeX = Random.Range(0, maxX - minX - gapLength);
        sizeX = Mathf.Round(sizeX * 2) / 2;

        if (sizeX!=0f)
        {
            // Calculate the position for the cube
            Vector3 firstCubePosition = new Vector3((sizeX / -2 + 11.5f) * -1, levelY, 0);

            // Create a new cube GameObject at the desired position
            GameObject firstCube = Instantiate(cubePrefab, firstCubePosition, Quaternion.identity);

            // Scale the cube along the X axis based on the random size
            firstCube.transform.localScale = new Vector3(sizeX, firstCube.transform.localScale.y, firstCube.transform.localScale.z);
        }

        

        // Generate the second cube

        sizeX = maxX - minX - gapLength - sizeX;


        if (sizeX!=0f)
        {
            // Calculate the position for the cube
            Vector3 secondCubePosition = new Vector3((sizeX / -2 + 11.5f), levelY, 0);

            // Create a new cube GameObject at the desired position
            GameObject secondCube = Instantiate(cubePrefab, secondCubePosition, Quaternion.identity);

            // Scale the cube along the X axis based on the random size
            secondCube.transform.localScale = new Vector3(sizeX, secondCube.transform.localScale.y, secondCube.transform.localScale.z);
        }
        

        currentLevelScript.levelY -= 3.0f;
    }
}