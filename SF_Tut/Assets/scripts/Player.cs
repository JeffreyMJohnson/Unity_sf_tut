using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    Vector3 currentDirection = Vector3.left;
    float moveSpeed = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleUI();
    }

    void HandleUI()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
            

        }
        if(Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }
    }

    void Move(Vector3 direction)
    {
        if (currentDirection != direction)
        {
            Debug.Log("flip it.");
            transform.Rotate(Vector3.up, 180.0f);
            currentDirection = direction;
        }
        
        Vector3 dx = currentDirection * moveSpeed * Time.deltaTime;
        Debug.Log("direction: " + dx);
        transform.Translate(dx, Space.World);
    }
}
