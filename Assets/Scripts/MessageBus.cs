using System;
using System.Collections.Generic;
using UnityEngine;

public class MessageBus : MonoBehaviour
{
    public static MessageBus Instance;

    const float SPEED_OF_LIGHT = 299_792_458f; // Speed of light in meters per second

    private List<ScheduledMessage> pending = new List<ScheduledMessage>(); // Pending messages
    private float simulatedTime = 0f;  // Simulated time independent of Unity's frame timing
    private static Random rand = new Random();

    // Structure to represent a message that will be delivered at a specific time
    class ScheduledMessage
    {
        public MessageData data;
        public float deliveryTime;
    }

    void Awake()
    {
        Instance = this;
    }

    // Function to simulate the passage of time
    public void SimulateTime(float deltaTime)
    {
        simulatedTime += deltaTime;  // Update simulated time based on the actual frame time
    }

    // Send message with simulated delay
    public void SendMessageDelayed(GameObject sender, GameObject receiver, float antennaDelayMean, float antennaDelayStd)
    {
        float distance = Vector3.Distance(sender.transform.position, receiver.transform.position);
        float delay = distance / SPEED_OF_LIGHT;  // Calculate delay based on speed of light
        double u1 = 1.0 - rand.NextDouble();
        double u2 = 1.0 - rand.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
        float antennaDelay = randStdNormal * antennaDelayStd + antennaDelayMean;
        float deliveryTime = simulatedTime + delay + antennaDelay;  // When the message will be delivered in the simulation time
        

        var message = new MessageData(sender, receiver, simulatedTime);  // The message carries the simulated send time
        pending.Add(new ScheduledMessage { data = message, deliveryTime = deliveryTime });
    }

    void Update()
    {
        // Simulate time based on the actual time elapsed in Unity
        SimulateTime(Time.deltaTime / 10000000f);

        // Deliver messages whose delivery time has passed based on the simulated time
        float now = simulatedTime;

        // Process all pending messages
        for (int i = pending.Count - 1; i >= 0; i--)
        {
            if (now >= pending[i].deliveryTime)  // If it's time to deliver the message
            {
                var msg = pending[i];
                pending.RemoveAt(i);  // Remove the message from the list

                // Deliver message to the receiver
                msg.data.receiver.SendMessage("OnMessageReceived", msg.data, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    // Getter for simulated time
    public float GetSimulatedTime()
    {
        return simulatedTime;
    }
}
