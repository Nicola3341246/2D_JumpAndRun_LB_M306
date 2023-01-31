using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D EnemyBody;
    [SerializeField] float walkSpeed;
    float walkDirection = 1;
    [SerializeField] string spielerTag;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        if (EnemyBody.velocity.x == 0 && walkDirection == 1)
        {
            walkDirection = -1;
        }
        else if (EnemyBody.velocity.x == 0 && walkDirection == -1)
        {
            walkDirection = 1;
        }
        EnemyBody.velocity = new Vector2(walkDirection * walkSpeed * 5, EnemyBody.velocity.y);



    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == spielerTag)
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            
        }
    }

    

}
