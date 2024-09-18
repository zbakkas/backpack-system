using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootwapone : MonoBehaviour
{
    public inventManager inM;
    public ittttem[] itembickup;
    public GameObject[] gun;

    // Start is called before the first frame update
    void Start()
    {
        gun[0].SetActive(false);
        gun[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ittttem receivedItem = inM.getselecteItem(false);
       
        if (receivedItem == itembickup[0])
        {
            gun[0].SetActive(true);
        }
        else
        {
            gun[0].SetActive(false);
        }
        if (receivedItem == itembickup[1])
        {
            gun[1].SetActive(true);
        }
        else
        {
            gun[1].SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "M16")
        {
            Destroy(other.gameObject);
        
            //shi.transform.parent = gri.transform;
            bool result = inM.addItem(itembickup[0]);
        }
        //

        if (other.gameObject.tag == "akm")
        {
            Destroy(other.gameObject);
           
            bool result = inM.addItem(itembickup[1]);
        }
        if (other.gameObject.tag == "shootgun")
        {
            Destroy(other.gameObject);

            bool result = inM.addItem(itembickup[2]);
        }
        if (other.gameObject.tag == "snaiper")
        {
            Destroy(other.gameObject);

            bool result = inM.addItem(itembickup[3]);
        }

    }
}
