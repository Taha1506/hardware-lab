using UnityEngine;

public class Tag : MonoBehaviour
{

    private static float antennaDelayMean = 5e-6;
    private static float antennaDelayStd = 1e-6;
    void Start()
    {
        GameObject[] anchors = GameObject.FindGameObjectsWithTag("Anchor");

        foreach (GameObject anchor in anchors)
        {
            MessageBus.Instance.SendMessageDelayed(gameObject, anchor, antennaDelayMean, antennaDelayStd);
        }
    }
}
