using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

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

    public int kolvomat_a2;
    public int kolvomat_b2;

    public int numfabric=0;

    private bool spawn;    //for lerp to snap
    private GameObject snap_point;
    private GameObject obj_spawn;

    private int layerMaskWithoutPlayer=1;

 //   private LineRenderer lr;

    public GameObject[] masssnap = new GameObject[0];

    private void Start()
    {
     //   lr = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        if (numfabric==1)
        {
            UI2.text= "There are " + kolvomat.ToString() + " out of 3 blocks of wood in the factory";

            if (kolvomat >=3)
            {
                isActive = true;
                UI.text = "Resource production...";
            }
            else
            {
                UI.text = "There are no materials";
                isActive = false;
            }
        }

        if (numfabric == 2)
        {
            UI2.text = kolvomat_a2.ToString()+"/3 blocks of wood and "+kolvomat_b2.ToString()+ "/3 blocks of coal";

            if (kolvomat_a2 >= 3 && kolvomat_b2>=3)
            {
                isActive = true;
                UI.text = "Resource production...";
            }
            else
            {
                UI.text = "There are no materials";
                isActive = false;
            }
        }


        if (isActive && numfabric==0)
        {          
         //   lr.enabled = true;
       //     lr.SetPosition(0, transform.position);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMaskWithoutPlayer))
            {
                if (hit.collider)
                {
            //        lr.SetPosition(1, hit.point);
                    bool check = true;
                    if (masssnap.Length==5)
                    {
                        for (int i = 0; i < masssnap.Length; i++)
                        {
                            if (!masssnap[i].GetComponent<CheckFull>().isYEs)
                            {
                                check = false;
                            }

                        }
                        if (!check)
                        {
                            UI.text = "Resource production...";
                        }
                        else
                        {
                            UI.text = "There is no place in the factory";
                        }
                    }
                    
                }
                if (hit.collider.tag=="snap_zone")
                {
                    if (Array.IndexOf(masssnap,hit.collider.gameObject)==-1)
                    {
                        Array.Resize(ref masssnap,masssnap.Length+1);
                        masssnap[masssnap.Length - 1] = hit.collider.gameObject;
                    }
                    spawn = true;
                    snap_point = hit.collider.gameObject;
                    obj_spawn = Instantiate(material, gameObject.transform.position, gameObject.transform.rotation);
                }
            }
            else
            {
         //       lr.SetPosition(1, transform.forward * 5000);
            }
        }
        else if(!isActive && numfabric==0)
        {
       //     lr.enabled = false;
        }

        if (isActive && numfabric == 1)
        {
      //      lr.enabled = true;
    //        lr.SetPosition(0, transform.position);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMaskWithoutPlayer))
            {
                if (hit.collider)
                {        
          //          lr.SetPosition(1, hit.point);
                }
                if (hit.collider.tag == "snap_zone")
                {
                    if (Array.IndexOf(masssnap, hit.collider.gameObject) == -1)
                    {
                        Array.Resize(ref masssnap, masssnap.Length + 1);
                        masssnap[masssnap.Length - 1] = hit.collider.gameObject;
                    }
                    spawn = true;
                    snap_point = hit.collider.gameObject;
                    obj_spawn = Instantiate(material, gameObject.transform.position, gameObject.transform.rotation);
                    kolvomat--;
                }
            }
            else
            {
    //            lr.SetPosition(1, transform.forward * 5000);
            }
        }
        else if (!isActive && numfabric == 1)
        {
//            lr.enabled = false;
        }

        if (isActive && numfabric == 2)
        {
    //        lr.enabled = true;
  //          lr.SetPosition(0, transform.position);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMaskWithoutPlayer))
            {
                if (hit.collider)
                {
           //         lr.SetPosition(1, hit.point);
                   
                }
                if (hit.collider.tag == "snap_zone")
                {
                    if (Array.IndexOf(masssnap, hit.collider.gameObject) == -1)
                    {
                        Array.Resize(ref masssnap, masssnap.Length + 1);
                        masssnap[masssnap.Length - 1] = hit.collider.gameObject;
                    }
                    if (masssnap.Length<1)
                    {
                        UI.text = "Resource production...";
                    }
                    spawn = true;
                    snap_point = hit.collider.gameObject;
                    obj_spawn = Instantiate(material, gameObject.transform.position, gameObject.transform.rotation);
                    kolvomat_a2 -= 2;
                    kolvomat_b2 -= 1;
                }
            }
            else
            {
     //           lr.SetPosition(1, transform.forward * 5000);
            }
        }
        else if (!isActive && numfabric == 2)
        {
    //        lr.enabled = false;
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

        if (numfabric == 1)
        {
            bool check = true;
            if (masssnap.Length ==3)
            {
                for (int i = 0; i < masssnap.Length; i++)
                {
                    if (!masssnap[i].GetComponent<CheckFull>().isYEs)
                    {
                        check = false;
                    }

                }
                if (check)
                {
                    UI.text = "There is no place in the factory";
                }
      
            }
        }
        else if (numfabric == 2)
        {
            bool check = true;
            if (masssnap.Length == 1)
            {
                for (int i = 0; i < masssnap.Length; i++)
                {
                    if (!masssnap[i].GetComponent<CheckFull>().isYEs)
                    {
                        check = false;
                    }

                }
                if (check)
                {
                    UI.text = "There is no place in the factory";
                }
            }
        }
    }
}
