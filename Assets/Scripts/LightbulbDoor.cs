using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightbulbDoor : MonoBehaviour
{
    [SerializeField] private SmallLight smallLight;

    // Start is called before the first frame update
    void Start()
    {
        smallLight.Removed += Close;
        smallLight.Returned += Open;
    }

    private void OnDestroy()
    {
        smallLight.Removed -= Close;
        smallLight.Returned -= Open;
    }

    private void Close()
    {
        transform.Translate(Vector3.down);
    }

    private void Open()
    {
        transform.Translate(Vector3.up);
    }
}
