using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFull : MonoBehaviour
{
    public bool isYEs = false;

    private void OnTriggerEnter(Collider other)
    {
        isYEs = true;
    }
    private void OnTriggerStay(Collider other)
    {
        isYEs = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isYEs = false;
    }
}
