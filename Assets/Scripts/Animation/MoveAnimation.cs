public class MoveAnimation : IAnimation
{
    private Player player;
    public MoveAnimation(Player player)
    {
        this.player = player;
    }
    public void Animation()
    {
        if(player.MovementDirection.magnitude == 0)
        {
            if (!player.IsIdle)
            {
                IdleAnimationStart();
                player.IsRunning = false;
                player.IsIdle = true;
            }
        }
        else if (player.MovementDirection.magnitude != 0)
        {
            if (!player.IsRunning)
            {
                MoveAnimationPlay();
                player.IsRunning = true;
                player.IsIdle = false;
            }
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
