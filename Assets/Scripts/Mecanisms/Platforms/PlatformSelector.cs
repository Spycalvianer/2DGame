using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSelector : MonoBehaviour
{
    public enum type {notMoving, movingAuto, playerMoves}
    public type platformType;
    public PlatformMoving movingPlatformScript;
    public PlatformPlayer playerMovesPlatformScript;
    public SpriteRenderer platformSprite;

    private void Start()
    {
        movingPlatformScript = GetComponent<PlatformMoving>();
        playerMovesPlatformScript = GetComponent<PlatformPlayer>();
        platformSprite = GetComponentInChildren<SpriteRenderer>();
        AsignarTipo();
    }
    void AsignarTipo()
    {
        switch (platformType)
        {
            case type.notMoving:
                movingPlatformScript.enabled = false;
                playerMovesPlatformScript.enabled = false;
                platformSprite.color = Color.white;
                break;
            case type.movingAuto:
                movingPlatformScript.enabled = true;
                playerMovesPlatformScript.enabled = false;
                platformSprite.color = Color.yellow;
                break;
            case type.playerMoves:
                playerMovesPlatformScript.enabled = true;
                movingPlatformScript.enabled = false;
                platformSprite.color = Color.red;
                break;
        }
    }
}
