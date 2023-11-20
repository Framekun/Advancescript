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
    [SerializeField] private string HitboxName;
    private Animator Anim;

    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Player == null)
        {
            var PlayerObject = GameObject.FindGameObjectWithTag("Player");
            if (PlayerObject != null)
            {
                Player = PlayerObject.transform;
            }
            else
            {
                return;
            }
        }

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
            Anim.SetBool("seePlayer", true);
            Debug.Log("follow player");
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
            Anim.SetBool("seePlayer", false);
            Debug.Log("not follow player");
        }

        EnemyRotation();
    }

    private void EnemyRotation()
    {
        if (transform.position.x < Player.position.x) //fix : if +x = look right
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (transform.position.x > Player.position.x) //fix : if -x = look left 
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == HitboxName)
        {
            Debug.Log("Get Hit!");
            Destroy(gameObject);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision2D)
    //{
    //    if (collision2D.gameObject.CompareTag("AttackHit"))
    //    {
    //        Debug.Log("Get Hit!");
    //        Destroy(gameObject);
    //    }
    //}
}
