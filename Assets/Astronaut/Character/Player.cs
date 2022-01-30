using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Animator anim;
    private CharacterController controller;
    public float speed;
    public FloatingJoystick floatingJoy;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }


    void Update (){

        Vector3 direction = Vector3.forward * floatingJoy.Vertical + Vector3.right * floatingJoy.Horizontal;
          
        if (direction * speed * Time.deltaTime != new Vector3(0,0,0))
        {
            anim.SetInteger("AnimationPar", 1);
            controller.Move(direction * speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(controller.velocity);
        }
        else
        {
            anim.SetInteger("AnimationPar", 0);
        }
    }
}
