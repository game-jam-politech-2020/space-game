using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform player;
    public Transform reciever;
    

    private bool playerIsOverlapping = false;

    // Update is called once per frame
    void Update () {
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            // If this is true: The player has moved across the portal
            if (dotProduct < 0f)
            {
                Vector3 y =  new Vector3 (0f,(player.transform.position.y - transform.position.y),0f);
                float yDiff = y.y;
                Debug.Log(yDiff+ ":y");
                // Teleport him!
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset - y;
                

                playerIsOverlapping = false;

                
                
            }
        }
    }

    void OnTriggerEnter (Collider other)
    {
        Debug.Log("Залетел");
        playerIsOverlapping = true;
        
    }

    void OnTriggerExit (Collider other)
    {
        Debug.Log("ВЫлетел");
        playerIsOverlapping = false;
    }
}