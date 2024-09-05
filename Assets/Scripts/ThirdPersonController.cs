using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonController : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public float rotationSpeed = 720.0f; // Degrees per second
    public float jumpForce = 5.0f;
    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private Animator m_Animator;
    private bool groundedPlayer;

    public GameObject FinishPop;
    public ParticleSpawner Spawner;
    public UiControler uiControler;
    public bool isMove = true;

    public AudioSource jump, run,finishsfx;

    private void Start()
    {
       uiControler= GameObject.Find("Canvas").GetComponent<UiControler>();
        rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        m_Animator = gameObject.GetComponentInChildren<Animator>();
        FinishPop.SetActive(false);
        Spawner = gameObject.GetComponentInChildren<ParticleSpawner>();

        run.Play();
    }

    void Update()
    {
        Vector3 velocity;
        Vector3 moveDirection;
      if (isMove)
        {
            // Check if the player is grounded
            groundedPlayer = Physics.Raycast(transform.position, -Vector3.up, groundCheckDistance, groundLayer);

        // Get player input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Create a movement vector based on input
        Vector3 inputDirection = new Vector3(horizontalInput, 0, verticalInput);

        // If there is any input, rotate the player in the direction of input
        if (inputDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(inputDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Apply movement

         moveDirection = transform.forward * inputDirection.magnitude;

       
        velocity = moveDirection * playerSpeed;
         // Preserve the existing vertical velocity (e.g., from gravity)
       
            velocity.y = rb.velocity.y;
            bool isMoving = inputDirection.magnitude > 0;
            m_Animator.SetBool("run", isMoving);
            if (isMoving&&groundedPlayer)
            {
                run.volume = 1;
            }
            else
            {
               run.volume = 0;
            }
            // Handle jumping
            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {
                m_Animator.SetTrigger("jump");
                
                jump.Play();
            }
            rb.velocity = velocity;
        }
        else
        {
            rb.velocity = Vector3.zero;
            m_Animator.SetBool("run",false);
           
        }

       
        // Set animation parameters
       
    }
    


   

    // This method is called by the animation event during the jump
    public void PerformJump()
    {
        
        
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("finish") && !FinishPop.activeSelf)
        {

            
            FinishPopUp();
        }
        else if (collision.collider.CompareTag("void"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void FinishPopUp()
    {
        run.Pause();
        finishsfx.Play();
        Spawner.CallSpawnParticleSystems();
        FinishPop.SetActive(true);
        uiControler.UpdateThePopup();
    }
}
