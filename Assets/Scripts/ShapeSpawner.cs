using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    public GameObject circlePrefab; 
    public GameObject squarePrefab;
    public GameObject temp;
    public int circles = 0; // num of circles
    public int squares = 0; // num of squares

    private float spawnCooldown = 1f; 
    private float nextSpawnTime = 1f; 
    public ColorChangeForBeat color; // reference to the colorchangeforthebeat class

    private float prevPrefabPos = -300.0f;

    private OrderManager om;

    void Start()
    {
        color = FindObjectOfType<ColorChangeForBeat>();

        if (color == null)
        {
            Debug.LogError("ColorChangeForBeat not found in the scene!");
        }

        om = FindObjectOfType<OrderManager>();


    }


    void Update()
    {
        if (circles + squares > 5 || om.isCleared == true)
        {
            Debug.Log("Too many elements");
            prevPrefabPos = -300.0f;
            // clear all elements
            om.RemoveShapes(circles, squares);
            circles = 0;
            squares = 0;
            om.isCleared = false;
        }

        if (Time.time >= nextSpawnTime && color.canSpawnCircle) 
        {
            SpawnShape(circlePrefab);
            nextSpawnTime = Time.time + spawnCooldown; 
            color.canSpawnCircle = false;
            circles += 1;
        }

        
        if (Time.time >= nextSpawnTime && color.canSpawnSquare) 
        {
            SpawnShape(squarePrefab);
            nextSpawnTime = Time.time + spawnCooldown; 
            color.canSpawnSquare = false;
            squares += 1; 
        }
    }

    private void SpawnShape(GameObject prefab)
    {
        

        var someGameObject = GameObject.Find("ShootButton");
        Vector3 buttonPosition = someGameObject.GetComponent<RectTransform>().anchoredPosition;
        //Debug.Log("Button Position: " + buttonPosition);

       // Vector3 mousePosition = Input.mousePosition;
       //mousePosition.z = 10f; 

        
       //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(buttonPosition);

        Vector3 toPlace = new Vector3(buttonPosition.x + prevPrefabPos, buttonPosition.y + 150.0f, 0f);
        //Debug.Log("Shape Position: " + toPlace);
        // increment 
        prevPrefabPos += 65.0f;
        //Debug.Log("PrevFabBos: " + prevPrefabPos);


        //if (circles + squares > 5)
        //{
        //    Debug.Log("Too many elements");
        //    prevPrefabPos = -300.0f;
        //    // clear all elements
        //    om.RemoveShapes(circles, squares);
        //    circles = 0;
        //    squares = 0;
        //}
        //else
        //{
        //    temp = Instantiate(prefab, new Vector3(toPlace.x, toPlace.y, 0), Quaternion.identity) as GameObject;
        //    temp.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        //}

        temp = Instantiate(prefab, new Vector3(toPlace.x, toPlace.y, 0), Quaternion.identity) as GameObject;
        temp.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

    }
}