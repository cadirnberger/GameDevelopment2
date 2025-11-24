using UnityEngine;

public class HK_Animation : MonoBehaviour
{
    Movement movement;
    Sensors sensors;
    Animator animator;
    Rigidbody2D body;

    float idleDelay = 0f;

    void Awake()
    {
        movement = GetComponent<Movement>();
        sensors = GetComponent<Sensors>();
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        animator.SetBool("Grounded", movement.Grounded);
        animator.SetBool("WallSlide", sensors.IsWallSliding());
        animator.SetFloat("AirSpeedY", body.linearVelocity.y);

        HandleRunIdle();
        HandleJumpAnimation();
    }

    void HandleRunIdle()
    {
        if (Mathf.Abs(body.linearVelocity.x) > 0.1f)
        {
            idleDelay = 0.05f;
            animator.SetInteger("AnimState", 1);
        }
        else
        {
            idleDelay -= Time.deltaTime;
            if (idleDelay < 0)
                animator.SetInteger("AnimState", 0);
        }
    }
    public void HandleRollAnimation()
    {
        if (movement.Rolling)
        {
            animator.SetTrigger("Roll");
        }
    }
    public void HandleJumpAnimation()
    {
        if (!movement.Grounded && body.linearVelocity.y > 0.1f)
        {
            animator.SetTrigger("Jump");
        }
    }
    public void HandleDeath()
    {
    animator.SetTrigger("Death"); 
    }
    public void HandleHurt()
    {
        
    animator.SetTrigger("Hurt");
        
    }


} 
