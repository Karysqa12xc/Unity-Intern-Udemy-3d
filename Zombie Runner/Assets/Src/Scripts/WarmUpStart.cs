using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmUpStart : MonoBehaviour
{
    [SerializeField] GameObject WarmUpSpawn;
    public GameObject prefab;
    public int numberOfObjects = 10; // Số lượng vật thể cần tạo mỗi đợt
    public int maxObjects = 10; // Số lượng vật thể tối đa cho phép
    public float cylinderHeight = 5f; // Chiều cao của hình trụ
    public float circleRadius = 5f; // Bán kính của vòng tròn
    public Vector3 centerPosition = Vector3.zero; // Tọa độ trung tâm
    public List<GameObject> spawnedObjects = new List<GameObject>(); // Danh sách chứa các vật thể đã tạo
    private bool isInWarmupPlace = false;

    void Update()
    {
        SpawnWave();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            WarmUpSpawn.SetActive(false);
            isInWarmupPlace = true;
            foreach (var obj in spawnedObjects)
            {
                obj.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            WarmUpSpawn.SetActive(true);
            foreach (var obj in spawnedObjects)
            {
                obj.SetActive(false);
            }
        }
    }

    void SpawnWave()
    {
        if (spawnedObjects.Count < maxObjects)
        {
            Vector3 randomPosition = GetRandomPositionInCylinder(circleRadius, WarmUpSpawn.transform.position);
            GameObject newObject = Instantiate(prefab, randomPosition, Quaternion.identity);
            if(!isInWarmupPlace){
                newObject.SetActive(false);
            }
            spawnedObjects.Add(newObject);
            
        }

    }

    Vector3 GetRandomPositionInCylinder(float radius, Vector3 center)
    {
        float angle = Random.Range(0f, Mathf.PI * 2); // Ngẫu nhiên góc từ 0 đến 2π
        float r = Random.Range(0f, radius); // Ngẫu nhiên bán kính
        float x = center.x + r * Mathf.Cos(angle); // Tính tọa độ x
        float z = center.z + r * Mathf.Sin(angle); // Tính tọa độ z
        float y = center.y + Random.Range(-cylinderHeight / 2f, cylinderHeight / 2f); // Ngẫu nhiên chiều cao y

        return new Vector3(x, y, z);
    }
}
