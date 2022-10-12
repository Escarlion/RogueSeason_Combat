using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeaponController : MonoBehaviour
{
    [SerializeField] Player player;
    WeaponRotationController weaponRotationController;
    CombatManager combatManager;
    Animator animator;

    int damage;
    [SerializeField] private int maxAmmo = 1;
    [SerializeField] int currentAmmo;
    float shotCD;
    float reloadCD;
    float projetileSpeed;

    bool readyToShot = true;

    string WEAPON_SHOT;
    string WEAPON_RECHARGE;
    string WEAPON_IDLE;

    private void Start()
    {
        weaponRotationController = GetComponent<WeaponRotationController>();
        combatManager = player.GetComponent<CombatManager>();
        animator = GetComponent<Animator>();

        WEAPON_SHOT = gameObject.name + "Shot";
        WEAPON_RECHARGE = gameObject.name + "Recharge";
        WEAPON_IDLE = gameObject.name + "Idle";
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        //Verifica se o player Apertou o botão Esq ou Dir do mouse
        if (Input.GetButtonDown(combatManager.command[combatManager.commandIndex]))
        {
            Shot();
        }
    }
    private void FixedUpdate()
    {
        weaponRotationController.WeaponRotation();
    }

    void Shot()
    {
        if (currentAmmo > 0 && readyToShot)
        {
                combatManager.NotReadyToSwitchWeapon();
                readyToShot = false;
                animator.Play(WEAPON_SHOT);
                currentAmmo--;  
        }
        else if(currentAmmo == 0 && readyToShot)
        {
            Recharge();
        }
    }

    void Recharge()
    {
        readyToShot = false;
        combatManager.NotReadyToSwitchWeapon();
        currentAmmo = maxAmmo;
        animator.Play(WEAPON_RECHARGE);
    }

    void ReturnToIdle()
    {
        combatManager.ReadyToSwitchWeapon();
        readyToShot = true;
        animator.Play(WEAPON_IDLE);
    }
}
