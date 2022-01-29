using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Размер стека")]
    public int KolvoMat = 0;

    [Header("Для lerp на фабрики")]
    public bool lerpto1fabric = false;
    public bool lerpto2fabric = false;
    public bool gotofinal = false;

    public GameObject readobj;

    [Header("Родитель")]
    public GameObject snap_point;

    [Header("Спавн поинт")]
    public GameObject spawnpoint;

    private GameObject obj_spawn;

    private bool ischild = false;


    private void Update()
    {

        if (ischild)
        {
            for (int i = 0; i < snap_point.transform.childCount; i++)
            {
                if (i == 0)
                {
                    snap_point.transform.GetChild(i).localPosition = new Vector3(0,0,0);

                }
                else
                {
                    snap_point.transform.GetChild(i).localPosition = new Vector3(snap_point.transform.GetChild(i-1).localPosition.x+0.1f, snap_point.transform.GetChild(i-1).localPosition.y, snap_point.transform.GetChild(i-1).localPosition.z);
                }
            }
            ischild = false;
        }
    }

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

            bool check = false;
            for (int i = 0; i < snap_point.transform.childCount; i++)
            {
                if (snap_point.transform.GetChild(i).GetComponent<LerpObj>().isready)
                {
                    check = true;
                }
            }
            if (!check)
                ischild = true;
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
