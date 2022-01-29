using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Animator anim;
    private CharacterController controller;
    public float speed = 600.0f;
    public float turnSpeed = 400.0f;
    public FloatingJoystick floatingJoy;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }


    void Update (){

        Vector3 direction = Vector3.forward * floatingJoy.Vertical + Vector3.right * floatingJoy.Horizontal;
          
        if (direction * speed * Time.fixedDeltaTime != new Vector3(0,0,0))
        {
            anim.SetInteger("AnimationPar", 1);
            controller.Move(direction * speed * Time.fixedDeltaTime);
            transform.rotation = Quaternion.LookRotation(controller.velocity);
         //   transform.Rotate(0, direction.x * turnSpeed * Time.deltaTime, 0);
        }
        else
        {
            anim.SetInteger("AnimationPar", 0);
        }
    }
}
