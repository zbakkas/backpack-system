using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ammo : MonoBehaviour
{
    public int Amoo;
    public int MaxAmoo  ;

    public Text Tamo, Tmaxamo;

    public int addAmoo;
    //
    public int Amoo2 = 15;

    public Animator ani;

    bool relodd;

    public int amopistol2, amoshotgun2, amoM162, amoSniper2;
    public int amopistol, amoshotgun, amoM16, amoSniper;
    public int MAXamopistol, MAXamoshotgun, MAXamoM16, MAXamoSniper;

    public waopen w;
    // Start is called before the first frame update
    void Start()
    {
     
        Amoo = Amoo2;
        relodd = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        ///LAG REMOV THIS
        Tamo.text = Amoo.ToString();
        Tmaxamo.text = MaxAmoo.ToString();
        if (w.namperWeapons == 1)
        {
            Amoo = amopistol;
            Amoo2 = amopistol2;
            MaxAmoo = MAXamopistol;
        }
        if (w.namperWeapons == 2)
        {
            Amoo = amoshotgun;
            Amoo2 = amoshotgun2;
            MaxAmoo = MAXamoshotgun;
            
        }
        if (w.namperWeapons == 3)
        {
            Amoo = amoM16;
            Amoo2 = amoM162;
            MaxAmoo = MAXamoM16;

        }
        if (w.namperWeapons == 4)
        {
            Amoo = amoSniper;
            Amoo2 = amoSniper2;
            MaxAmoo = MAXamoSniper;

        }
        ////////
        if ((Input.GetKeyDown(KeyCode.R) && Amoo < Amoo2 && MaxAmoo >= 1)|| (Amoo == 0 && MaxAmoo > 0))
        {
            if (relodd)
            {
                ani.SetTrigger("relod");
                relodd = false;
            }
            
            StartCoroutine(waitingRelod());           
        }
        ///////////////////
     
        
    }

    IEnumerator waitingRelod()
    {
        yield return new WaitForSeconds(1.5f);
        relodd = true;
       
        if (MaxAmoo >= Amoo2)
        {
            if (w.namperWeapons == 1)
            {
                MAXamopistol -= Amoo2 - Amoo;
                amopistol += Amoo2 - Amoo;
            }
            if (w.namperWeapons == 2)
            {
                MAXamoshotgun -= Amoo2 - Amoo;
                amoshotgun += Amoo2 - Amoo;
            }
            if (w.namperWeapons == 3)
            {
                MAXamoM16 -= Amoo2 - Amoo;
                amoM16 += Amoo2 - Amoo;
            }
            if (w.namperWeapons == 4)
            {
                MAXamoSniper -= Amoo2 - Amoo;
                amoSniper += Amoo2 - Amoo;
            }

        }
        if (MaxAmoo < Amoo2 && MaxAmoo - (Amoo2 - Amoo) >= 1)
        {
            if (w.namperWeapons == 1)
            {
                MAXamopistol -= Amoo2 - Amoo;
                amopistol += Amoo2 - Amoo;
            }
            if (w.namperWeapons == 2)
            {
                MAXamoshotgun -= Amoo2 - Amoo;
                amoshotgun += Amoo2 - Amoo;
            }
            if (w.namperWeapons == 3)
            {
                MAXamoM16 -= Amoo2 - Amoo;
                amoM16 += Amoo2 - Amoo;
            }
            if (w.namperWeapons == 4)
            {
                MAXamoSniper -= Amoo2 - Amoo;
                amoSniper += Amoo2 - Amoo;
            }

        }
        if (MaxAmoo - (Amoo2 - Amoo) < 0)
        {
            if (w.namperWeapons == 1)
            {
                amopistol += MAXamopistol;
                MAXamopistol -= MAXamopistol;
            }
            if (w.namperWeapons == 2)
            {
                
                amoshotgun += MAXamoshotgun ;
                MAXamoshotgun -= MAXamoshotgun;
            }
            if (w.namperWeapons == 3)
            {
                amoM16 += MAXamoM16;
                MAXamoM16 -= MAXamoM16;
            }
            if (w.namperWeapons == 4)
            {

                amoSniper += MAXamoSniper;
                MAXamoSniper -= MAXamoSniper;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //z = GameObject.Find("FRDI").GetComponent<WAMOD>();
        //akhd = GameObject.Find("Player").GetComponent<AudioSource>();
        if (other.gameObject.tag == "amoofrdi")
        {
            //akhd.PlayOneShot(clakd);
            //Debug.Log("amozayed");
            //Destroy(gameObject);
            //Destroy(zombie, 4);
            //z.amo = z.amo + amooo;
            MaxAmoo = MaxAmoo + addAmoo;
            
        }
        //

        
    }


}
