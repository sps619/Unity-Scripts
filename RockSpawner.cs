using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A teddy bear spawner
/// </summary>
public class RockSpawner : MonoBehaviour
{
	// needed for spawning
	[SerializeField]
	GameObject prefabGreenRock;
    [SerializeField]
    GameObject prefabMagentaRock;
    [SerializeField]
    GameObject prefabWhiteRock;
    
    // spawn control
    const float MinSpawnDelay = 1;
	const float MaxSpawnDelay = 2;
	Timer spawnTimer;

	// spawn location support
	const int SpawnBorderSize = 100;
	int minSpawnX;
	int maxSpawnX;
	int minSpawnY;
	int maxSpawnY;
    const float MinImpulseForce = 1f;
    const float MaxImpulseForce = 2f;
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        
        // save spawn boundaries for efficiency
        minSpawnX = SpawnBorderSize;
		maxSpawnX = Screen.width - SpawnBorderSize;
		minSpawnY = SpawnBorderSize;
		maxSpawnY = Screen.height - SpawnBorderSize;

		// create and start timer
		spawnTimer = gameObject.AddComponent<Timer>();
		spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
		spawnTimer.Run();

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // check for time to spawn a new teddy bear
        if (spawnTimer.Finished)
        {
			SpawnRock();

			// change spawn timer duration and restart
			spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
			spawnTimer.Run();
		}
        }
	
	/// <summary>
	/// Spawns a new teddy bear at a random location
	/// </summary>
	void SpawnRock()
	{
		// generate random location and create new teddy bear
		Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX),Random.Range(minSpawnY, maxSpawnY),-Camera.main.transform.position.z);
		Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);

        // spawn random prefab
        // int prefabNumber = Random.Range(0, 3);
        int prefabNumber = Random.Range(0,3);
        if (prefabNumber == 0)
        {
            GameObject rock = Instantiate<GameObject>(prefabWhiteRock,worldLocation, Quaternion.identity);
            rock.tag = "countRock";
                
        }
        else if (prefabNumber == 1)
        {
           GameObject rock1 = Instantiate<GameObject>(prefabMagentaRock,worldLocation, Quaternion.identity);
            rock1.tag = "countRock";
      
        }
        else
        {
            GameObject rock2 = Instantiate<GameObject>(prefabGreenRock,worldLocation, Quaternion.identity);
            rock2.tag = "countRock";
          
        }
}
    
}
