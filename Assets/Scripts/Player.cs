using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigid;

    private bool grounded = false;
    //private bool jumping = false; 
    private float delay = 0;

    public float jumpForce;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        delay += Time.deltaTime;
        PlayerJump();
    }


    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true && delay > 0.5f)
        {
            //animator.SetBool("Jumping", true);
            rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
            grounded = false;
            //jumping = true;
            delay = 0;

        }

        if (Input.GetKeyUp(KeyCode.Space) && rigid.velocity.y > 0f)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * 0.5f);
            //jumping = false;
            //animator.SetBool("Jumping", false);
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.35f, 1 << 10);
        Debug.DrawRay(transform.position, Vector2.down * 1.35f, Color.red);

        if (hitInfo.collider != null)
        {
            grounded = true;
            //if (jumping == true)
            //{
            //    jumping = false;
            //    //animator.SetBool("Jumping", false);
            //}
        }
        else
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("GameOver");
    }
}
