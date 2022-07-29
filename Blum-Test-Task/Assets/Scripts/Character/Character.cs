using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private CharacterData characterData;

    protected int life;
    protected float speed;
    protected float fall;
    protected float timeAtacking;
    protected int maxLife;

    private Rigidbody2D rigid;
    private int jumpAmount;

    public virtual void Setup()
    {
        life = characterData.Life;
        maxLife = characterData.Life;
        speed = characterData.Speed;
        jumpAmount = characterData.JumpAmount;
        timeAtacking = characterData.TimeAtacking;
        rigid = GetComponent<Rigidbody2D>();
        rigid.gravityScale = characterData.Fall;
    }

    public virtual void MyUpdate()
    {}

    public virtual void GetPunch()
    {
        life -= 1;

        if (life == 0f)
            Destroy(gameObject);
    }

    protected virtual void Attack()
    {
        animator.SetTrigger("Attack");
    }

    protected void Jump()
    {
        rigid.velocity = Vector2.up * jumpAmount;
        animator.SetBool("isJump", true);
    }

    protected void NotJump()
    {
        animator.SetBool("isJump", false);
    }

    protected void Move(float axis, float speed)
    {
        animator.SetFloat("isWalking", axis == -1f ? 1f : axis);
        rigid.velocity = new Vector2(axis * speed, rigid.velocity.y);

        if (axis == 0f)
            return;

        else if (axis == 1)
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

        else if (axis == -1)
            transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
    }
}
