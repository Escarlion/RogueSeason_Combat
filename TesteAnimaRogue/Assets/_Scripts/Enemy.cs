using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Enemy : MonoBehaviour
{
    [SerializeField] int life = 1;
    [SerializeField] AnimationClip IDLE;
    [SerializeField] AnimationClip DAMAGE;
    [SerializeField] GameObject floatingPoints;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void EnemyTakeDamage(int damage)
    {
        life -= damage;
        FloatingDamage(damage);
        if (life <= 0)
        {
            Die();
        }
        else
        {
            animator.Play(DAMAGE.name);
        }

    }
    
    void Die()
    {
        animator.Play(DAMAGE.name);
        Destroy(gameObject, 0.2f);
    }

    void ReturnToIdle()
    {
        animator.Play(IDLE.name);
    }
    void FloatingDamage(int damage)
    {
        GameObject point = Instantiate(floatingPoints, transform.position, transform.rotation);
        point.transform.SetParent(this.transform);
        point.GetComponent<TextMeshPro>().text = damage.ToString();
        if(damage <= 1)
        {
            point.GetComponent<TextMeshPro>().color = new Color(255, 255, 255, 255);
        }
        else if(damage > 1 && damage <= 2)
        {
            point.GetComponent<TextMeshPro>().color = new Color(255, 103, 0, 255);
        }
        else if(damage > 2 && damage <= 5)
        {
            point.GetComponent<TextMeshPro>().color = new Color(255, 0, 0, 255);
        }
        else
        {
            point.GetComponent<TextMeshPro>().color = new Color(255, 255, 255, 255);
        }
    }
}
