using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private SpriteRenderer SpR;
    private Rigidbody2D Rb;
    private Vector2 movement;

    public Animator Anim;
    public Transform GroundTranform;
    public float CheckRedias = 0.5f;
    public LayerMask GroundMask;

    public bool onGround;
    bool jumping = false;

    float Speed = 800f;
    float jump = 50f;
    float doublejump =60f;
   
    
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        SpR= GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        onGround = Physics2D.OverlapCircle(GroundTranform.position, CheckRedias, GroundMask);

        var H = Input.GetAxisRaw("Horizontal");

        movement.x = H;
        Rb.velocity = new Vector2(movement.x * Speed * Time.deltaTime, Rb.velocity.y);


        
        if (H > 0)
        {
            SpR.flipX = false;
        }
        else if (H < 0)
        {
            SpR.flipX = true;
        }

        Anim.SetFloat("run", Mathf.Abs(H));


        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
           Rb.AddForce(new Vector2(0,jump),ForceMode2D.Impulse);
            Anim.SetTrigger("jump");
            jumping = true;
          
           
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumping && !onGround)
        {
            Rb.AddForce(new Vector2(0, doublejump), ForceMode2D.Impulse);
            Anim.SetTrigger("jump");
             jumping = false;
        }

        if (Rb.transform.position.y < -33f)
        {
            PauseGame();
        }

    }



    private void OnCollisionEnter2D(Collision2D others)
    {
        if (others.collider.tag == "Platforms")
        {
            transform.SetParent(others.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D others)
    {
        if (others.collider.tag == "Platforms")
        {
            transform.SetParent(null);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(GroundTranform.position, CheckRedias);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }

}
