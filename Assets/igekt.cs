using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class igekt : MonoBehaviour
{
    public GameObject grenade;
    public int force = 800;
    public lotGranad loG;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")&&loG.selecter&&loG.grenadee>0&& ! IsMouseOverUI())
        {
            GameObject go = Instantiate(grenade, transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * force);
            loG.grenadee = loG.grenadee - 1;
        }
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

}
