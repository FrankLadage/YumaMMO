using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementObject : MonoBehaviour {

    Animator anim;

    private Vector2 targetPosition;



    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        //Mouseclick to move to location
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //Walk Animation
        if (targetPosition != Vector2.zero)
        {
            anim.SetBool("iswalking", true);
            anim.SetFloat("input_x", targetPosition.x);
            anim.SetFloat("input_y", targetPosition.y);
        }
        else
        {
            anim.SetBool("iswalking", false);
        }

        //Movement Speed Formula
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * 2);
    }
}