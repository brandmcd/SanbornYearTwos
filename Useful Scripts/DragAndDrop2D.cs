using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {


    Vector3 offset = new Vector3(); //offset from piece to mouse pos
    public bool followMouse = false;
    int placement = -1; public int opType;
    bool movable; public GameObject zone;
    Vector3 worldPos;
    // Use this for initialization
    void Start()
    {
        //this script is on a instatiated object, it should follow the mouse upon birth.
        movable = true;
        this.transform.GetChild(0).transform.position = new Vector3(this.transform.GetChild(0).transform.position.x,
            this.transform.GetChild(0).transform.position.y, 1);
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 0.01f);
        //set offset, follow mouse
        // offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        followMouse = true;
        Cursor.lockState = CursorLockMode.Confined; //mouse can't go off-screen 
                                                    //set parent to the WinManager so it can be destroyed
        this.transform.parent = GameObject.Find("WinManager").transform;
        // originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // if (!GameManager.lose && !GameManager.win) //no dragging during win/loss
        // {
        if(!Input.GetKey(KeyCode.Mouse0) && followMouse)
        {
            OnMouseUp();
        }
        if (followMouse)
        {
            Vector3 mousePo = Input.mousePosition;
            mousePo.z = 1; //Camera.main.nearClipPlane;
            worldPos = Camera.main.ScreenToWorldPoint(mousePo);
            transform.position = worldPos;
        }
        //if mouse goes off-screen, drop piece and snap to on-screen position
        Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        if ((mousePos.x > 1 || mousePos.y > 1) && followMouse)
        {
            followMouse = false;
            transform.position = new Vector3(Mathf.Floor(transform.position.x), Mathf.Floor(transform.position.y), -0.5f);
        }
        if ((mousePos.x < 0 || mousePos.y < 0) && followMouse)
        {
            followMouse = false;
            transform.position = new Vector3(Mathf.Ceil(transform.position.x), Mathf.Ceil(transform.position.y), -0.5f);
        }
        // }
    }

    private void OnMouseDown()
    {
        if (movable)
        {
            //set offset, follow mouse
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            followMouse = true;

            //store originalPos as valid starting point
           // originalPos = transform.position;
        }
        //highlight selected block?
    }

    private void OnMouseUp()
    {
        //click to nearest valid position, don't follow mouse
        followMouse = false;
        //if in one of the operator reciving zones
        if (placement != -1)
        {
            this.GetComponent<SpriteRenderer>().color = Color.gray; //gray to indicate locked
            this.transform.position = zone.transform.position;
            movable = false;
            WinCondition.setOp(placement, opType);
            
        }
            //transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), -0.5f);
            //keep it on screen
            if (transform.position.x < -7)
            {
                transform.position = new Vector3(-7, transform.position.y);
            }
            if (transform.position.x > 7)
            {
                transform.position = new Vector3(7, transform.position.y);
            }
            if (transform.position.y > 4)
            {
                transform.position = new Vector3(transform.position.x, 4);
            }
            if (transform.position.y < -4.5)
            {
                transform.position = new Vector3(transform.position.x, -4.5f);
            }

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        print(1);
        
        zone = col.gameObject;
        if(zone.name == "op1")
        {
            placement = 1;
        }
        else if (zone.name == "op2")
        {
            placement = 2;
        }
        else if (zone.name == "op3")
        {
            placement = 3;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        print(2);
        placement = -1;
        zone = null;
    }

    
}
