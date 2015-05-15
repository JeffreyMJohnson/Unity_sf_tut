using UnityEngine;
using System.Collections;

public class player1 : MonoBehaviour
{
    Animator playerAnimator = null;
    // Use this for initialization
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleUI();
    }

    private void HandleUI()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            playerAnimator.SetTrigger("right_jab_left");
            playerAnimator.SetTrigger("left_jab_right");
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            playerAnimator.SetTrigger("left_cross_left");
        }
    }
}
