using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDestroy : MonoBehaviour
{
    public FoodSpawner foodSpawner;
    void OnTriggerEnter2D(Collider2D col)
    {
            if (col.gameObject.CompareTag("Food"))
            {
                Destroy(col.gameObject);
                foodSpawner.NewFoodSpawn();
            }

    }

}
