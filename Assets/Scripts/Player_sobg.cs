using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_sobg : MonoBehaviour
{
    public GameObject spawn;
    private GameObject obj;
    public GameObject forobj;


    private GameObject _snap;
    private GameObject _obj;

    private int[] snap1del = new int[0];

    private bool gotosnap1 = false;

    private GameObject[] gotosnap = new GameObject[0];
    private GameObject[] no_gotosnap = new GameObject[0];

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "brus")
        {
            if (forobj.transform.childCount<=4)
            {
                other.gameObject.GetComponentInParent<CheckMat>().isYes = false;
                other.transform.rotation = spawn.transform.rotation;
                obj = other.gameObject;
                StartCoroutine(Lerp());
                other.gameObject.transform.SetParent(forobj.transform);
                spawn.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1f, spawn.transform.position.z);

            }
           
        }

        if (other.gameObject.tag=="ugol")
        {
            if (forobj.transform.childCount <= 4)
            {
                other.gameObject.GetComponentInParent<CheckMat>().isYes = false;
                other.transform.rotation = spawn.transform.rotation;
                obj = other.gameObject;
                StartCoroutine(Lerp());
                other.gameObject.transform.SetParent(forobj.transform);
                spawn.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1f, spawn.transform.position.z);

            }
        }

        if (other.gameObject.tag == "carbon")
        {
        }

        if (other.gameObject.tag == "snap1")
        {
            gotosnap1 = true;
           
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "snap1")
        {
            gotosnap1 = true;
            _snap = other.gameObject;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "snap1")
        {
            gotosnap1 = false;
        }
    }

    IEnumerator Lerp()
    {
        while (Vector3.Distance(obj.transform.position, spawn.transform.position) > 0.01f)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, spawn.transform.position, 1f);
        }
        yield return null;
    }

    int k = 0;

    private void Update()
    {
        if (gotosnap1)
        {
            for (int i = 0; i < forobj.transform.childCount; i++)
            {
                if (forobj.transform.GetChild(i).tag == "brus")
                {
                    GameObject go = forobj.transform.GetChild(i).gameObject;
                    forobj.transform.GetChild(i).SetParent(null);

                    Array.Resize(ref gotosnap, gotosnap.Length + 1);
                    gotosnap[gotosnap.Length - 1] = go;


                }
                //if (forobj.transform.GetChild(i).tag == "ugol")
                //{
                //    GameObject go = forobj.transform.GetChild(i).gameObject;

                //    Array.Resize(ref no_gotosnap, no_gotosnap.Length + 1);
                //    no_gotosnap[no_gotosnap.Length - 1] = go;


                //}
            }

            if (k<gotosnap.Length)
            {
                if (Vector3.Distance(gotosnap[k].transform.position, _snap.transform.position) > 0.01f)
                {
                    gotosnap[k].transform.position = Vector3.Lerp(gotosnap[k].transform.position, _snap.transform.position, 50f * Time.deltaTime);
                }
                else
                {
                    Destroy(gotosnap[k]);
                    gotosnap[k] = null;
                    k++;

                    GameObject.Find("factory_ugol").transform.GetComponent<Ugol_fabric>().kolvoMat++;
                   
          //          gotosnap[k].transform.position = new Vector3(gotosnap[k].transform.position.x, gotosnap[k].transform.position.y - 1, gotosnap[k].transform.position.z);
                    spawn.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y - 1f, spawn.transform.position.z);
                }
            }
     


           
        }
        if (GameObject.Find("factory_ugol").transform.GetComponent<Ugol_fabric>().kolvoMat == 5)
        {
            GameObject.Find("factory_ugol").transform.GetComponent<Ugol_fabric>().isactivefabric = true;
         //   GameObject.Find("factory_ugol").transform.GetComponent<Ugol_fabric>().kolvo = 0;
        }
    }
}
