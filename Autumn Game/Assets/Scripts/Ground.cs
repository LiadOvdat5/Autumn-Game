using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    //General
    Collider2D myCollider;

    //Game Managment
    GameManager gameManager;
    float currentLeavesOnGround;


    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        gameManager = FindObjectOfType<GameManager>();

        currentLeavesOnGround = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if(collision.gameObject.layer == 10)
        {
            gameManager.AddLeafOnGround();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            gameManager.RemoveLeafOnGround();
        }

    }
}
