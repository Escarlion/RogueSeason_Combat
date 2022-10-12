using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponController : MonoBehaviour
{
    //Objetos
    [SerializeField] Player player;
    CombatManager combatManager;
    Animator animator;
    WeaponRotationController weaponRotation;

    //Variaveis
    [SerializeField] int quantCombo = 1;
    int damage;
    int currentCombo = 0;
    float atkSpeed;
    bool isAttacking = false;
    bool nextAttack = true; 
    private string currentAnimation;
    private string IDLE_ANIMATION;

    private void Start()
    {
        animator = GetComponent<Animator>();
        combatManager = player.GetComponent<CombatManager>();
        IDLE_ANIMATION = gameObject.name + "Idle";
        weaponRotation = GetComponent<WeaponRotationController>();
    }

    private void Update()
    {
        //Verifica se o player Apertou o botão Esq ou Dir do mouse
        if (Input.GetButtonDown(combatManager.command[combatManager.commandIndex]))
        {
            ComboStart();
        }

    }

    private void FixedUpdate()
    {
        weaponRotation.WeaponRotation();
    }

    //Inicia o sistema de combo, impossibilitando a troca de arma
    public void ComboStart()
    {
        
        if (isAttacking == false)
        {
            if (nextAttack)
            {
                combatManager.NotReadyToSwitchWeapon();
                isAttacking = true;
                ChangeAnimation(gameObject.name+"Attack" + currentCombo);
                currentCombo++;
                ComboCheck();
            }
        }
        
    }

    //Finaliza o sistema de combo e possibilita a troca de arma
    void ComboFinish()
    {
        ChangeAnimation(IDLE_ANIMATION);
        combatManager.ReadyToSwitchWeapon();
        isAttacking = false;
        nextAttack = true;
        currentCombo = 0;
    }

    //Verifica se o combo ja acabou ou não
    void ComboCheck()
    {
        if (currentCombo <= quantCombo)
        {
            nextAttack = true;
        }
        else
        {
            nextAttack = false;
            ComboFinish();
        }
    }

    //Muda a animação e não permite que ela "reinicie" caso tente rodar uma animação que ja está em andamento
    void ChangeAnimation(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;

        animator.Play(newAnimation);

        currentAnimation = newAnimation;

    }
    //Essa função é usada pela animação para dizer quando pode atacar novamente
    void ChangeIsAttackValue()
    {
        isAttacking = false;
    }


}
