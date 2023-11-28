using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Vector3 move;
    

    public float jumpSpeed;

    public PhotonView phot;


    public GameObject throwable;

    public int throwcount;

    public LayerMask floorMask;

    float verticalLook;

    public float mouseSens;

    public int click;
    public CapsuleCollider col;

    public TextMeshProUGUI nick;

   

    public bool isGrounded = true;

    public Transform groundCheck;
    public float radius;
    public LayerMask ground;

    [SerializeField] GameObject camHold;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        phot = GetComponent<PhotonView>();
        col = GetComponent<CapsuleCollider>();
        
        


        if (!phot.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
            nick.text = phot.Owner.NickName;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!phot.IsMine)
        {
            return;
        }

        if (phot.IsMine)
        {
            GetComponent<Renderer>().material.color = Color.red;

            nick.text = PhotonNetwork.NickName;
        }
        
        



        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical).normalized;



        rb.MovePosition(rb.position +transform.TransformDirection(move)   * speed * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, radius, ground);
        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpSpeed);
        }

        if(Input.GetMouseButton(0) && throwcount > 0)
        {
            Instantiate(throwable, transform.position, transform.rotation);
            throwcount--;
        }


        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSens);

        verticalLook += Input.GetAxisRaw("Mouse Y") * mouseSens;
        verticalLook = Mathf.Clamp(verticalLook, -90, 90);

        camHold.transform.localEulerAngles = Vector3.left * verticalLook;


        if (Input.GetKeyDown(KeyCode.N))
        {
            click++;
        }

        if(click > 1)
        {
            click = 0;
        }

        if(click == 1)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }

       
    }

  
}
