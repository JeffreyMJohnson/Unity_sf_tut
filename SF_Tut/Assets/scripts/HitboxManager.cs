using UnityEngine;
using System.Collections;

public class HitboxManager : MonoBehaviour
{

    //set these in the editor

    public BoxCollider2D jab0;
    public BoxCollider2D jab1;
    public BoxCollider2D cross0;
    public BoxCollider2D cross1;

    //used for organization
    private BoxCollider2D[] colliders;

    //collider on this game object
    private BoxCollider2D localCollider = null;

    //say box but are using polygon colliders
    public enum HITBOXES
    {
        JAB0,
        JAB1,
        CROSS0,
        CROSS1,
        CLEAR //special case to remove all boxes
    }

    // Use this for initialization
    void Start()
    {
        //set up the array so script can more easiloy set up boxes
        colliders = new BoxCollider2D[] { jab0, jab1, cross0, cross1 };
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        //was i hit or doing the hitting
        if(col.gameObject.GetComponent<Player>().IsHittableBox(col as BoxCollider2D))
        {
            Debug.Log("hit a hittable box.");
            //hit hittable box
            col.gameObject.GetComponent<Animator>().SetTrigger("faceDamage");
        }

        if(IsHitBox(col as BoxCollider2D))
        {
            Debug.Log("Hit by a hitbox.");
            //hit by hitbox
        }

    }

    private bool IsHitBox(BoxCollider2D col)
    {
        foreach(BoxCollider2D hitBox in colliders)
        {
            if (hitBox.size == col.size && hitBox.offset == col.offset)
            {
                return true;
            }
        }
        return false;
    }

    public void SetHitBox(HITBOXES value)
    {
        if (value != HITBOXES.CLEAR)
        {
            if(null == localCollider)
            {
                localCollider = gameObject.AddComponent<BoxCollider2D>();
                localCollider.isTrigger = true;
            }
            localCollider.size = colliders[(int)value].size;
            localCollider.offset = colliders[(int)value].offset;
            return;
        }
        Destroy(localCollider);
        localCollider = null;
    }
}
