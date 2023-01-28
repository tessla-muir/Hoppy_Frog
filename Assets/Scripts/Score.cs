using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Transform player;
    public GUIStyle style;

    public float maxHeight = 0;
    public float playerHeight = 0;

    void Update()
    {
        // Calculate the player height
        playerHeight = player.position.y;

        // Update maxHeight when player crosses it
        if (maxHeight < playerHeight) {
            maxHeight = playerHeight;
        }
    }

    void OnGUI() 
    {
        // Calculate and display the score
        style.fontSize = 25;
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(0, 0, 100, 50), "Max Height: " + Mathf.Round(maxHeight).ToString(), style);
    }
}
