using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private UIManager ui;
    [SerializeField]
    private PlayerAtack playerAtack;

    [SerializeField]
    private string tagGrounded;
    [SerializeField]
    private string tagEnemy;
    [SerializeField]
    private string tagMoney;

    [SerializeField]
    private bool isGrounded;
    private int money;
    private float vertexMove;

    public override void Setup()
    {
        playerAtack.TagEnemy = tagEnemy;
        inputManager = new InputManager();
        inputManager.Enable();

        inputManager.Player.Move.performed += ctx => vertexMove = ctx.ReadValue<float>();
        inputManager.Player.Jump.performed += ctx => JumpPlayer();
        inputManager.Player.Atacked.performed += ctx => Attack();

        ui.UpdateMoney(money);
        base.Setup();
        ui.UpdateLife(life);
    }

    public override void MyUpdate()
    {
        Move(vertexMove, speed);
    }

    protected override void Attack()
    {
        playerAtack.Attack();
        base.Attack();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        TouchGrounded(col.gameObject.tag);
        TouchMoney(col.gameObject);
        TouchEnemy(col.gameObject);
    }

    private void JumpPlayer()
    {
        if (isGrounded)
        {
            Jump();
            isGrounded = !isGrounded;
        }
    }

    private void TouchEnemy(GameObject enemy)
    {
        if (enemy.tag == tagEnemy)
        {
            GetPunch();
            transform.position = new Vector3(transform.position.x - 2f, transform.position.y, 0f);
            ui.UpdateLife(life);
        }
    }

    private void TouchGrounded(string tag)
    {
        if (tag == tagGrounded)
        {
            isGrounded = true;
            NotJump();
        }
    }

    private void TouchMoney(GameObject gameObject)
    {
        if (gameObject.tag == tagMoney)
        {
            money += 1;
            Destroy(gameObject);
            ui.UpdateMoney(money);
        }
    }
}