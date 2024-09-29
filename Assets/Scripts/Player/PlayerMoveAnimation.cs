using UnityEngine;

public class PlayerMoveAnimation : IAnimation
{
    private Player player;
    private Animator animator;
    private bool isIdle;
    private bool isRunning;
    public PlayerMoveAnimation(Animator animator)
    {
        player = SceneManager.Instance.Player;
        this.animator = animator;
    }
    public void Animation()
    {
        if (player.IsDead) return;
        if(player.MovementDirection.magnitude == 0 && !isIdle)
        {
            animator.SetTrigger("Idle");
            isRunning = false;
            isIdle = true;
        }
        else if (player.MovementDirection.magnitude != 0 && !isRunning && isIdle)
        {
            animator.SetTrigger("Run");
            isRunning = true;
            isIdle = false;
        }
    }
}
