using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class BigEnemy : MonoBehaviour, IEnemy
{
    public float Hp { get; set; } = 2;
    public float Damage;
    public float AtackSpeed;
    public float AttackRange = 2;
    public Animator AnimatorController;
    public NavMeshAgent Agent;
    [SerializeField] private List<Enemy> Enemies;
    private List<Enemy> cloneEnemies = new List<Enemy>();
    private Player player;
    private float lastAttackTime = 0;
    private bool isDead = false;
    
    private void Start()
    {
        SceneManager.Instance.AddEnemie(this);
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
        Agent.SetDestination(SceneManager.Instance.Player.transform.position);
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        if(isDead)
        {
            return;
        }

        if (Hp <= 0)
        {
            player.AddHP();
            Die();
            Agent.isStopped = true;
            return;
        }

        var distance = Vector3.Distance(transform.position, SceneManager.Instance.Player.transform.position);
     
        if (distance <= AttackRange)
        {
            Agent.isStopped = true;
            if (Time.time - lastAttackTime > AtackSpeed)
            {
                lastAttackTime = Time.time;
                SceneManager.Instance.Player.Hp -= Damage;
                AnimatorController.SetTrigger("Attack");
            }
        }
        else
        {
            Agent.isStopped = false;
            Agent.SetDestination(SceneManager.Instance.Player.transform.position);
        }
        AnimatorController.SetFloat("Speed", Agent.speed); 
    }
    private void Die()
    {
        foreach (var enemy in cloneEnemies)
            enemy.gameObject.SetActive(true);
        SceneManager.Instance.RemoveEnemie(this);
        isDead = true;
        AnimatorController.SetTrigger("Die");
    }
}
