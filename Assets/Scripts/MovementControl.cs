using UnityEngine;
using System.Collections.Generic;
using System;
public class MovementControl : MonoBehaviour
{
    private Vector2Int gridPosition;
    private Vector2Int gridMoveDirection;
  
    private float gridMoveTimer;
    public float gridMoveTimerMax = 0.5f;
    
    [SerializeField]
    private List<GameObject> BodyParts = new List<GameObject>();
    public GameObject bodyPartPrefab;
    public Transform bodyTransform;
   

    void Awake()
    {
        gridPosition = new Vector2Int((int)BodyParts[0].transform.position.x, (int)BodyParts[0].transform.position.y);
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1,0);
    }

    void Update()
    {
        if (GameDataManager.Instance.IsMoving)
        {
            HandleInput();
            HandleGridmovement();
        }
    }

    void HandleInput()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (gridMoveDirection.y != -1)
            {
                gridMoveDirection.y = 1;
                gridMoveDirection.x = 0;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (gridMoveDirection.y != 1)
            {
                gridMoveDirection.y = -1;
                gridMoveDirection.x = 0;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (gridMoveDirection.x != 1)
                {
                    gridMoveDirection.x = -1;
                    gridMoveDirection.y = 0;
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (gridMoveDirection.x != -1)
                {
                    gridMoveDirection.x = 1;
                    gridMoveDirection.y = 0;
                }
            }
 
    }

    void HandleGridmovement()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer > gridMoveTimerMax)
        {
            gridPosition += gridMoveDirection * 5;
            gridMoveTimer -= gridMoveTimerMax;
            
            for (int i = BodyParts.Count - 1; i > 0; i--)
            {
                BodyParts[i].transform.position = BodyParts[i - 1].transform.position;

            }
            BodyParts[0].transform.position = new Vector3(gridPosition.x, gridPosition.y, 0);
        }
        
       
    }

    [ContextMenu("bodyGrowth")]
    public void GrowBody()
    {
        GameObject newBodypart = Instantiate(bodyPartPrefab, BodyParts[BodyParts.Count - 1].transform.position * 5,
                                             transform.rotation);
        BodyParts.Add(newBodypart);
    }

    public int GetBodyLength()
    {
        return BodyParts.Count;
    }
}
