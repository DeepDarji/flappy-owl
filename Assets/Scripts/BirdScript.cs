using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour

{

    public static BirdScript instance;

    [SerializeField]
    private Rigidbody2D myRigidBody;

    [SerializeField]
    private Animator anim;
    private float forwardSpeed = 0.4f;
    private float bounceSpeed = 0.8f;
    private bool didFlap;
    public bool isAlive;
    //private Button flapButton;

    [SerializeField]
    private AudioSource audioSource;
    
    [SerializeField]
    private AudioClip flapClip, pointClip, diedClip;


    public int score;

    private void Awake()
    {
        /*anim = GetComponent<Animator> ();     
        myRigidBody = GetComponent<Rigidbody2D>();*/

        if (instance == null)
        {
            instance = this;
        }
        
        isAlive = true;

        score = 0;

        //flapButton = GameObject.FindGameObjectWithTag("FlapButton").GetComponent<Button>();
        //flapButton.onClick.AddListener (() => FlapTheBird());
    
        SetCamerasX();
    }

    void Start()
    {
        
    }

    //Update called every frame
    //Fixed Updates called every two or three frames
    void FixedUpdate()
    {
        if(isAlive) {
            Vector3 temp = transform.position;
            temp.x += forwardSpeed * Time.deltaTime;
            transform.position = temp;

            if(didFlap)
            {
                didFlap = false;
                myRigidBody.velocity = new Vector2 (0, bounceSpeed);
                audioSource.PlayOneShot(flapClip);
                anim.SetTrigger("Flapping");
            }
            
        }
    }

    void SetCamerasX()
    {
        CameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x);
    }

    public float GetPositionX()
    {
        return transform.position.x;
    }

    public void FlapTheBird()
    {
        didFlap = true;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
         if(target.gameObject.tag == "Ground" || target.gameObject.tag == "Pipe")
        {
            if(isAlive)
            {
                isAlive = false;
                anim.SetTrigger("Died");
                audioSource.PlayOneShot(diedClip);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "PipeHolder")
        {
            score++;
            audioSource.PlayOneShot(pointClip);

        }
    }


}
