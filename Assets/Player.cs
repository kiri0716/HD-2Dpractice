using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;
    //RigidbodyをtheRBと定義
    public Rigidbody theRB;
    public Animator animator;
    Vector3 movement;

    int muki = 0;

    // Update is called once per frame
    void Update()
    {
        //x軸の移動はHorizontal(左右方向キー等)から取得する
        movement.x = Input.GetAxisRaw("Horizontal");

        //z軸の移動はVertical(上下方向キー等)から取得する
        movement.z = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        if(movement.x==1)
        {
            muki = 1;
        }
       
        if(movement.x==-1)
        {
            muki = -1;
        }

        if(muki==1)
        {
            animator.SetBool("IDLE2", true);
        }
        if(muki==-1)
        {
            animator.SetBool("IDLE2", false);
        }
        //if(muki==2)
        //if(muki==3)
        if (movement.z == 1|| movement.z == -1)
        {
            animator.SetBool("IDLE2", false);
        }

        animator.SetFloat("Vertical", movement.z);
        //移動速度決定フロー。sqrMagnitudeは距離計算に使用されるらしい
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate()
    {
        //theRBの移動後の位置を決定するための式
        theRB.MovePosition(theRB.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    void rightmuki() 
    {
        animator.SetBool("IDLE2", false);
    }
}
