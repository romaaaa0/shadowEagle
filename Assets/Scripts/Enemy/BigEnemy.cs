using System.Collections.Generic;
using UnityEngine;
public class BigEnemy : Enemy
{
    public override float Health { get; set; } = 4;
    [SerializeField] private SimpleEnemy cloneEnemy;
    private List<SimpleEnemy> cloneEnemies = new List<SimpleEnemy>();
    protected override void Start()
    {
        base.Start();   
        SetDie(new BigEnemyDie(animator, cloneEnemy, this, navMeshAgent));
        SetAttack(new BigEnemyAttack(this, navMeshAgent, animator));
        SetMovement(new EnemyMovement(this, navMeshAgent, animator));
        navMeshAgent.SetDestination(SceneManager.Instance.Player.transform.position);
        die = new BigEnemyDie(animator, cloneEnemy, this, navMeshAgent);
    }
    protected void Update()
    {
        if (IsDead || SceneManager.Instance.Player.IsDead) return;
        Die();
        Attack();
        Movement();
    }
}
