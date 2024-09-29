using UnityEngine;

public class SimplePlayerAttack : PlayerAttack
{
    protected override float attackTimer { get; set ; }
    protected override float attackDelayTime { get; set; } = 1;
    protected override float attackDistance { get; set; } = 3;
    private float damage = 1;
    private Enemy closestEnemy;
    protected override void Update()
    {
        base.Update();
    }
    public override void Attack()
    {
        if (SceneManager.Instance.Player.IsDead) return;
        closestEnemy = playerDistanceToClosestEnemy.Distance(gameObject.transform);
        if (closestEnemy != null)
        {
            var distance = Vector3.Distance(transform.position, closestEnemy.transform.position);
            if (distance <= attackDistance && attackTimer <= 0)
            {
                transform.transform.rotation = Quaternion.LookRotation(closestEnemy.transform.position - transform.position, Vector3.up);
                closestEnemy.Health -= damage;
                Fight();
            }
        }
        if (attackTimer <= 0)
        {
            Fight();
        }
    }
    protected override void Fight()
    {
        base.Fight();
        animatorController.SetTrigger("Attack");
    }
}
