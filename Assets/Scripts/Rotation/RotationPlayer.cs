using UnityEngine;

public class RotationPlayer : IRotation
{
    private Player player;
    private float rotationSpeed = 30;

    public RotationPlayer(Player player)
    {
        this.player = player;
    }

    public void Rotation()
    {
        if (player.MovementDirection.magnitude != 0)
        {
            var playerTransform = player.gameObject.transform.rotation;
            var toRotation = Quaternion.LookRotation(player.MovementDirection);
            player.gameObject.transform.rotation = Quaternion.Slerp(playerTransform, toRotation, rotationSpeed * Time.deltaTime);
        }
     }
}
