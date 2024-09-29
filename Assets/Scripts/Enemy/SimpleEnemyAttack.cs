using UnityEngine; 
using UnityEngine.AI;

public class SimpleEnemyAttack : EnemyAttack
{
    public SimpleEnemyAttack(Enemy enemy, NavMeshAgent navMeshAgent, Animator animator) :
    base(enemy, navMeshAgent, animator)
    { }
    protected override float attackDelayTime { get; set; } = 2;
    protected override float damage { get; set; } = 1;
}
