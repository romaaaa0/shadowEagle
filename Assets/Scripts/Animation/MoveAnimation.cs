public class MoveAnimation : IAnimation
{
    private Player player;
    public MoveAnimation()
    {
        player = SceneManager.Instance.Player;
    }
    public void Animation()
    {
        if(player.MovementDirection.magnitude == 0 && !player.IsIdle)
        {
            IdleAnimationStart();
            player.IsRunning = false;
            player.IsIdle = true;
        }
        else if (player.MovementDirection.magnitude != 0 && !player.IsRunning && player.IsIdle)
        {
            MoveAnimationPlay();
            player.IsRunning = true;
            player.IsIdle = false;
        }
    }
    private void MoveAnimationPlay()
    {
        player.AnimatorController.SetTrigger("Run");
    }
    private void IdleAnimationStart()
    {
        player.AnimatorController.SetTrigger("Idle");
    }
}
