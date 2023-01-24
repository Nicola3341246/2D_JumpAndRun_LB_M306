using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D EnemyBody;
    [SerializeField] float walkSpeed;
    float walkDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyBody.velocity= Vector3.zero;

    }
}
