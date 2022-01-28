using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int KolvoMat = 0;

    public bool lerpto1fabric = false;
    public GameObject readobj;

    [Header("Родитель")]
    public GameObject snap_point;

    [Header("Спавн поинт")]
    public GameObject spawnpoint;

    private GameObject obj_spawn;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="brus")
        {
            if (KolvoMat<=4)
            {
                other.gameObject.transform.GetComponent<BoxCollider>().enabled = false;
                other.gameObject.transform.GetComponent<LerpObj>().isLerp = true;
                other.gameObject.transform.GetComponent<LerpObj>().snappoint = snap_point;
                other.gameObject.transform.GetComponent<LerpObj>().spawnpoint = spawnpoint;
                KolvoMat++;
            }
           
        }
        if (other.gameObject.tag == "ugol")
        {

        }
        if (other.gameObject.tag == "carbon")
        {

        }

        if (other.gameObject.tag=="snap1")
        {
            lerpto1fabric = true;
            readobj = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "snap1")
        {
            lerpto1fabric = true;
            readobj = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "snap1")
        {
            lerpto1fabric = false;
            readobj = other.gameObject;
        }
    }
}
