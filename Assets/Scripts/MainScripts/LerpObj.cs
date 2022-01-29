using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpObj : MonoBehaviour
{
    public bool isLerp = false;
    public GameObject snappoint;
    public GameObject spawnpoint;

    public bool isready=false;

    private void FixedUpdate()
    {
        if (isLerp)
        {
            if (Mathf.Abs(Vector3.Distance(this.gameObject.transform.position, spawnpoint.transform.position)) > 0.01f)
            {
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, spawnpoint.transform.position, 15f * Time.deltaTime);
            }
            else
            {
                this.gameObject.transform.SetParent(snappoint.transform);
                this.gameObject.transform.rotation = snappoint.transform.rotation;
                spawnpoint.transform.position = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y+1, spawnpoint.transform.position.z);
                isLerp = false;
            }
        }

        if (GameObject.Find("Player").GetComponent<PlayerController>().gotofinal)
        {
            
            if (this.gameObject.tag == "carbon")
            {
                if (this.gameObject.transform.parent != null)
                {
                    if (Mathf.Abs(Vector3.Distance(this.gameObject.transform.position, GameObject.Find("Player").GetComponent<PlayerController>().readobj.transform.position)) > 0.01f)
                    {
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, GameObject.Find("Player").GetComponent<PlayerController>().readobj.transform.position, 15f * Time.deltaTime);
                    }
                    else
                    {
                        Destroy(this.gameObject);
                        GameObject.Find("Player").GetComponent<PlayerController>().KolvoMat--;
                        GameObject.FindGameObjectWithTag("final").GetComponent<CarbonHouse>().KolvoCarb++;
                        spawnpoint.transform.position = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y - 1, spawnpoint.transform.position.z);
                        GameObject.Find("Player").GetComponent<PlayerController>().gotofinal = false;
                        
                    }
                }
            }
            else
            {
                if (this.gameObject.transform.parent != null)
                {
                    if (Mathf.Abs(Vector3.Distance(this.gameObject.transform.position, GameObject.Find("Player").GetComponent<PlayerController>().readobj.transform.position)) > 0.01f)
                    {
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, GameObject.Find("Player").GetComponent<PlayerController>().readobj.transform.position, 15f * Time.deltaTime);
                    }
                    else
                    {
                        Destroy(this.gameObject);
                        GameObject.Find("Player").GetComponent<PlayerController>().KolvoMat--;
                        spawnpoint.transform.position = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y - 1, spawnpoint.transform.position.z);
                        GameObject.Find("Player").GetComponent<PlayerController>().gotofinal = false;
                    }
                }
            }

        }

        if (GameObject.Find("Player").GetComponent<PlayerController>().lerpto1fabric)
        {
            
            if (this.gameObject.tag=="brus")
            {
                if (this.gameObject.transform.parent != null)
                {
                    isready = true;
                    if (Mathf.Abs(Vector3.Distance(this.gameObject.transform.position, GameObject.Find("Player").GetComponent<PlayerController>().readobj.transform.position)) > 0.01f)
                    {
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, GameObject.Find("Player").GetComponent<PlayerController>().readobj.transform.position, 15f * Time.deltaTime);
                    }
                    else
                    {
                        //       this.gameObject.transform.SetParent(null);
                        Destroy(this.gameObject);
                        GameObject.Find("Player").GetComponent<PlayerController>().KolvoMat--;
                        GameObject.FindGameObjectWithTag("factory2").GetComponent<FabricLogic>().kolvomat++;
                        spawnpoint.transform.position = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y - 1, spawnpoint.transform.position.z);
                        GameObject.Find("Player").GetComponent<PlayerController>().lerpto1fabric = false;
                      
                    }
                }
            }

        }

        if (GameObject.Find("Player").GetComponent<PlayerController>().lerpto2fabric)
        {
            if (this.gameObject.tag == "brus")
            {
                if (this.gameObject.transform.parent != null)
                {
                    if (Mathf.Abs(Vector3.Distance(this.gameObject.transform.position, GameObject.Find("Player").GetComponent<PlayerController>().readobj.transform.position)) > 0.01f)
                    {
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, GameObject.Find("Player").GetComponent<PlayerController>().readobj.transform.position, 15f * Time.deltaTime);
                    }
                    else
                    {
                        //       this.gameObject.transform.SetParent(null);
                        Destroy(this.gameObject);
                        GameObject.Find("Player").GetComponent<PlayerController>().KolvoMat--;
                        GameObject.FindGameObjectWithTag("factory3").GetComponent<FabricLogic>().kolvomat_a2++;
                        spawnpoint.transform.position = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y - 1, spawnpoint.transform.position.z);
                        GameObject.Find("Player").GetComponent<PlayerController>().lerpto2fabric = false;
                    }
                }
            }
            else if (this.gameObject.tag == "ugol")
            {
                if (this.gameObject.transform.parent != null)
                {
                    if (Mathf.Abs(Vector3.Distance(this.gameObject.transform.position, GameObject.Find("Player").GetComponent<PlayerController>().readobj.transform.position)) > 0.01f)
                    {
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, GameObject.Find("Player").GetComponent<PlayerController>().readobj.transform.position, 15f * Time.deltaTime);
                    }
                    else
                    {
                        //       this.gameObject.transform.SetParent(null);
                        Destroy(this.gameObject);
                        GameObject.Find("Player").GetComponent<PlayerController>().KolvoMat--;
                        GameObject.FindGameObjectWithTag("factory3").GetComponent<FabricLogic>().kolvomat_b2++;
                        spawnpoint.transform.position = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y - 1, spawnpoint.transform.position.z);
                        GameObject.Find("Player").GetComponent<PlayerController>().lerpto2fabric = false;
                    }
                }
            }

        }
    }
}
