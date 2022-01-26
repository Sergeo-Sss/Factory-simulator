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
        if (snapzones[i].GetComponent<CheckMat>().isYes == false)
        {
            GameObject go = Instantiate(brus, snapzones[i].transform.position, snapzones[i].transform.rotation);
            go.transform.SetParent(snapzones[i].transform);
            snapzones[i].GetComponent<CheckMat>().isYes = true;

        }
        
        i++;
        StartCoroutine(Wait());
    }

    
    void Update()
    {
        //for (int i=0;i<snapzones.Length;i++)
        //{
        //    if (snapzones[i].GetComponent<CheckMat>().isYes == false)
        //    {
        //        isstart = false;
        //    }
        //}
        if (isstart)
        {
            if (cntdnw > 0)
            {
                cntdnw -= Time.deltaTime;
            }
            double b = System.Math.Round(cntdnw, 0);
            timerText.text = "Next through "+b.ToString()+" "+"...";
            if (cntdnw < 0)
            {
                cntdnw = res;
                isstart = false;
               
            }
            
        }
        else
        {
            timerText.text = "No";
        }
    }
}
