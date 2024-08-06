using System.Collections;
using System.Collections.Generic;
using KeyElements;
using Resources.Scripts;
 using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public GameObject player;
    public Transform holdPos;
    
    public float pickUpRange = 5f; 
    private float rotationSensitivity = 1f;
    private GameObject heldObj;
    private Rigidbody heldObjRb;
    private int LayerNumber;
    private InputManager _inputManager;


    public bool isPickingObject
    {
        get
        {
            return heldObj;
        }
    }
    void Start()
    {
        LayerNumber = LayerMask.NameToLayer("holdLayer");
        _inputManager = InputManager.Instance;
    }
    void Update()
    {
        if (_inputManager.PlayerPickUp())
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    GameObject hitedGameObject = hit.transform.gameObject;
                    if (hitedGameObject.CompareTag("canPickUp"))
                    {
                        PickUpObject(hitedGameObject);
                    }else if (hitedGameObject.GetComponent<KeyHolder>() &&
                              hitedGameObject.GetComponent<KeyHolder>().KeyIsOn)
                    {
                        KeyHolder keyHolder = hitedGameObject.GetComponent<KeyHolder>();
                        PickUpObject(keyHolder.Key);
                        keyHolder.TakeKey();

                    }
                }
            }
            else
            {
                StopClipping();
                StopPickUp();
            }
        }
        if (heldObj != null) 
        {
            MoveObject();
        }
    }

    public void StopPickUp()
    {
        
        DropObject();
    }

    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>())
        {
            heldObj = pickUpObj;
            heldObjRb = pickUpObj.GetComponent<Rigidbody>();
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform;
            heldObj.layer = LayerNumber;
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }
    void DropObject()
    {
        Debug.Log("some");
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObj = null;
    }
    void MoveObject()
    {
        heldObj.transform.position = holdPos.transform.position;
    }


    void StopClipping()
    {
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
        
        if (hits.Length > 1)
        {
            heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
        }
    }
}
