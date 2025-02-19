using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("基本属性")]
    [SerializeField] protected float health;

    [SerializeField] protected float Damage;
    [SerializeField] protected float speed;
    protected Rigidbody2D rb2;
}
