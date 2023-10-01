using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicsActivation : MonoBehaviour
{
    PlayerMechanics playerController;
    public enum Parameter { dashActivated, doubleJumpActivated, upwardsDashActivated }
    public Parameter type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerController = collision.GetComponent<PlayerMechanics>();
            Activatepram(type);
            Destroy(gameObject);
        }
    }
    void Activatepram(Parameter par)
    {
        if(par == Parameter.dashActivated)
        {
            playerController.dashActivated = true;
        }
        else if(par == Parameter.doubleJumpActivated)
        {
            playerController.doubleJumpActivated = true;
        }
        else if (par == Parameter.upwardsDashActivated)
        {
            playerController.upwardsDashActivated = true;
        }
    }
}
