using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;
    //Rigidbody��theRB�ƒ�`
    public Rigidbody theRB;
    public Animator animator;
    Vector3 movement;

    int muki = 0;

    // Update is called once per frame
    void Update()
    {
        //x���̈ړ���Horizontal(���E�����L�[��)����擾����
        movement.x = Input.GetAxisRaw("Horizontal");

        //z���̈ړ���Vertical(�㉺�����L�[��)����擾����
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
        //�ړ����x����t���[�BsqrMagnitude�͋����v�Z�Ɏg�p�����炵��
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate()
    {
        //theRB�̈ړ���̈ʒu�����肷�邽�߂̎�
        theRB.MovePosition(theRB.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    void rightmuki() 
    {
        animator.SetBool("IDLE2", false);
    }
}
