using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventManager : MonoBehaviour
{
    public int maxstackItem=4;
    public inventorySeyn[] inventorySeyns;////////
    public GameObject infentoryitemPrefab;

    int selectSlot = -1;

    private void Start()
    {
        changeSelegteSolt(0);
    }
    private void Update()
    {
        if(Input.inputString != null)
        {
            bool isnumber = int.TryParse(Input.inputString, out int number);
            if(isnumber&&number>0&&number<6)
            {
                changeSelegteSolt(number - 1);
            }
        }
    }
    void changeSelegteSolt(int newVulue)
    {
        if (selectSlot >= 0)
        {
            inventorySeyns[selectSlot].Deselect();
        }
      
        inventorySeyns[newVulue].select();
        selectSlot = newVulue;
    }

    public bool addItem(ittttem itm)
    {
        /////////////max
        for (int i = 0; i < inventorySeyns.Length; i++)
        {
            inventorySeyn slot = inventorySeyns[i];/////////
            inventoruIteeem itmInslot = slot.GetComponentInChildren<inventoruIteeem>();
            if (itmInslot != null && 
                itmInslot.itm==itm&& 
                itmInslot.count< maxstackItem&&
                itmInslot.itm.stackible==true)
            {
                itmInslot.count++;
                itmInslot.refrechcont();
                return true;
            }
        }
        /////////////
        for (int i =0;i< inventorySeyns.Length; i++)
        {
            inventorySeyn slot = inventorySeyns[i];/////////
            inventoruIteeem itmInslot = slot.GetComponentInChildren<inventoruIteeem>();
            if(itmInslot == null)
            {
                SpawnNewItem(itm,slot);
                return true;
            }
        }
        return false;
    }
    void SpawnNewItem(ittttem itm, inventorySeyn slot)
    {
        GameObject newitmgo = Instantiate(infentoryitemPrefab, slot.transform);
        inventoruIteeem inventoruIteee = newitmgo.GetComponent<inventoruIteeem>();
        inventoruIteee.InitialiseItem(itm);

    }

    public ittttem getselecteItem(bool use)
    {
        inventorySeyn slot = inventorySeyns[selectSlot];
        inventoruIteeem itmInslot = slot.GetComponentInChildren<inventoruIteeem>();
        if (itmInslot != null)
        {
            ittttem itm= itmInslot.itm;
            if (use == true)
            {
                itmInslot.count--;
                if (itmInslot.count <= 0)
                {
                    Destroy(itmInslot.gameObject);
                }
                else
                {
                    itmInslot.refrechcont();
                }
            }
            return itm;
        }
        return null;
    }
}
