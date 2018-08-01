using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float moveSpeed = 1000f;
    public GameObject pointCanvas;
    public GameObject checkPointText;
    public Vector3 resetPosition; 

    Rigidbody rb;
    CanvasController cc;
    Vector3 offset;
    public Camera mine;
    public bool isCollected;
    int lvlcor = -1;
    //Scene myScene;

    // Use this for initialization
    void Start() {
        rb = this.GetComponent<Rigidbody>();
        cc = GameObject.Find("Canvas").GetComponent<CanvasController>();
        rb = this.GetComponent<Rigidbody>();
        offset = mine.transform.position - transform.position;
        resetPosition = this.transform.position;
        /*
        if(myScene.name == "level 1"){

            lvlcor = -1;
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        float hdir = lvlcor * Input.GetAxisRaw("Horizontal");
        float vdir = lvlcor * Input.GetAxisRaw("Vertical");
        
        if (this.transform.position.y <  -27f) {
            ReturnToCheckpoint();
        }
    
        if(isCollected)
        {
            Destroy(this.gameObject, 1f);
            //Disappear();
        }
    


        Vector3 directionVector = new Vector3(vdir, 0, hdir);
        Vector3 unitVector = directionVector.normalized;
        Vector3 forceVector = unitVector * moveSpeed * Time.deltaTime;
        mine.transform.position = transform.position + offset;
        rb.AddForce(forceVector);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            if (resetPosition != other.transform.position)
            {
                resetPosition = other.transform.position;

                GameObject temporaryTextObject = (GameObject)Instantiate(pointCanvas);
                Destroy(temporaryTextObject, 1.5f);
            }
        }
            
        if (other.gameObject.tag == "collectible")
        {
            cc.IncreaseScore(5);
            other.GetComponent<collectiblesController>().isCollected = true;
            //other.gameObject.SetActive(false);
        }
        /*
        void disapear()
        {
            this.transform.rotate(vector3.up, 720 * Time.deltaTime)
        }
        */
    }
       void ReturnToCheckpoint() 
       {
           this.transform.position = resetPosition;
       }




}