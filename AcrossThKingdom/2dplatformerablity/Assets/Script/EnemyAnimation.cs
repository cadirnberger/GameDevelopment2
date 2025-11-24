using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetMoving(bool isMoving)
    {
        anim.SetBool("IsMoving", isMoving);
    }

    public void PlayAttack()
    {
        anim.SetTrigger("Attack");
    }

    public void PlayHurt()
    {
        anim.SetTrigger("Hurt");
    }

    public void PlayDeath()
    {
        anim.SetTrigger("Death");
        anim.SetBool("IsMoving", false);
    }
}
