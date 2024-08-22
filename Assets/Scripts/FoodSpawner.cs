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

  
    GameObject instantiatedFood;
    void Start()
    {
        foodSpawning();
    }
    [ContextMenu("foodSpawning")]
    public void foodSpawning()
    {
      
        var randomPosition = new Vector3((int)Random.Range(xRangeStart, xRangeEnd),
                    (int)Random.Range(yRangeStart, yRangeEnd), 0);

        var bodyPart = Physics2D.OverlapPoint(randomPosition);
        
        while (bodyPart != null)
        {
            Debug.Log(bodyPart);
            randomPosition = new Vector3((int)Random.Range(xRangeStart, xRangeEnd),
               (int)Random.Range(yRangeStart, yRangeEnd), 0);
            bodyPart = Physics2D.OverlapPoint(randomPosition);

        }
        instantiatedFood = Instantiate(foodPrefab, randomPosition, Quaternion.identity);
        
    }
    
}