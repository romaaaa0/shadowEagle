using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    public abstract float Health { get; set; }
    public float AttackDistance { get; set; }
    public bool IsDead { get; set; }
    public bool IsRunning { get; set; }
    public bool IsAttacking { get; set; }
    protected Animator animator;
    protected NavMeshAgent navMeshAgent;
    protected IDie die;
    protected EnemyAttack enemyAttack;
    protected IMovement movement;
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        AttackDistance = navMeshAgent.stoppingDistance;
    }
    protected void SetDie(IDie die)
    {
        this.die = die;
    }
    protected void Die()
    {
        die.Die();  
    }
    protected void SetAttack(EnemyAttack enemyAttack)
    {
        this.enemyAttack = enemyAttack;
    }
    protected void Attack()
    {
        enemyAttack.Attack();
    }
    protected void SetMovement(IMovement movement)
    {
        this.movement = movement;
    }
    protected void Movement()
    {
        movement.Move();
    }
}