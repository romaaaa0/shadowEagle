using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Speed { get; set; } = 5;
    public bool IsRunning { get; set; }
    public bool IsFighting { get; set; }
    public bool IsIdle { get; set; }
    public bool IsDead { get; set; }
    public Vector3 MovementDirection { get; private set; }
    public float Hp { get; set; } = 10;
    public Animator AnimatorController;
    private IDie die;
    private void Start()
    {
        die = new DiePlayer();
    }
    private void Update()
    {
        if (IsDead) return;
        die.Die();
        MovementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }
    public void AddHP() => Hp++;
}