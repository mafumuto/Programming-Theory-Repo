using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsEnemy : Enemy
{
    //INHERITANCE
    private float speed = 3.0f;

    private Vector3 lookDirection;

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        enemyTransform = GetComponent<Transform>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        lookDirection = (player.transform.position - transform.position).normalized;
        //enemyrb.addforce(lookdirection * speed);
        ForceAttack(lookDirection);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    //POLYMORPHISM ABSTRACTION
    public override void ForceAttack(Vector3 lookDirection)
    {

        enemyRB.AddForce(lookDirection * speed);
    }

    //ENCAPSULATION
    public float Speed { get => speed; set => speed = value; }

}
