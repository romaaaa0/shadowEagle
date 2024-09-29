using UnityEngine;

public class PlayerDistanceToClosestEnemy
{
    public Enemy Distance(Transform player)
    {
        var enemies = SceneManager.Instance.Enemies;
        if (enemies == null) return null;
        Enemy closestEnemy = null;
        for (int i = 0; i < enemies.Count; i++)
        {
            var enemy = enemies[i];
            if(closestEnemy == null)
                closestEnemy = enemy;
            var distance = Vector3.Distance(player.position, enemies[i].transform.position);
            var closestDistance = Vector3.Distance(player.position, closestEnemy.transform.position);
            if (distance < closestDistance)
            {
                closestEnemy = enemies[i];
            }
        }
        return closestEnemy;
    }
}
