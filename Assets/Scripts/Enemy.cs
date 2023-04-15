using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    protected Rigidbody enemyRB;
    protected Transform enemyTransform;
    protected GameObject player;
    //protected float speed;

    private void Start()
    {
        //enemyRB = GetComponent<Rigidbody>();
        //enemyTransform = GetComponent<Transform>();
        //player = GameObject.Find("Player");
    }

    public virtual void ForceAttack(Vector3 direction) { }

    //public virtual float Speed { get; set; }
}
