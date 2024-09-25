using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class BigEnemy : MonoBehaviour, IEnemy
{
    public float Health { get; set; } = 2;
    [SerializeField] private List<Enemy> Enemies;
    private float damage = 2;
    private float atackSpeed = 2;
    private float attackDistance = 2;
    private Animator animatorController;
    private NavMeshAgent navMeshAgent;
    private List<Enemy> cloneEnemies = new List<Enemy>();
    private Player player;
    private float lastAttackTime = 0;
    private IDie die;
    private bool isDead;
    private void Start()
    {
        animatorController = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        SceneManager.Instance.AddEnemie(this);
        CreateSpareEnemies();
        navMeshAgent.SetDestination(SceneManager.Instance.Player.transform.position);
        player = FindObjectOfType<Player>();
        die = new BigEnemyDie(animatorController, cloneEnemies, this, navMeshAgent);
    }
    private void Update()
    {
        if(isDead) return;
        isDead = die.Die();

        var distance = Vector3.Distance(transform.position, SceneManager.Instance.Player.transform.position);
     
        if (distance <= attackDistance)
        {
            navMeshAgent.isStopped = true;
            if (Time.time - lastAttackTime > atackSpeed)
            {
                lastAttackTime = Time.time;
                SceneManager.Instance.Player.Hp -= damage;
                animatorController.SetTrigger("Attack");
            }
        }
        else
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(SceneManager.Instance.Player.transform.position);
        }
        animatorController.SetFloat("Speed", navMeshAgent.speed); 
    }
    private void CreateSpareEnemies()
    {
        var position = transform.position;
        foreach (var character in Enemies)
        {
            Vector3 pos = new Vector3(Random.Range(position.x + 2, position.x - 2), 0,
                Random.Range(position.z + 2, position.z - 2));
            var enemy = Instantiate(character, pos, Quaternion.identity);
            enemy.WasEnemyCreated = true;
            enemy.gameObject.SetActive(false);
            SceneManager.Instance.AddEnemie(enemy);
            cloneEnemies.Add(enemy);
        }
    }
    private void Die()
    {

    }
}
