using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public Transform start, end;   // The start and end positions of the obstacle
    public float speed = 1f;       // Speed of the obstacle movement
    private bool movingForward = true; // Direction flag

    // Start is called before the first frame update
    void Start()
    {
        // Set the obstacle's initial position to the start position
        transform.position = start.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveObstacle();
    }

    void MoveObstacle()
    {
        // Move the obstacle in the current direction
        if (movingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, end.position, speed * Time.deltaTime);

            // If the obstacle has reached the end position, reverse the direction
            if (transform.position == end.position)
            {
                movingForward = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, start.position, speed * Time.deltaTime);

            // If the obstacle has reached the start position, reverse the direction
            if (transform.position == start.position)
            {
                movingForward = true;
            }
        }
    }
}
