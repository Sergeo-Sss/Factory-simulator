using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Brus_fabric : MonoBehaviour
{
    public TMP_Text timerText;
    public float res = 3;
    float cntdnw;

    public GameObject[] snapzones;
    public GameObject brus;

    private GameObject[] objects = new GameObject[9];

    public GameObject snappoint;

    private int i = 0;
    private bool isstart = false;


    private void Start()
    {
        cntdnw = res;
       
        StartCoroutine(Wait());
        
       
    }

    IEnumerator Wait()
    {
        isstart = true;
        yield return new WaitForSeconds(res);
        if (i==snapzones.Length)
        {
            i = 0;
        }
        for (int k=0;k<snapzones.Length;k++)
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
            objects[i] = go;
            go.transform.SetParent(snapzones[i].transform);
            snapzones[i].GetComponent<CheckMat>().isYes = true;
        }
        
        i++;
        StartCoroutine(Wait());
    }


    IEnumerator LerpNum(Vector3 go, Vector3 spawn, GameObject obj)
    {
        while (Vector3.Distance(go,spawn)>0.01f)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position,spawn,1f);
        }
        yield return null;
    }
    
    void Update()
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
            snappoint.GetComponent<LerpFabric>().SetMassiv(objects, snapzones);
            snappoint.GetComponent<LerpFabric>().isStart = true;
        }
    }
}
