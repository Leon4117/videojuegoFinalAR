using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject[] carPrefabs;
    private Vector3 carSpawnPos;
    private float startDelay = 2.0f;
    private float spawnInterval = 2.0f;
    public GameObject[] obstaclePrefabs;
    public GameObject[] powerUpPrefabs; // Array para los prefabs de power ups
    private float spawnPosX;
    private float spawnPosZ;
    private float y = 0.0f;
    public float powerUpSpawnChance = 0.2f; // 20% de probabilidad de que aparezca un power up
    public static SpawnManager Instance;
    private Cronometer time;
    public bool isPlayStart = false;

    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("SpawnRandomCar", startDelay, spawnInterval);
        time = FindObjectOfType<Cronometer>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void SpawnRandomCar() {
        if (isPlayStart && !time.isGameOver)
        {
            carSpawnPos = new Vector3(Random.Range(10.0f, 30.0f), 0, Random.Range(-28.0f, -21.0f));
            int carIndex = Random.Range(0, carPrefabs.Length);
            Instantiate(carPrefabs[carIndex], carSpawnPos, carPrefabs[carIndex].transform.rotation);
        }
    }
  
    private Vector3 GenerateSpawnPosition(int pos){
        var spawnRanges = new (Vector2 xRange, Vector2 zRange)[]{
            (new Vector2(34, 41), new Vector2(-16, 21)),   // Pos 1
            (new Vector2(26, 74), new Vector2(15, 21)),  // Pos 2
            (new Vector2(74, 100), new Vector2(17, 21)), // Pos 3
            (new Vector2(101, 106), new Vector2(17, 29)), // Pos 4
            (new Vector2(106, 149), new Vector2(25, 29)), // Pos 5
            (new Vector2(149, 157), new Vector2(-43, 29)), // Pos 6
            (new Vector2(43, 157), new Vector2(-19, -30))   // Pos 7
        };

        var (xRange, zRange) = spawnRanges[pos - 1];
        float spawnPosX = Random.Range(xRange.x, xRange.y);
        float spawnPosZ = Random.Range(zRange.x, zRange.y);

        float spawnPosY = (powerUpPrefabs != null && powerUpPrefabs.Length > 0) ? 0.5f : y; // 0.5f es la altura recomendada
        return new Vector3(spawnPosX, spawnPosY, spawnPosZ);
    }

    public void SpawnObstacles(){
        if (isPlayStart && !time.isGameOver)
        {
            // Primero decidimos si spawnear un power up en lugar de un obstáculo
            if (ShouldSpawnPowerUp())
            {
                SpawnPowerUp();
                return;
            }

            if (obstaclePrefabs.Length == 0){
                Debug.LogError("No hay prefabs de obstáculos asignados.");
                return;
            }

            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Vector3 spawnPosition = GenerateSpawnPosition(Random.Range(1, 8));
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPosition, obstaclePrefabs[obstacleIndex].transform.rotation);
        }
    }

    private bool ShouldSpawnPowerUp()
    {
        // Verificamos que haya power ups configurados y que el random cumpla con la probabilidad
        return powerUpPrefabs != null && 
               powerUpPrefabs.Length > 0 && 
               Random.value <= powerUpSpawnChance;
    }

    private void SpawnPowerUp()
    {
        int powerUpIndex = Random.Range(0, powerUpPrefabs.Length);
        Vector3 spawnPosition = GenerateSpawnPosition(Random.Range(1, 8));
        Instantiate(powerUpPrefabs[powerUpIndex], spawnPosition, powerUpPrefabs[powerUpIndex].transform.rotation);
    }

    private void Awake(){
        if (Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
}