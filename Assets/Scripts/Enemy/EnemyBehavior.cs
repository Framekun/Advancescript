using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private Transform[] WayPoints;
    [SerializeField] private Transform[] Hitbox;
    [SerializeField] private float MoveSpeed = 3f;
    [SerializeField] private float DetectionRadius = 5f;
    private int CurrentWaypointIndex = 0;
    private Transform Player;
    private bool FollowingPlayer = false;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) <= DetectionRadius)
        {
            FollowingPlayer = true;
        }
        else
        {
            FollowingPlayer = false;
        }

        if (FollowingPlayer)
        {
            Vector3 targetDirection = Player.position - transform.position;
            targetDirection.Normalize();
            transform.Translate(targetDirection * MoveSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 targetDirection = WayPoints[CurrentWaypointIndex].position - transform.position;
            targetDirection.Normalize();
            transform.Translate(targetDirection * MoveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, WayPoints[CurrentWaypointIndex].position) < 0.1f)
            {
                CurrentWaypointIndex = (CurrentWaypointIndex + 1) % WayPoints.Length;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("AttackHit"))
        {
            Debug.Log("Get Hit!");
            Destroy(gameObject);
        }
    }
}
