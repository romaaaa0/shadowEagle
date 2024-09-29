using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    private Player player;
    private IAnimation animationMove;
    private RotationPlayer rotation;
    public void Start()
    {
        player = SceneManager.Instance.Player;
        animationMove = new PlayerMoveAnimation(GetComponent<Animator>());
        rotation = new RotationPlayer();
    }
    private void Update()
    {
        if (player.IsDead || player.IsWon) return;
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
