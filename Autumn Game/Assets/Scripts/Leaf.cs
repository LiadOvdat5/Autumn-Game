using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    //General
    Animator myAnimator;

    //Ground check
    [SerializeField] LayerMask platformLayerMask;
    private BoxCollider2D boxCollider2D;


    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        if(isGrounded())
        {
            myAnimator.SetBool("TouchedGround", true);
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.size, 0f, Vector2.down, 0.1f, platformLayerMask);
        //Debug.Log(raycastHit.collider);
        return (raycastHit.collider != null);
    }



}
