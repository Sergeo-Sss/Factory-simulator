using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("������ �����")]
    public int KolvoMat = 0;

    [Header("��� lerp �� �������")]
    public bool lerpto1fabric = false;
    public bool lerpto2fabric = false;
    public bool gotofinal = false;

    public GameObject readobj;

    [Header("��������")]
    public GameObject snap_point;

    [Header("����� �����")]
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
            if (KolvoMat <= 4)
            {
                other.gameObject.transform.GetComponent<BoxCollider>().enabled = false;
                other.gameObject.transform.GetComponent<LerpObj>().isLerp = true;
                other.gameObject.transform.GetComponent<LerpObj>().snappoint = snap_point;
                other.gameObject.transform.GetComponent<LerpObj>().spawnpoint = spawnpoint;
                KolvoMat++;
            }
        }
        if (other.gameObject.tag == "carbon")
        {
            if (KolvoMat <= 4)
            {
                other.gameObject.transform.GetComponent<BoxCollider>().enabled = false;
                other.gameObject.transform.GetComponent<LerpObj>().isLerp = true;
                other.gameObject.transform.GetComponent<LerpObj>().snappoint = snap_point;
                other.gameObject.transform.GetComponent<LerpObj>().spawnpoint = spawnpoint;
                KolvoMat++;
            }
        }

        if (other.gameObject.tag=="snap1")
        {
            lerpto1fabric = true;
            readobj = other.gameObject;
        }

        if (other.gameObject.tag == "snap2")
        {
            lerpto2fabric = true;
            readobj = other.gameObject;
        }

        if (other.gameObject.tag=="final")
        {
            gotofinal = true;
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
        if (other.gameObject.tag == "snap2")
        {
            lerpto2fabric = true;
            readobj = other.gameObject;
        }
        if (other.gameObject.tag == "final")
        {
            gotofinal = true;
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
        if (other.gameObject.tag == "snap2")
        {
            lerpto2fabric = false;
            readobj = other.gameObject;
        }
        if (other.gameObject.tag == "final")
        {
            gotofinal = false;
            readobj = other.gameObject;
        }
    }
}
