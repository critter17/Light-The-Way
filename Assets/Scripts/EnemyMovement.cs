using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public int health;
    public GameObject doorGameObject;

    // Animation Objects
    public Animator enemyAnim;

    // Movement Waypoints
    public Transform[] waypoints;
    public int currentWaypoint;
    public float delay;

    private void Start()
    {
        currentWaypoint = 0;
        transform.position = waypoints[currentWaypoint].transform.position;
        delay = 5.0f;
    }

    private void Update()
    {
        //if(health <= 0)
        //{
        //    //PlayHurtAnimation();
        //    Destroy(gameObject);
        //    doorGameObject.SetActive(true);
        //}

        if(transform.position != waypoints[currentWaypoint].position && health > 0)
        {
            Vector2 pos = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, moveSpeed * Time.deltaTime);
            //float newX = Mathf.RoundToInt(pos.x);
            //float newY = Mathf.RoundToInt(pos.y);
            GetComponent<Rigidbody2D>().MovePosition(pos);
        }
        else
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;

        //if(Input.GetKeyDown(KeyCode.Space))
        //    enemyAnim.SetTrigger("HurtTrigger");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interact")
        {
            SceneManager.LoadScene("Game Scene");
        }
    }

    public void HurtEnemy()
    {
        PlayHurtAnimation();
        health -= 1;
    }

    public void PlayHurtAnimation()
    {
        enemyAnim.SetTrigger("HurtTrigger");
        StartCoroutine("HurtAnim", 1.0f);
        //if(health <= 0)
        //{

        //    StartCoroutine("StopMoving", 1.0f);
        //}
    }

    IEnumerator HurtAnim(float time)
    {
        yield return new WaitForSeconds(time);
        enemyAnim.SetTrigger("HurtTrigger");
        if(health <= 0)
        {
            Destroy(gameObject);
            doorGameObject.SetActive(true);
        }
    }
}
