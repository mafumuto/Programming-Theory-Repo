using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    private float speed = 6.0f;
    private Vector3 lookDirection;
    // Start is called before the first frame update
    void Start()
    {     
        enemyRB = GetComponent<Rigidbody>();
        
        enemyTransform = GetComponent<Transform>();
        enemyTransform.localScale *= 2;
        enemyRB.mass *= 2;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        lookDirection = (player.transform.position - transform.position).normalized;
        //enemyRB.AddForce(lookDirection * speed);
        ForceAttack(lookDirection);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    public override void ForceAttack(Vector3 lookDirection)
    {
        enemyRB.AddForce(lookDirection * speed);
    }
    public float Speed { get => speed; set => speed = value; }
}
