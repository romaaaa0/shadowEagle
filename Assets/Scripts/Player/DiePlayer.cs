public class DiePlayer : IDie
{
    private Player player;
    public DiePlayer()
    {
        player = SceneManager.Instance.Player;
    }
    public void Die()
    {
        if (player.Hp <= 0)
        {
            player.AnimatorController.SetTrigger("Die");
            SceneManager.Instance.GameOver();
            player.IsDead = true;
        }
    }
}