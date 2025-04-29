using UnityEngine;

public class Tag : MonoBehaviour
{
    void Start()
    {
        GameObject[] anchors = GameObject.FindGameObjectsWithTag("Anchor");

        foreach (GameObject anchor in anchors)
        {
            MessageBus.Instance.SendMessageDelayed(gameObject, anchor);
        }
    }
}