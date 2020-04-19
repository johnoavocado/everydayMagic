using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CharacterController : MonoBehaviour
{
    enum State
    {
        Well,
        Asleep,
        Hungry,
        Upset
    }

    private float horizontalVelocity = 0.0f;
    private float verticalVelocity = 0.0f;
    private float movementSpeed = 2.0f;

    public List<ItemController> AvailableItems;

    public WorldThing worldThingInfocus;
    public WorldThing worldNothing;
    
    public ItemController EquippedItem;

    public GameObject equippedItemSlot;
    public GameObject putDownZone;
    
    public KeyCode equipButton;
    public KeyCode upButton;
    public KeyCode downButton;
    public KeyCode leftButton;
    public KeyCode rightButton;
    public KeyCode activateButton;

    private AudioSource _as;
    public AudioClip equipSound;

    private void Start()
    {
        worldThingInfocus = worldNothing;
        _as = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        horizontalVelocity = 0.0f;
        verticalVelocity = 0.0f;
        if (Input.GetKey(rightButton)) {horizontalVelocity += 1.0f; }
        if (Input.GetKey(leftButton)) {horizontalVelocity += -1.0f; }
        if (Input.GetKey(upButton)) {verticalVelocity += 1.0f; }
        if (Input.GetKey(downButton)) {verticalVelocity += -1.0f; }
        
        if(Input.GetKeyDown(equipButton)){ SwapItem(); }
        // if(Input.GetKeyDown(equipButton)){ PutDownItem(); }
        if(Input.GetKeyDown(activateButton)) {ActivateItem();}

        UpdatePosition();
    }

    void UpdatePosition()
    {
        Vector2 tmp_pos = transform.position;
        var direction = new Vector2(horizontalVelocity, verticalVelocity);
        horizontalVelocity = direction.magnitude == 0.0f ? 0.0f : direction.x / direction.magnitude;
        verticalVelocity = direction.magnitude == 0.0f ? 0.0f : direction.y / direction.magnitude;
        tmp_pos.x += horizontalVelocity * movementSpeed * Time.deltaTime;
        tmp_pos.y += verticalVelocity * movementSpeed * Time.deltaTime;

        tmp_pos = new Vector2(Mathf.Clamp(tmp_pos.x, -3.0f, 4.0f), Mathf.Clamp( tmp_pos.y,-2.0f, 3.0f));
        
        transform.position = tmp_pos;
    }
    

    void SwapItem()
    {
        if (AvailableItems.Count == 0)
        {
            if (PutDownItem())
            {
                _as.clip = equipSound;
                _as.Play();
            }
            return;
        }

        _as.clip = equipSound;
        _as.Play();
        
        PutDownItem();
        EquippedItem = AvailableItems[0];
        AvailableItems.Remove(AvailableItems[0]);
        AvailableItems.TrimExcess();

        EquippedItem.transform.position = equippedItemSlot.transform.position;
        EquippedItem.transform.parent = equippedItemSlot.transform;
        
        Debug.Log(EquippedItem.gameObject.name);
    }

    private bool PutDownItem()
    {
        if (EquippedItem != null)
        {
            SafeAdd(EquippedItem);
            EquippedItem.PutDown(putDownZone.transform.position);
            EquippedItem.transform.parent = null;
            EquippedItem = null;
            return true;
        }

        return false;
    }

    void ActivateItem()
    {
        if (EquippedItem)
        {
            if (EquippedItem.CanActivateWith(worldThingInfocus))
            {
                _as.clip = EquippedItem.ActivateSound;
                _as.Play();
            }
            
            if (EquippedItem.Activate(worldThingInfocus) == true)
            {
                Destroy(EquippedItem.gameObject);
                EquippedItem = null;
            }
        }
    }

    void SafeAdd(ItemController itemController)
    {
        if (!AvailableItems.Contains(itemController))
        {
            AvailableItems.Add(itemController );
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<WorldThing>() != null)
        {
            worldThingInfocus = other.GetComponent<WorldThing>();
            if(EquippedItem) worldThingInfocus.Highlight(EquippedItem.CanActivateWith(worldThingInfocus));
        }

        if (other.GetComponent<ItemController>() != null)
        {
            SafeAdd(other.GetComponent<ItemController>());
        }
        // Debug.Log("There are " + AvailableItems.Count + " items available.");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<WorldThing>() != null)
        {
            worldThingInfocus.Highlight(false);
            worldThingInfocus = worldNothing;
        }

        if (other.GetComponent<ItemController>() != null)
        {
            AvailableItems.Remove(other.GetComponent<ItemController>() );
            AvailableItems.TrimExcess();
        }
        // Debug.Log("There are " + AvailableItems.Count + " items available.");
    }
}
