using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    private EnemyData data; 

    public void Init(EnemyData _data)
    {
        data = _data;
        GetComponent<SpriteRenderer>().sprite = data.MainSR;
    } 
    public float Attack
    {
        get { return data.MainAttack; } 
        protected set { }
    }
    public static Action<GameObject> OnEnemyOverFly;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * data.MainSpeed);
        if (transform.position.y < -10 && OnEnemyOverFly != null)
        {
            OnEnemyOverFly(gameObject);
        }
    }
}
