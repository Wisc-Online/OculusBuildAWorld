﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    Animator animator;

    //The target player
    public Transform player;
    //At what distance will the enemy walk towards the player?
    public float walkingDistance = 20.0f;
    public float attackdistance = 4.0f;
    //In what time will the enemy complete the journey between its position and the players position
    public float smoothTime = 10.0f;
    //Vector3 used to store the velocity of the enemy
    private Vector3 smoothVelocity = Vector3.zero;

    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }


    //Call every frame
    void Update()
    {
        //Look at the player
        transform.LookAt(player);
        //Calculate distance between player
        float distance = Vector3.Distance(transform.position, player.position);
        //If the distance is smaller than the walkingDistance
  
            transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
        transform.position = new Vector3(transform.position.x, 0.0f,transform.position.z);


        if (distance < attackdistance)
        {
            animator.SetBool("ZombieisClose", true);
        }
        

    }
}
