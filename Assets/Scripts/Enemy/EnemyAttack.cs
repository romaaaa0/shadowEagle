using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyAttack
{
    protected abstract float attackDelayTime { get; set; }
    protected abstract float damage { get; set; }
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private float attackTimer;
    private Enemy enemy;
    public EnemyAttack(Enemy enemy, NavMeshAgent navMeshAgent, Animator animator)
    {
        this.enemy = enemy;
        this.navMeshAgent = navMeshAgent;
        this.animator = animator;
    }
    public virtual void Attack()
    {
        if (enemy.IsDead || SceneManager.Instance.Player.IsDead) return;
        var distance = Vector3.Distance(enemy.transform.position, SceneManager.Instance.Player.transform.position);
        attackTimer -= Time.deltaTime;
        if (distance <= enemy.AttackDistance)
        {
            navMeshAgent.isStopped = true;
            if (attackTimer <= 0)
            {
                var player = SceneManager.Instance.Player;
                enemy.transform.rotation = Quaternion.LookRotation(player.transform.position - enemy.transform.position);
                attackTimer = attackDelayTime;
                SceneManager.Instance.Player.Hp -= damage;
                animator.SetTrigger("Attack");
            }
        }
    }
}
