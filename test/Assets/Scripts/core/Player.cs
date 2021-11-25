using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movemetSpeed;
    private Vector3 targetPosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movemetSpeed * Time.deltaTime);
    }

    // Move right and left
    public void Move(Vector3 moveDirection)
    {
        targetPosition += moveDirection;
    }
}
