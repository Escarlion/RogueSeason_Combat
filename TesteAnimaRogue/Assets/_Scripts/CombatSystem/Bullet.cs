using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Objetos
    [SerializeField] float destroyAfter = 5f;
    CombatManager combatManager;
    Animator animator;
    Enemy enemy;

    //Variaveis
    string HIT_EFFECT = "BulletHit";
    int bulletDamage;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Destroy(gameObject, destroyAfter);
        combatManager = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<CombatManager>();
        bulletDamage = combatManager.GetActiveWeaponDamage();
    }

    //Verifica as informações do alvo usando uma collisão de trigger
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        enemy = hitInfo.GetComponent<Enemy>();  
    }

    //Executa a animação de contato da bala e faz alguma função dependendo do que foi acertado
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.Play(HIT_EFFECT);
        if (enemy != null)
        {
            enemy.EnemyTakeDamage(bulletDamage);
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
