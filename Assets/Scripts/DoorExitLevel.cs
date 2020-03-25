using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExitLevel : MonoBehaviour
{
    public Transform spawnPosition;
    private PlayerMovement playerMovement;
    public GameObject cameraGameObject;
    public Transform levelGameObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Interact")
        {
            GameObject player = collision.transform.parent.gameObject;
            playerMovement = player.GetComponent<PlayerMovement>();
            if (spawnPosition != null)
            {
                playerMovement.canMove = false;
                player.transform.position = spawnPosition.position;
                cameraGameObject.transform.position = new Vector3(levelGameObject.position.x, levelGameObject.position.y, cameraGameObject.transform.position.z);
                StartCoroutine(MovingLevel(0.15f));
            }
            else
            {
                SceneManager.LoadScene("Thanks For Playing!");
            }
        }
    }

    IEnumerator MovingLevel(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        playerMovement.canMove = true;
    }
}
