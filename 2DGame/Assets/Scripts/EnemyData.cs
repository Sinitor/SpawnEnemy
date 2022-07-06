using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemies",fileName ="New Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private Sprite sr;
    public Sprite MainSR
    {
        get { return sr; }
        protected set { }
    }
    [SerializeField] private float speed; 
    public float MainSpeed
    {
        get { return speed; } 
        protected set { }
    }
    [SerializeField] private float attack; 
    public float MainAttack
    {
        get { return attack; } 
        protected set { }
    }
}
