using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightbulbPickup : MonoBehaviour, IPickup
{
    [SerializeField] private bool canPickup = false;
    [SerializeField] private bool noLightbulb = false;

    private void Update()
    {
        if (Input.GetButtonDown("Pickup") && canPickup)
        {
            Pickup();
        }
    }

    public void Pickup()
    {
        // Player's Animation State Change
        // Lightbulb GameObject destroyed

        PlayerMovement player = FindObjectOfType<PlayerMovement>();

        if (player == null || noLightbulb) return;

        player.playerAnimator.SetBool("HasLightbulb", true);
        canPickup = false;
        Transform lightbulb = transform.GetChild(0);
        lightbulb.gameObject.SetActive(false);
        noLightbulb = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.CompareTo("Player") == 0)
        {
            canPickup = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.CompareTo("Player") == 0)
        {
            canPickup = false;
        }
    }
}
