using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class inventoruIteeem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Image image;
    public Text countText;

    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public ittttem itm;
    [HideInInspector] public int count = 1;

    ///////

    public GameObject[] prifabbGun;
    public Transform player;

    RectTransform invP;
    public Sprite[] itembickup;

   public inventorySeyn invSY;
    inventManager invM;
    waopen wp;


    public bool shooot =true;


    Ray ay;
    RaycastHit hit;
    public Transform P1,P2;
 

    private void Start()
    {

        invP = GameObject.Find("TO").GetComponent<RectTransform>();
        player = GameObject.Find("Player").transform;
        invSY = gameObject.GetComponentInParent<inventorySeyn>();
        invM = GameObject.Find("mantger").GetComponent<inventManager>();
        wp = player.gameObject.GetComponent<waopen>();

        P1 = GameObject.Find("spawn gun").transform;
        P2 = GameObject.Find("spawn gun2").transform;
    }
  

    public void InitialiseItem(ittttem newItem)
    {
        itm = newItem;
        image.sprite = newItem.image;
        refrechcont();
    }

    public void refrechcont()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }
   
    public void OnBeginDrag(PointerEventData eventData)
    {

        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        countText.gameObject.SetActive(false);
        ///

       

    }

    public void OnDrag(PointerEventData eventData)
    {

        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        ///
        refrechcont();
        /////dipawn icon

        if (!RectTransformUtility.RectangleContainsScreenPoint(invP, Input.mousePosition))
        {
            Destroy(gameObject);
            ////
            for(int i=0;i < itembickup.LongLength; i++)
            {
                if (image.sprite == itembickup[i])
                {
                    ay.origin = P1.position;
                    ay.direction = P2.position - P1.position;
                    if (Physics.Raycast(ay, out hit))
                    {
                        Instantiate(prifabbGun[i], new Vector3(hit.point.x + (-0.107f), hit.point.y + (0.107f), hit.point.z + (-0.107f)), prifabbGun[i].transform.rotation);

                    }
                   
                }
            }
           

        }

    }

    public void sssss()
    {
        shooot = false;
        for (int i = 0; i < invM.inventorySeyns.LongLength; i++)
        {
            invM.inventorySeyns[i].Deselect();
        }
        invSY.select();

        for (int i = 0; i < itembickup.LongLength; i++)
        {
            if (image.sprite == itembickup[i])////pistol            
            {
                wp.namperWeapons = i+1;
                wp.switchWeapons(i+1);
            }
        }

    
        
    }
    public void ddd()
    {

    }
}
