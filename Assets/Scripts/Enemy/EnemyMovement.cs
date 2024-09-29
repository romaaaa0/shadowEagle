using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : IMovement
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private Transform enemyTransform;
    private float maximumDistanceToPlayer = 2;
    private Enemy enemy;
    private IAnimation animationMove;
    public EnemyMovement(Enemy enemy, NavMeshAgent navMeshAgent, Animator animator)
    {
        enemyTransform = enemy.transform;
        this.navMeshAgent = navMeshAgent;
        this.animator = animator;
        this.enemy = enemy;
        animationMove = new EnemyMovementAnimation(enemy, animator, enemyTransform);
    }
    public void Move()
    {
        var distanceToPlayer = Vector3.Distance(enemyTransform.position, SceneManager.Instance.Player.transform.position);
        if (distanceToPlayer > maximumDistanceToPlayer)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(SceneManager.Instance.Player.transform.position);
        }
        animationMove.Animation();
    }
}
