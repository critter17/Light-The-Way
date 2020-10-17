using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SmallLight : MonoBehaviour, IInteractable
{
    [SerializeField] private bool canInteract = false;
    [SerializeField] private bool noLightbulb = false;

    public delegate void RemoveHandler();
    public event RemoveHandler Removed;

    public delegate void ReturnHandler();
    public event ReturnHandler Returned;

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && canInteract)
        {
            Interact();
        }
    }

    public void Interact()
    {
        // Player's Animation State Change
        // Lightbulb GameObject destroyed

        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        Transform lightbulb;

        if (player == null) return;

        if (noLightbulb)
        {
            lightbulb = player.transform.GetChild(0).GetChild(0);
            lightbulb.SetParent(transform);
            lightbulb.SetAsFirstSibling();
            lightbulb.localPosition = Vector3.zero;
            lightbulb.localRotation = Quaternion.identity;
            lightbulb.localScale = Vector3.one;
            noLightbulb = false;

            Returned?.Invoke();
        }
        else
        {
            lightbulb = transform.GetChild(0);
            lightbulb.SetParent(player.transform.GetChild(0));
            lightbulb.localPosition = Vector3.zero;
            lightbulb.localRotation = Quaternion.identity;
            lightbulb.localScale = Vector3.one;
            noLightbulb = true;

            Removed?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.CompareTo("Player") == 0)
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.CompareTo("Player") == 0)
        {
            canInteract = false;
        }
    }
}
