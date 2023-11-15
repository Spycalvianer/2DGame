using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HideableScript : MonoBehaviour
{
    public PlayerMechanics mechanics;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mechanics.canHide = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        mechanics.canHide = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        mechanics.canHide = false;
    }

}
