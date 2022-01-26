using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sobg : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="brus")
        {
            other.gameObject.GetComponentInParent<CheckMat>().isYes = false;
            Destroy(other.gameObject);
            print("gg");
        }
    }
}
