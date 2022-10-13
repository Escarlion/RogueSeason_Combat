using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Objetos
    private Rigidbody2D rb;
    private Animator animator;
    CombatManager combatManager;
    SpriteRenderer spriteRenderer;

    //Variaveis
    public float MoveSpeed = 5f;
    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public Vector2 movement;

    //Variaveis Dash
    private bool canDash = true;
    private bool isDashing = false;
    [SerializeField] private float dashPower = 24f;
    [SerializeField] private float dashingCooldown = 1f;
    private float dashingTime = 0.2f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        combatManager = GetComponent<CombatManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        //Atualiza o a posição do personagem
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Corrida
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            MoveSpeed = 10f;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            MoveSpeed = 5f;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (combatManager.leftWeaponActive != true && combatManager.canSwitchWeapon)
            {
                combatManager.LeftWeaponConfiguration();
            }

        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (combatManager.rightWeaponActive != true && combatManager.canSwitchWeapon)
            {
                combatManager.RightWeaponConfiguration();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        if (isDashing) return;
        PlayerMovement();
    }

    //Inverte o sprite do personagem
    void Flip()
    {
        if (movement.x > 0 && !facingRight)
        {
            facingRight = !facingRight;
            spriteRenderer.flipX = false;
        }
        else if (movement.x < 0 && facingRight)
        {
            facingRight = !facingRight;
            spriteRenderer.flipX = true;
        }
    }

    void PlayerMovement()
    {
        rb.MovePosition(rb.position + movement.normalized * (MoveSpeed * Time.fixedDeltaTime)); //faz o player se mexer
        Flip();
        
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(movement.x * dashPower, movement.y * dashPower);
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}