using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    private Player player;
    private Animator animator;
    private IAnimation animationMove;
    private RotationPlayer rotation;
    public void Start()
    {
        player = SceneManager.Instance.Player;
        animationMove = new PlayerMoveAnimation();
        rotation = new RotationPlayer();
    }
    private void Update()
    {
        if (player.IsDead) return;
        Move();
    }
    public void Move()
    {        
        if (player.MovementDirection.magnitude != 0)
        {
            player.transform.position += player.MovementDirection * Time.deltaTime * player.Speed;
            rotation.Rotation();
        }
        animationMove.Animation();
    }
}
