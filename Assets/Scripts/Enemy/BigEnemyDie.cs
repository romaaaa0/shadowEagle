using UnityEngine;
using UnityEngine.AI;

public class BigEnemyDie : IDie
{
    private Animator animator;
    private BigEnemy bigEnemy;
    private NavMeshAgent navMeshAgent;
    private SimpleEnemy cloneEnemy;
    private CreateSpareEnemies createSpareEnemies;
    public BigEnemyDie(Animator animator, SimpleEnemy cloneEnemy, BigEnemy bigEnemy, NavMeshAgent navMeshAgent)
    {
        this.animator = animator;
        this.cloneEnemy = cloneEnemy;
        this.bigEnemy = bigEnemy;
        this.navMeshAgent = navMeshAgent;
        createSpareEnemies = new CreateSpareEnemies(cloneEnemy, bigEnemy.transform);
    }
    public void Die()
    {
        if (bigEnemy.Health <= 0)
        {
            SceneManager.Instance.Player.AddHP(2);
            navMeshAgent.isStopped = true;
            createSpareEnemies.Create(2);
            SceneManager.Instance.RemoveEnemie(bigEnemy);
            animator.SetTrigger("Die");
            bigEnemy.IsDead = true;
        }
    }
}
