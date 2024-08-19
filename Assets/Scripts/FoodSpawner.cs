using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{

    public GameObject foodPrefab;
    public float xRangeStart = -75f;
    public float yRangeStart = -40f;
    public float xRangeEnd = 75f;
    public float yRangeEnd = 40f;

    Vector3 randomPosition;
    GameObject instantiatedFood;
    void Start()
    {
        StartCoroutine(foodSpawning());
    }

    IEnumerator foodSpawning()
    {
        Destroy(instantiatedFood);
        randomPosition = new Vector3((int)Random.Range(xRangeStart, xRangeEnd),
                    (int)Random.Range(yRangeStart, yRangeEnd), 0);

        while (Physics2D.Raycast(randomPosition, Vector2.up).collider != null)
        {
            //Debug.Log($"Found an object - distance: \" + {Physics2D.Raycast(randomPosition, Vector2.up).point}");
            randomPosition = new Vector3((int)Random.Range(xRangeStart, xRangeEnd),
               (int)Random.Range(yRangeStart, yRangeEnd), 0);

        }
        instantiatedFood = Instantiate(foodPrefab, randomPosition, Quaternion.identity);
        yield return new WaitForSeconds(20);
        StartCoroutine(foodSpawning());
    }
    public void NewFoodSpawn()
    {
        StartCoroutine(foodSpawning());
    }
}