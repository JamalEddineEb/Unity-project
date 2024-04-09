using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset; // Offset from the player's position

    void LateUpdate()
    {
        // Calculate the desired position behind the player
        Vector3 targetPosition = player.position - player.forward * offset.z + player.up * offset.y;

        // Set the position of the GameObject
        transform.position = targetPosition;

        // Make the GameObject look at the player
        transform.LookAt(player);
    }
}
