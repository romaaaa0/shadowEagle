using Assets;

public class SimpleEnemy : Enemy
{
    public override float Health { get; set; } = 1;
    protected override void Start()
    {
        base.Start();
        SetDie(new SimpleEnemyDie(this, animator, navMeshAgent));
        SetAttack(new SimpleEnemyAttack(this, navMeshAgent, animator));
        SetMovement(new EnemyMovement(this, navMeshAgent, animator));
        navMeshAgent.SetDestination(SceneManager.Instance.Player.transform.position);
        die = new SimpleEnemyDie(this, animator, navMeshAgent);
    }
    protected void Update()
    {
        if (IsDead || SceneManager.Instance.Player.IsDead) return;
        Die();
        Attack();
        Movement();
    }
}