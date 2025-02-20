using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    public GameObject circlePrefab; // 圆形预制件
    public GameObject squarePrefab; // 方形预制件

    private bool canSpawnCircle = true; // 控制是否可以生成圆形
    private bool canSpawnSquare = true; // 控制是否可以生成方形
    private float spawnCooldown = 1f; // 生成冷却时间
    private float nextSpawnTime = 1f; // 下次生成时间

    void Update()
    {
        // 检测键盘按下1键
        if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time >= nextSpawnTime) // 按下1键
        {
            SpawnShape(circlePrefab);
            nextSpawnTime = Time.time + spawnCooldown; // 设置下次生成时间
        }

        // 检测键盘按下2键
        if (Input.GetKeyDown(KeyCode.Alpha2) && Time.time >= nextSpawnTime) // 按下2键
        {
            SpawnShape(squarePrefab);
            nextSpawnTime = Time.time + spawnCooldown; // 设置下次生成时间
        }
    }

    private void SpawnShape(GameObject prefab)
    {
        // 获取鼠标位置
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // 设置z轴以确保摄像机可以看到

        // 将鼠标位置转换为世界坐标
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // 实例化预制件
        Instantiate(prefab, new Vector3(worldPosition.x, worldPosition.y, 0), Quaternion.identity);
    }
}