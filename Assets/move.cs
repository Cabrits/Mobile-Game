using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject player;

    public void OnPointerClick()
    {
        player.GetComponent<Movement>().targetPosition = Input.mousePosition;
        player.GetComponent<Movement>().targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(player.GetComponent<Movement>().targetPosition.x, player.GetComponent<Movement>().targetPosition.y, 0.0f));

    }
}
