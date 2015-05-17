using UnityEngine;
using System.Collections;

public class HitboxManager : MonoBehaviour
{

    //set these in the editor

    public BoxCollider2D jab0;
    public BoxCollider2D jab1;

    //used for organization
    private BoxCollider2D[] colliders;

    //collider on this game object
    private BoxCollider2D localCollider;

    //say box but are using polygon colliders
    public enum HITBOXES
    {
        JAB0,
        JAB1,
        CLEAR //special case to remove all boxes
    }

    // Use this for initialization
    void Start()
    {
        //set up the array so script can more easiloy set up boxes
        colliders = new BoxCollider2D[] { jab0, jab1 };

        //create polygon collider
        localCollider = gameObject.AddComponent<BoxCollider2D>();
        localCollider.isTrigger = true; //set as a trigger so it doesn't collide with environment
        //localCollider.pathCount = 0;//clear auto-generated polygons
        localCollider.size = Vector2.zero;//clear auto-generated polygons
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (localCollider.size.x > 0.01 && localCollider.size.y > 0.01)
        {
            //hitting mode
            //this object hitting so fire the damage animation on who collided with
            col.gameObject.GetComponent<Animator>().SetTrigger("faceDamage");
        }



    }

    public void SetHitBox(HITBOXES value)
    {
        if (value != HITBOXES.CLEAR)
        {
            //Debug.Log("setting box: " + value);
            //localCollider.SetPath(0, colliders[(int)value].GetPath(0));
            localCollider.size = colliders[(int)value].size;
            localCollider.offset = colliders[(int)value].offset;
            return;
        }
        //localCollider.pathCount = 0;
        //Debug.Log("setting box: " + value);
        localCollider.size = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
