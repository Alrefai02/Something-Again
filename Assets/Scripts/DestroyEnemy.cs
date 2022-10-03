using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject player;

    public float distance = 0.02f;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.position =  Vector2.MoveTowards(transform.position,player.transform.position, distance * Time.deltaTime);
    }
}
