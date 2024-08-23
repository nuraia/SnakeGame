using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodReSpawner : MonoBehaviour
{
    public FoodSpawner foodSpawner;
    public MovementControl movementControler;
    int Point;

    void Start()
    {
        Point = 0;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Food"))
        {
            Destroy(col.gameObject);
            Point += 10;
            UIManager.instance.SetScore(Point);
            GameDataManager.Instance.playerScore = Point;
            movementControler.GrowBody();
            int count = movementControler.GetBodyLength();
            if (count < 100) foodSpawner.foodSpawning();

        }

    }

    
}
