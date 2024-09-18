using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlPlayer : MonoBehaviour
{

    public CharacterController ch;
    public float movespeed;
    float speed;

    public float jump = 0;
    public float isjump;
    public float timjump;


    public float recoil = 0;
    public float moussansfti = 1;


    public bool louckcrous =true;

    public Animator an;

   //PhotonView v;
  
    // Start is called before the first frame update
    void Start()
    {
        speed = movespeed;

        if (louckcrous)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

      
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            if( louckcrous == true)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                louckcrous = false;
            }
            else
            {
                louckcrous = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            

        }

      

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            an.SetBool("run", true);
            speed = movespeed * 1.5f;
        }
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
           an.SetBool("run", false);
            speed = movespeed;
        }
      
        
     
    }
    private void FixedUpdate()
    {
      
        
      
      
           

        
      
        ////
        bool aais;
        if (ch.isGrounded)
        {
            
            aais = true;
        }
        else
        {
            aais = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && aais == true)
        {
            jump = isjump;
           
         
        }
        else
        {
            if (aais == false)
            {
                jump -= isjump * timjump * Time.deltaTime;
              
            }

        }
        ///
          an.SetFloat("X", Input.GetAxisRaw("Vertical"));
         an.SetFloat("Y", Input.GetAxisRaw("Horizontal"));

        Vector2 vulompv = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        vulompv.Normalize();

      
        //

      

        Vector3 velocity = (transform.forward * vulompv.y + transform.right * vulompv.x) * speed   + Vector3.up * jump;
        ch.Move(velocity * Time.deltaTime);
 
    }
}
