using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
public float moveForce = 10;
    public float maxHSpeed = 10;


    Vector2 currentDirection = Vector2.right;
    Rigidbody2D rBody = null;
    Animator anim = null;
    bool walking = false;

    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleUI();
        Debug.Log("current velocity: " + rBody.velocity);
        anim.SetFloat("hVelocity", Mathf.Abs(rBody.velocity.x));
    }

    void HandleUI()
    {

        if (Input.GetKey(KeyCode.A))
        {
            Move(-Vector2.right);//left


        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector2.right);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            anim.SetTrigger("jab");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("cross");
        }
    }

    void Move(Vector2 direction)
    {

        if (currentDirection != direction)
        {
            transform.Rotate(Vector3.up, 180.0f);
            currentDirection = direction;
        }
        
        if (rBody.velocity.x > -maxHSpeed && rBody.velocity.x < maxHSpeed)
        {
            rBody.AddForce(currentDirection * moveForce);
        }
    }

    void Jab()
    {

    }

}
