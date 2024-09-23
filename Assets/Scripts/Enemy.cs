using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IEnemy
{
    public float Hp { get; set; } = 1;
    public float Damage;
    public float AtackSpeed;
    public float AttackRange = 2;
    public bool WasEnemyCreated { get; set; } = false;

    public Animator AnimatorController;
    public NavMeshAgent Agent;

    private Player player;

    private float lastAttackTime = 0;
    private bool isDead = false;
    private void Start()
    {
        if (!WasEnemyCreated)
        {
            SceneManager.Instance.AddEnemie(this);
            WasEnemyCreated = false;
        }

        Agent.SetDestination(SceneManager.Instance.Player.transform.position);
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if(isDead)
        {
            return;
        }

        if (Hp <= 0)
        {
            player.AddHP();
            Die();
            Agent.isStopped = true;
            return;
        }

        var distance = Vector3.Distance(transform.position, SceneManager.Instance.Player.transform.position);
     
        if (distance <= AttackRange)
        {
            Agent.isStopped = true;
            if (Time.time - lastAttackTime > AtackSpeed)
            {
                lastAttackTime = Time.time;
                SceneManager.Instance.Player.Hp -= Damage;
                AnimatorController.SetTrigger("Attack");
            }
        }
        else
        {
            Agent.isStopped = false;
            Agent.SetDestination(SceneManager.Instance.Player.transform.position);
        }
        AnimatorController.SetFloat("Speed", Agent.speed); 
    }
    private void Die()
    {
        SceneManager.Instance.RemoveEnemie(this);
        isDead = true;
        AnimatorController.SetTrigger("Die");
    }

}
