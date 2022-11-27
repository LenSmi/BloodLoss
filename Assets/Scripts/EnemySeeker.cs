using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySeeker : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent agent;
    public float speed;
    public Transform player;

    public bool isRunning;
    public bool isHunting;
    public bool isSpawned;

    public int distance = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (isHunting)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        //agent.Move(player.position);
        agent.SetDestination(player.position);
        anim.Play("Armature_Run");
    }

   
}
