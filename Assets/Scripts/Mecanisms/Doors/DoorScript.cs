
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public SceneController sceneChangeScript;
    public string sceneName;
    bool playerInside;
    private void Awake()
    {
        sceneChangeScript = FindObjectOfType<SceneController>();
    }
    private void Update()
    {
        PlayerGoesNextScene();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInside = false;
        }
    }
    void PlayerGoesNextScene()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            sceneChangeScript.NextScene();
        }
    }
}
