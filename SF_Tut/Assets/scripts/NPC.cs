using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour
{

    public float moveForce = 10;
    public float maxHSpeed = 10;
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
    void Update()
    {
        //HandleUI();
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
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            anim.SetTrigger("jab");
        }

    }

    void Cross()
    {
        anim.SetTrigger("cross");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(faceHitBox.IsTouching(col));
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            Debug.Log("trigger fired on npc.");
            anim.SetTrigger("faceDamage");
            col.gameObject.GetComponent<HitboxManager>().SetHitBox(HitboxManager.HITBOXES.CLEAR);

        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collision fired on npc.");
    }
}
