using UnityEngine;

public class DoublePlayerAttack : PlayerAttack
{
    protected override float attackTimer { get; set; }
    protected override float attackDelayTime { get; set; } = 2;
    protected override float attackDistance { get; set; } = 3;
    private float damage = 2;
    private Enemy closestEnemy;
    protected override void Update()
    {
        base.Update();
        closestEnemy = playerDistanceToClosestEnemy.Distance(gameObject.transform);
    }
    public override void Attack()
    {
        if (SceneManager.Instance.Player.IsDead) return;
        if (closestEnemy != null)
        {
            var enemyType = closestEnemy as MonoBehaviour;
            var distance = Vector3.Distance(transform.position, enemyType.transform.position);
            if (distance <= attackDistance && attackTimer <= 0)
            {
                transform.transform.rotation = Quaternion.LookRotation(enemyType.transform.position - transform.position, Vector3.up);
                closestEnemy.Health -= damage;
                Fight();
            }
        }
    }
    protected override void Fight()
    {
        base.Fight();
        animatorController.SetTrigger("DoubleAttack");
    }
}
