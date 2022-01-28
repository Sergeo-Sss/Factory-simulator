using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FabricLogic : MonoBehaviour
{
    [Header("Префаб сырья")]
    public GameObject material;

    [Header("Текст")]
    public TMP_Text UI;

    [Header("Текст для 2 фабрики")]
    public TMP_Text UI2;

    public bool isActive = false;
    public int kolvomat;
    private int kolvomat2;
    public int numfabric=0;

    private bool spawn;    //for lerp to snap
    private GameObject snap_point;
    private GameObject obj_spawn;

    private int layerMaskWithoutPlayer=1;

    private LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        if (numfabric==1)
        {
            UI2.text= "There are " + kolvomat.ToString() + " out of 3 resources in stock";

            if (kolvomat >=3)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }



        }
        

        if (isActive && numfabric==0)
        {
            lr.enabled = true;
            lr.SetPosition(0, transform.position);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMaskWithoutPlayer))
            {
                if (hit.collider)
                {
                    lr.SetPosition(1, hit.point);
                }
                if (hit.collider.tag=="snap_zone")
                {
                    spawn = true;
                    snap_point = hit.collider.gameObject;
                    obj_spawn = Instantiate(material, gameObject.transform.position, gameObject.transform.rotation);
                }
            }
            else
            {
                lr.SetPosition(1, transform.forward * 5000);
            }
        }
        else if(!isActive && numfabric==0)
        {
            lr.enabled = false;
        }

        if (isActive && numfabric == 1)
        {
            lr.enabled = true;
            lr.SetPosition(0, transform.position);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMaskWithoutPlayer))
            {
                if (hit.collider)
                {
                    lr.SetPosition(1, hit.point);
                }
                if (hit.collider.tag == "snap_zone")
                {
                    spawn = true;
                    snap_point = hit.collider.gameObject;
                    obj_spawn = Instantiate(material, gameObject.transform.position, gameObject.transform.rotation);
                    kolvomat--;
                }
            }
            else
            {
                lr.SetPosition(1, transform.forward * 5000);
            }
        }
        else if (!isActive && numfabric == 1)
        {
            lr.enabled = false;
        }

        if (spawn==true)
        {
            if (obj_spawn!=null)
            {
                if (Vector3.Distance(obj_spawn.transform.position, snap_point.transform.position) > 0.01f)
                {
                    obj_spawn.transform.position = Vector3.Lerp(obj_spawn.transform.position, snap_point.transform.position, 10f * Time.deltaTime);
                }
                else
                {
                    spawn = false;
                }
            }
          
        }
    }
}
