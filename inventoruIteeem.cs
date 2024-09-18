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

    private void Start()
    {

        invP = GameObject.Find("TO").GetComponent<RectTransform>();
        player = GameObject.Find("PLAYER").transform;
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
        /////

        if (!RectTransformUtility.RectangleContainsScreenPoint(invP, Input.mousePosition))
        {
            Destroy(gameObject);
            ////
           
            if (image.sprite == itembickup[0])
            {
                Instantiate(prifabbGun[0], new Vector3(player.position.x + (-4f), player.position.y + (-1f), player.position.z + (0)), prifabbGun[0].transform.rotation);
            }
            if (image.sprite == itembickup[1])
            {
               
                    Instantiate(prifabbGun[1], new Vector3(player.position.x + (-4f), player.position.y + (-1f), player.position.z + (0)), prifabbGun[1].transform.rotation);
               
               
            }

        }

    }
}
