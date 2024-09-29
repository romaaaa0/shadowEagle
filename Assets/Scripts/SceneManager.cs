using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;

    public Player Player;
    public List<Enemy> Enemies = new List<Enemy>();
    public int countEnemies;

    private int currWave = 0;
    [SerializeField] private LevelConfig Config;
    [SerializeField] private Text currentWaveNumber;
    [SerializeField] private Text totalNumberWaves;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        totalNumberWaves.text = "Total Waves: " + Config.Waves.Length;
        currentWaveNumber.text = "Current Wave: " + currWave;
        SpawnWave();
    }
    public void AddEnemie(Enemy enemie)
    {
        Enemies.Add(enemie);
    }

    public void RemoveEnemie(Enemy enemie)
    {
        Enemies.Remove(enemie);
        if(Enemies.Count == 0)
        {
            SpawnWave();
        }
    }
    private void SpawnWave()
    {
        if (currWave >= Config.Waves.Length)
        {
            WinGame.Instance.Win();
            return;
        }

        var wave = Config.Waves[currWave];
        foreach (var character in wave.Characters)
        {
            Vector3 pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            var enemy = Instantiate(character, pos, Quaternion.identity);
            AddEnemie(enemy.GetComponent<Enemy>());
        }
        currWave++;
        currentWaveNumber.text = "Current Wave: " + currWave;
    }

    public void Reset()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private void Update()
    {
        countEnemies = Enemies.Count;
    }
}
