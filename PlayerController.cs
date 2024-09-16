using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed=5;
    private Vector3 input;

    void Update(){
        GatherInput();
        Look();
        
    }

    void FixedUpdate(){
        Move();
        Jump();
        
    }

    void GatherInput(){
        input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));

    }

    void Look(){

        if(input !=Vector3.zero){

            var relative = (transform.position + input)-transform.position;
            var rot = Quaternion.LookRotation(relative,Vector3.up);

            transform.rotation=rot;
           

        }
        
    }

    void Move(){
        rb.MovePosition(transform.position + (transform.forward*input.magnitude) * speed * Time.deltaTime);

    }

    void Jump(){
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector3.up*100);
        }
    }
}
