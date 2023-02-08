using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelicanFunctions : MonoBehaviour
{
    //TODO: improve with event handler
    public void JumpInit()
    {
        Pelican.GetInstance().AddForce();
    }
    public void TurnOffCollider()
    {
        Pelican.GetInstance().TunrOffCollider();
    }
}
