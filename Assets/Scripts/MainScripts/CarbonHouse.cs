using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CarbonHouse : MonoBehaviour
{
    [Header("Количество карбона")]
    public int KolvoCarb = 0;

    [Header("UI")]
    public TMP_Text text;

    public GameObject UI_victory;

    private void Update()
    {
        text.text = KolvoCarb.ToString()+ "/3 carbon blocks";
        if (KolvoCarb==3)
        {
            GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>().enabled=false;
            UI_victory.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
