using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Speed
    {
        get { return speed; }
        set
        {
            speed = value;
            if (speed < 0)
                throw new ArgumentException("Ўвидк≥сть Player не може бути менше 0");
        }
    }
    public bool IsRunning { get; set; }
    public bool IsFighting { get; set; }
    public bool IsIdle { get; set; }
    public Vector3 MovementDirection { get; private set; }
    public float Hp = 10;
    private bool isDead = false;
    public Animator AnimatorController;
    private int speed = 5;
    private IMovement movement;
    private IRotation rotation;
    public float magnitudePlayer;
    private void Start()
    {
        movement = new PlayerMovement(this);
        rotation = new RotationPlayer(this);
    }
    private void Update()
    {
        if (isDead) return;

        if (Hp <= 0)
        {
            Die();
            return;
        }
        MovementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        movement.Move();
        rotation.Rotation();

    }
    private void Die()
    {
        isDead = true;
        AnimatorController.SetTrigger("Die");
        SceneManager.Instance.GameOver();
    }
    public void AddHP()
    {
        Hp++;
    }
}