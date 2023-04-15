using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Enemy
{
    //private Rigidbody enemyRB;
    //private GameObject player;
    public float speed = 3.0f;

    private Vector3 lookDirection;
    [SerializeField]
    //private Enemy enemy;


    // Start is called before the first frame update
    void Start()
    {
        //enemyRB = GetComponent<Rigidbody>();
        //player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = (player.transform.position - enemyTransform.position).normalized;
        //enemyRB.AddForce(lookDirection * speed);
        ForceAttack(lookDirection);
        if (enemyTransform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

}
