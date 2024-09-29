using UnityEngine;
using UnityEngine.UI;
public abstract class PlayerAttack : MonoBehaviour
{
    [SerializeField] protected Image attackImage;
    [SerializeField] protected Button attackButton;
    protected PlayerDistanceToClosestEnemy playerDistanceToClosestEnemy;
    protected Animator animatorController;
    protected abstract float attackTimer { get; set; }
    protected abstract float attackDelayTime { get; set; }
    protected abstract float attackDistance { get; set; }
    private Player player;

    protected virtual void Start()
    {
        player = GetComponent<Player>();
        animatorController = GetComponent<Animator>();
        playerDistanceToClosestEnemy = new PlayerDistanceToClosestEnemy();
        attackButton.onClick.AddListener(Attack);
    }
    protected virtual void Update()
    {
        if (SceneManager.Instance.Player.IsDead) 
            attackButton.onClick.RemoveAllListeners();
        attackTimer -= Time.deltaTime;
        attackImage.fillAmount += Time.deltaTime / attackDelayTime;
    }
    public abstract void Attack();
    protected virtual void Fight()
    {
        attackImage.fillAmount = 0;
        attackTimer = attackDelayTime;
        player.IsFighting = true;
        player.IsRunning = false;
    }
}
