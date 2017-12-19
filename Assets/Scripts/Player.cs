using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MovementObject {

    private Vector2 targetPosition;


    Animator anim;

    private int[] pathfinding;

    // Use this for initialization
    void Start () {
        targetPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(gameObject.transform.position.x);


            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;

            //Debug.Log(Math.Truncate(pz.x) + (0.5));

            //gameObject.transform.position = pz;







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


        }
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * 2);
    }
}
