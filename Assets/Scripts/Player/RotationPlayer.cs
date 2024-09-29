using UnityEngine;

public class RotationPlayer
{
    private Player player;
    private float rotationSpeed = 30;

    public RotationPlayer()
    {
        player = SceneManager.Instance.Player;
    }
    public void Rotation()
    {
        var playerTransform = player.gameObject.transform.rotation;
        var toRotation = Quaternion.LookRotation(player.MovementDirection);
        player.gameObject.transform.rotation = Quaternion.Slerp(playerTransform, toRotation, rotationSpeed * Time.deltaTime);
    }
}
