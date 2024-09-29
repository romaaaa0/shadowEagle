using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Speed { get; set; } = 5;
    public bool IsDead { get; set; }
    public bool IsWon { get; set; }
    public Vector3 MovementDirection { get; private set; }
    public float Health { get; private set; } = 10;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject gameOverPanel;
    private IDie die;
    private float startHealth;
    public float HP;
    private void Start()
    {
        startHealth = Health;
        die = new DiePlayer(GetComponent<Animator>(), gameOverPanel);
    }
    private void Update()
    {
        HP = Health;
        if (IsDead || IsWon) return;
        die.Die();
        MovementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }
    public void AddHP(float amountHealth)
    {

        Health += amountHealth;
        healthBar.fillAmount += startHealth * amountHealth / 100;
        if (Health >= startHealth)
        {
            Health = startHealth;
        }
    }
    public void TakeAwayHealth(float damage)
    {
        Health -= damage;
        healthBar.fillAmount -= startHealth * damage / 100;
    }
}