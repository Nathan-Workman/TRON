using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    private void Start()
    {
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 currentPosition = collision.transform.position;

            if (currentPosition.x > screenBounds.x + objectWidth / 2)
            {
                currentPosition.x = -screenBounds.x - objectWidth / 2;
            }
            else if (currentPosition.x < -screenBounds.x - objectWidth / 2)
            {
                currentPosition.x = screenBounds.x + objectWidth / 2;
            }

            if (currentPosition.y > screenBounds.y + objectHeight / 2)
            {
                currentPosition.y = -screenBounds.y - objectHeight / 2;
            }
            else if (currentPosition.y < -screenBounds.y - objectHeight / 2)
            {
                currentPosition.y = screenBounds.y + objectHeight / 2;
            }

            collision.transform.position = currentPosition;
        }
    }
}