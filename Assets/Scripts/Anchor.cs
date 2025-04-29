using UnityEngine;

public class Anchor : MonoBehaviour
{
    const float SPEED_OF_LIGHT = 299_792_458f;

    public void OnMessageReceived(MessageData message)
    {
        float receiveTime = MessageBus.Instance.GetSimulatedTime();  // Access via getter
        float elapsed = receiveTime - message.sendTime;  // Time it took for the message to travel
        float estimatedDistance = elapsed * SPEED_OF_LIGHT;  // Estimated distance based on light-speed delay

        float actualDistance = Vector3.Distance(transform.position, message.sender.transform.position);
        float error = Mathf.Abs(estimatedDistance - actualDistance);  // Compare with actual distance

        // Output the results to the console
        Debug.Log($"{name} received message from {message.sender.name} at {receiveTime:F6}");
        Debug.Log($"Estimated Distance: {estimatedDistance:F6} m, Actual Distance: {actualDistance:F6} m, Error: {error:F6} m");
    }
}