using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float moveForce = 10;
    public float maxHSpeed = 10;
    public float jumpForce = 1;
    public bool NPC = false;
    public BoxCollider2D faceHitBox;


    Vector2 currentDirection = Vector2.right;
    Rigidbody2D rBody = null;
    Animator anim = null;

    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!NPC)
        {
            HandleUI();
        }

        //Debug.Log("current velocity: " + rBody.velocity);
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
            Jab();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Cross();
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
        anim.SetTrigger("jab");
    }

    void Cross()
    {
        anim.SetTrigger("cross");
    }

    void Jump()
    {

    }

    public bool IsHittableBox(BoxCollider2D col)
    {
        return faceHitBox.offset == col.offset && faceHitBox.size == col.size;
    }

}
