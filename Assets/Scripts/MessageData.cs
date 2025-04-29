using UnityEngine;

public class MessageData
{
    public GameObject sender;
    public GameObject receiver;
    public float sendTime;

    public MessageData(GameObject sender, GameObject receiver, float sendTime)
    {
        this.sender = sender;
        this.receiver = receiver;
        this.sendTime = sendTime;
    }
}