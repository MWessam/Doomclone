using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementComponent : MovementComponent
{
    [SerializeField] private float _speed;
    NavMeshAgent _agent;
    public override float Speed { get => _speed; set => _speed = value; }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = Speed;
    }
    public override void Move()
    {
        _agent.SetDestination(Player.PlayerCurrentPos.position);
    }
}
