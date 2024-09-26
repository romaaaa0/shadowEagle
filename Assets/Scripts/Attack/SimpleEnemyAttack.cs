﻿using UnityEngine; 
using UnityEngine.AI;

public class SimpleEnemyAttack : EnemyAttack
{
    protected override float attackDelayTime { get; set; } = 2;
    protected override float damage { get; set; } = 1;
}
