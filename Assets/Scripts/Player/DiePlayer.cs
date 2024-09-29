using UnityEngine;

public class DiePlayer : IDie
{
    private Player player;
    private Animator animator;
    private GameObject gameOverPanel;
    public DiePlayer(Animator animator, GameObject gameOverPanel)
    {
        player = SceneManager.Instance.Player;  
        this.animator = animator;
        this.gameOverPanel = gameOverPanel;
    }
    public void Die()
    {
        if (player.Health <= 0)
        {
            animator.SetTrigger("Die");
            player.IsDead = true;
            LostGame.Instance.Lost();
        }
    }
}