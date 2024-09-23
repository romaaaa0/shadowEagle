using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;

    public Player Player;
    public List<IEnemy> Enemies = new List<IEnemy>();
    public GameObject Lose;
    public GameObject Win;
    public int countEnemies;

    private int currWave = 0;
    [SerializeField] private LevelConfig Config;
    [SerializeField] private Text CurrentWaveNumber;
    [SerializeField] private Text TotalNumberWaves;

    private void Awake()
    {
        Instance = this;
        print(Enemies.Count);
    }

    private void Start()
    {
        TotalNumberWaves.text = "Total Waves: " + Config.Waves.Length;
        CurrentWaveNumber.text = "Current Wave: " + currWave;
        SpawnWave();
    }
    public void AddEnemie(IEnemy enemie)
    {
        Enemies.Add(enemie);
    }

    public void RemoveEnemie(IEnemy enemie)
    {
        Enemies.Remove(enemie);
        if(Enemies.Count == 0)
        {
            SpawnWave();
        }
    }

    public void GameOver()
    {
        Lose.SetActive(true);
    }

    private void SpawnWave()
    {
        if (currWave >= Config.Waves.Length)
        {
            Win.SetActive(true);
            return;
        }

        var wave = Config.Waves[currWave];
        foreach (var character in wave.Characters)
        {
            Vector3 pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            Instantiate(character, pos, Quaternion.identity);
        }
        currWave++;
        CurrentWaveNumber.text = "Current Wave: " + currWave;
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
