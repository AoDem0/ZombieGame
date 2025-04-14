using System.Numerics;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField]private Transform player;
   [SerializeField]private float moveSpeed;
    private float horizontalInput;
    private float verticalInput;
    private UnityEngine.Vector3 moveDirection;
    [SerializeField] private Rigidbody rb;


    private void Start()
    {
        rb.freezeRotation = true;
    }

    private void Update(){
        MyInputs();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInputs(){
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer(){
        moveDirection = player.forward * verticalInput + player.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed *10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        UnityEngine.Vector3 flatVel = new UnityEngine.Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if(flatVel.magnitude >moveSpeed){
            UnityEngine.Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new UnityEngine.Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);

        }
        
    
    }
}
