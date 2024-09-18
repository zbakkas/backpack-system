using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waopen : MonoBehaviour
{
    public GameObject[] gun;//,cam;
    public int namperWeapons;
    int I;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        switchWeapons(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            I = 1;
        }//pestol
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            I = 2;
        }//shotgun
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            I = 3;
        }//m16
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            I = 4;
        }//sniper

        ///////
        if (Input.GetKeyDown(KeyCode.Alpha0+I))
        {
            if (namperWeapons == I)
            {
                switchWeapons(0);
            }
            else
            {
                switchWeapons(I);
            }
        }

        
    }
    public void switchWeapons(int index)
    {
        for(int i=0;i < gun.LongLength; i++)
        {
            gun[i].SetActive(false);
           // cam[i].SetActive(false);
            anim.SetBool("gun" + i, false);
        }

        gun[index].SetActive(true);
      //  cam[index].SetActive(true);
        namperWeapons = index;
        anim.SetBool("gun" + namperWeapons, true);
    }

}
