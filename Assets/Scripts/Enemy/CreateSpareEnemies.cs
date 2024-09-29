using UnityEngine;

public class CreateSpareEnemies
{
    private Enemy enemy;
    private Transform spawnTransform;
    public CreateSpareEnemies(Enemy enemy, Transform spawnTransform)
    {
        this.enemy = enemy;
        this.spawnTransform = spawnTransform;
    }
    public void Create(int numberEnemies)
    {
        var spawnPosition = spawnTransform.position;
        for(var i = 0; i < numberEnemies; i++)
        {
            Vector3 position = new Vector3(Random.Range(spawnPosition.x + 2, spawnPosition.x - 2), 0,
            Random.Range(spawnPosition.z + 2, spawnPosition.z - 2));
            var enemy = MonoBehaviour.Instantiate(this.enemy, position, Quaternion.identity);
            SceneManager.Instance.AddEnemie(enemy);
        }
    }
}
