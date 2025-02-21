using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    public GameObject circlePrefab; 
    public GameObject squarePrefab; 

    private float spawnCooldown = 1f; 
    private float nextSpawnTime = 1f; 
    public ColorChangeForBeat color; // reference to the colorchangeforthebeat class

    void Start()
    {
      color = FindObjectOfType<ColorChangeForBeat>();

      if (color == null)
     {
        Debug.LogError("ColorChangeForBeat not found in the scene!");
     }
}


    void Update()
    {
        
        if (Time.time >= nextSpawnTime && color.canSpawnCircle) 
        {
            SpawnShape(circlePrefab);
            nextSpawnTime = Time.time + spawnCooldown; 
            color.canSpawnCircle = false;
        }

        
        if (Time.time >= nextSpawnTime && color.canSpawnSquare) 
        {
            SpawnShape(squarePrefab);
            nextSpawnTime = Time.time + spawnCooldown; 
            color.canSpawnSquare = false;
        }
    }

    private void SpawnShape(GameObject prefab)
    {
        
       Vector3 mousePosition = Input.mousePosition;
       mousePosition.z = 10f; 

        
       Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        
        Instantiate(prefab, new Vector3(worldPosition.x, worldPosition.y, 0), Quaternion.identity);

    }
}