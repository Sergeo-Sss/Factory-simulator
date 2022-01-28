using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class Ugol_fabric : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text resursText;
    public float res = 3;
    float cntdnw;

    public GameObject[] snapzones;
    public GameObject snappoint;
    public GameObject brus;

    private int i = 0;
    private bool isstart = false;

    private Vector3 gos;
    private Vector3 spawn;

    public bool isactivefabric = true;

    public int kolvoMat = 0;
    float timeleft;

   public int kolvo = 0;

    private bool ischeck = false;

    private GameObject[] objects = new GameObject[5];

    private void Start()
    {
        cntdnw = res;
        timeleft = res;
    }

  
    void Update()
    {
        resursText.text = "There are " + kolvoMat.ToString()+ " out of 5 resources in stock";
        if (kolvoMat == 0)
        {
            timerText.text = "No raw materials";
            isactivefabric = false;
            ischeck = false;
        }

        if (kolvo < objects.Length)
        {
            if (objects[kolvo] != null)
            {
                if (Vector3.Distance(objects[kolvo].transform.position, snapzones[kolvo].transform.position) > 0.01f)
                {
                    objects[kolvo].transform.position = Vector3.Lerp(objects[kolvo].transform.position, snapzones[kolvo].transform.position, 10f * Time.deltaTime);
                }
                else
                {
                    kolvo++;
                }
            }


        }
        if (isactivefabric == true)
        {
            isstart = true;
            if (timeleft>0)
            {
                timeleft -= Time.deltaTime;
            }
            else if (timeleft<=0)
            {
                kolvoMat--;

                if (i == snapzones.Length)
                {
                    i = 0;
                }
                for (int k = 0; k < snapzones.Length; k++)
                {
                    if (snapzones[k].GetComponent<CheckMat>().isYes == false)
                    {
                        i = k;
                        break;
                    }
                }
                if (snapzones[i].GetComponent<CheckMat>().isYes == false)
                {
                    GameObject go = Instantiate(brus, snappoint.transform.position, snappoint.transform.rotation);

                    //Array.Resize(ref objects, objects.Length + 1);
                    //objects[objects.Length - 1] = go;
                    objects[i] = go;


                    go.transform.SetParent(snapzones[i].transform);
                    snapzones[i].GetComponent<CheckMat>().isYes = true;

                }

                i++;
                timeleft = res;
                ischeck = true;
            }

        }
        if (isactivefabric == true)
        {
            int check = 0;
            for (int i = 0; i < snapzones.Length; i++)
            {
                if (snapzones[i].GetComponent<CheckMat>().isYes == true)
                {
                    check++;

                }
            }
            if (isstart && check != snapzones.Length)
            {
                if (cntdnw > 0)
                {
                    cntdnw -= Time.deltaTime;
                }
                double b = System.Math.Round(cntdnw, 0);
                timerText.text = "Next through " + b.ToString() + " " + "...";
                if (cntdnw < 0)
                {
                    cntdnw = res;
                    isstart = false;

                }

            }
            else if (isstart && check == snapzones.Length)
            {
                timerText.text = "There is no place in the warehouse.";
            }
        }

        

    }
}
