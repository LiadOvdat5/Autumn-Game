using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Movement
    [SerializeField] float runSpeed = 1f;
    [SerializeField] float jumpHight = 1f;

    //Ground check
    [SerializeField] LayerMask platformLayerMask;
    private BoxCollider2D boxCollider2D;
    
    //Attack
    [SerializeField] LayerMask leavesLayer;
    public bool isPunching = false;
    string[] punchingTypes = new string[] { "Punch 1", "Punch 2", "Punch 3 " } ;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 1f;

    //Game Mangment
    GameManager gameManager;

    //General
    Animator animator;
    Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        
        if(!isGrounded())
        {
            animator.SetBool("isJump", true);
        }
        else { animator.SetBool("isJump", false); }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
    }

    private void Move()
    {
        if (isPunching == false)
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            transform.position += new Vector3(horizontalMovement, 0, 0) * Time.deltaTime * runSpeed;

            if (horizontalMovement != 0)
            {
                animator.SetBool("isRun", true);
            }
            else
            {
                animator.SetBool("isRun", false);
            }

            if (horizontalMovement < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (horizontalMovement > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    private void Jump()
    {

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            SoundManager.PlaySound("jumpSound");
            rb.velocity = Vector2.up * jumpHight;
            animator.SetBool("isJump", true);
        }   

    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.size, 0f, Vector2.down, 0.1f, platformLayerMask );
        //Debug.Log(raycastHit.collider);
        return (raycastHit.collider != null);
    }

    private void Attack()
    {
        isPunching = true;
        animator.SetTrigger(punchingTypes[Random.Range(0, punchingTypes.Length)]);

        Collider2D[] hitLeaves = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, leavesLayer);
        
        foreach(Collider2D leaf in hitLeaves)
        {
            Destroy(leaf.gameObject);
            gameManager.AddLeafDestroyed();
            SoundManager.PlaySound("hitSound");
        }
        
    }

    private void NotPunching()
    {
        isPunching = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
