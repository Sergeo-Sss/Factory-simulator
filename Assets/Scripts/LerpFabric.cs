using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpFabric : MonoBehaviour
{
    public bool isStart = false;
    public GameObject[] massiv = new GameObject[9];
    public GameObject[] massiv_snap = new GameObject[9];

    public int kolvo = 0;

    public void SetMassiv(GameObject[] obj, GameObject[] snap)
    {
        massiv = obj;
        massiv_snap = snap;
    }

   
    void Update()
    {
        if (isStart)
        {
            if (kolvo<massiv.Length)
            {
                if (Vector3.Distance(massiv[kolvo].transform.position, massiv_snap[kolvo].transform.position) > 0.01f)
                {
                    massiv[kolvo].transform.position = Vector3.Lerp(massiv[kolvo].transform.position, massiv_snap[kolvo].transform.position, 10f * Time.deltaTime);
                    print("ff");
                }
                else
                {
                    kolvo++;
                }
            }
            else
            {
                
                isStart = false;
                kolvo = 0;
            }
            
        }

       
    }
}
