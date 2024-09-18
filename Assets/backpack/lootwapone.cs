using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootwapone : MonoBehaviour
{
    public inventManager inM;
    public ittttem[] itembickup;
    public GameObject[] gun;
    public string[] tagNameGun;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
   
    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.gameObject.tag == "pistol"&& (inM.inventorySeyns[0].transform.childCount == 0|| inM.inventorySeyns[1].transform.childCount == 0))
        {
            Destroy(other.gameObject);
        
            //shi.transform.parent = gri.transform;
            bool result = inM.addItem(itembickup[0]);
        }
        //

        if (other.gameObject.tag == "M16" && (inM.inventorySeyns[0].transform.childCount == 0 || inM.inventorySeyns[1].transform.childCount == 0))
        {
            Destroy(other.gameObject);
           
            bool result = inM.addItem(itembickup[1]);
        }
        */
        for(int i = 0; i < tagNameGun.LongLength; i++)
        {
            if (other.gameObject.tag == tagNameGun[i] && (inM.inventorySeyns[0].transform.childCount == 0 || inM.inventorySeyns[1].transform.childCount == 0))
            {
                Destroy(other.gameObject);

                bool result = inM.addItem(itembickup[i]);
            }
        }
    }
}
