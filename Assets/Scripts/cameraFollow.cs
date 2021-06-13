using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControlle : MonoBehaviour
{
	public Transform player;

    void FixedUpdate()
    {
        transform.position = player.position;
    }
}
