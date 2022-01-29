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
        text.text = KolvoCarb.ToString()+ "/5 carbon blocks";
        if (KolvoCarb==1)
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
