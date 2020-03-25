using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightIllumination : MonoBehaviour
{
    public SpriteRenderer lightSR;
    public CircleCollider2D lightAttack;
    public SpriteRenderer lightSwitchSR;
    public Sprite switchOffSprite;
    public Sprite switchOnSprite;
    public Light firstLight;
    public BoxCollider2D switchBoxComponent;
    public GameObject doorGameObject;
    public Text timerText;
    public float waitTime;
    private int currentTime;
    private bool canInteract;

    private void Start()
    {
        currentTime = Mathf.RoundToInt(waitTime);
        canInteract = false;
    }

    private void Update()
    {
        if (canInteract && Input.GetButtonDown("Interact"))
        {
            lightSR.color = Color.yellow;
            if(lightAttack != null)
                lightAttack.enabled = true;
            lightSwitchSR.sprite = switchOnSprite;
            firstLight.enabled = true;
            switchBoxComponent.enabled = false;
            if (doorGameObject != null) doorGameObject.SetActive(true);
            timerText.enabled = true;
            StartCoroutine("SwitchTimer");
            StartCoroutine(SwitchCounter(waitTime));
        }

        if (currentTime <= 0)
        {
            StopCoroutine("SwitchTimer");
            currentTime = Mathf.RoundToInt(waitTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interact")
            canInteract = true;
    }

    IEnumerator SwitchTimer()
    {
        while (true)
        {
            timerText.text = currentTime.ToString();
            yield return new WaitForSeconds(1.0f);
            currentTime -= 1;
        }
    }

    IEnumerator SwitchCounter(float waitTimer)
    {
        yield return new WaitForSeconds(waitTimer);
        firstLight.enabled = false;
        if(lightAttack != null)
            lightAttack.enabled = false;
        lightSR.color = Color.white;
        if (doorGameObject != null) doorGameObject.SetActive(false);
        timerText.enabled = false;
        yield return new WaitForSeconds(1.0f);
        lightSwitchSR.sprite = switchOffSprite;
        switchBoxComponent.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Interact")
            canInteract = false;
    }
}
