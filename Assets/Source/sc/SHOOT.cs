using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SHOOT : MonoBehaviour
{
    Ray ay;
    RaycastHit hit;

    public Transform P1;
    public Transform P2;

    public ammo a;
    public Animator ani;
    
    public GameObject muzzl;

    public bool relodanimatin;

    float timeStamp ;
    public float fireRate ;

    bool run;
    public Transform cam0,cam1,cam2;

    
    // Start is called before the first frame update

    void Start()
    {
        relodanimatin = false;
       
    }


    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButton("Fire1") && relodanimatin == false && a.w.namperWeapons == 3&& a.Amoo > 0)
        {
              ani.SetBool("shotAouto", true);
                timeStamp = timeStamp - Time.deltaTime;
                if (timeStamp <= 0)
                {
                    timeStamp = fireRate;
                    shotting();
                }
            
        }
        else
        {
            ani.SetBool("shotAouto", false);
        }
        if (Input.GetButtonDown("Fire1") && relodanimatin == false && a.w.namperWeapons != 3 && a.w.namperWeapons != 0&& !IsMouseOverUI())
        {
            if (a.Amoo > 0)
            {
                shotting();
            }
        }


            //////
        if (relodanimatin)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
            {
                ani.SetBool("finixRelode",true);
                relodanimatin = false;
            }
        }
        else
        {
            ani.SetBool("finixRelode", false);
        }


        if ((Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)&& a.w.namperWeapons != 0)
        {
            ani.SetBool("walk", true);
        }
        else
        {
            ani.SetBool("walk", false);
        }

        if (Input.GetKey(KeyCode.RightShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }

        if (Input.GetButton("Fire2") && a.w.namperWeapons !=0&&!run)
        {
            cam0.position = cam2.position;
        }
        else
        {
            cam0.position = cam1.position;
        }

    }

    public void shotting()
    {
       
        ani.SetTrigger("shot");

        //
        //ADUI.clip = isamoFRDI;
        // ADUI.Play();
        //////
        if (a.w.namperWeapons == 1)
        {
            a.amopistol = a.amopistol - 1;
        }
        else if (a.w.namperWeapons == 2)
        {
            a.amoshotgun = a.amoshotgun - 1;
        }
        else if (a.w.namperWeapons == 3)
        {
            a.amoM16 = a.amoM16 - 1;
        }
        else if (a.w.namperWeapons == 4)
        {
            a.amoSniper = a.amoSniper - 1;
        }

        //
        // flashFRDI.Emit(1);
        //flash1FRDI.Emit(1);
        ay.origin = P1.position;
        ay.direction = P2.position - P1.position;
        if (Physics.Raycast(ay, out hit))
        {
            Debug.DrawLine(ay.origin, hit.point, Color.red, 1f); //khat mkan rasasa
                                                                 //EVCTE MAZZL
            var rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
            var effect = Instantiate(muzzl, hit.point, rotation) as GameObject;
            effect.transform.SetParent(vObjectContainer.root, true);

        }
    }

        public void norelod()
    {
        relodanimatin = false;
    }
    public void yesrelode()
    {
        relodanimatin = true;
    }
}
