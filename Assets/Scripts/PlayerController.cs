using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;

    public BaseControlls Controlls { get; set; }
    public Rigidbody Rigidbody { get; set; }
    public Collider Collider { get; set; }
    public Camera PlayerCamera { get; set; }

    [SerializeField] GameObject PlayerModel;

    [SerializeField] int MovementSpeed = 5;

    [SerializeField] Animator animator;

    private Vector3 LastDirection;

    // Start is called before the first frame update
    void Start()
    {
        SetUpController();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        
        Move();

        if(Controlls.Build != 0)
        {
            ToggleBuildMenu();
        }
    }

    private void HandleInput()
    {
        Controlls.Horizontal = Input.GetKey(KeyCode.A) ? -1 : Input.GetKey(KeyCode.D) ? 1 : 0;
        Controlls.Vertical = Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0;
        Controlls.Use = Input.GetKey(KeyCode.E) ? 1 : 0;
        Controlls.Build = Input.GetKeyDown(KeyCode.B) ? 1 : 0;
    }

    private void Move()
    {
        float vertical = Controlls.Vertical;
        float horizontal = Controlls.Horizontal;
        
        if(vertical != 0 || horizontal != 0)
        {
            if(vertical != 0 && horizontal != 0)
            {
                vertical *= 0.75f;
                horizontal *= 0.75f;
            }

            print(vertical + "/" + horizontal);


            float adjustedHorizontalInput = (horizontal + vertical) / Mathf.Sqrt(2);
            float adjustedVerticalInput = (vertical - horizontal) / Mathf.Sqrt(2);

            Vector3 vector3 = new Vector3(adjustedHorizontalInput, 0, adjustedVerticalInput) * MovementSpeed;

            Rigidbody.velocity = vector3;

            LastDirection = vector3;

            PlayerModel.transform.rotation = Quaternion.LookRotation(LastDirection * -1);

            animator.Play("Walk");
        } else
        {
            animator.Play("Empty");
        }
    }

    private void ToggleBuildMenu()
    {
        print("Toggle build menu");
    }

    private void SetUpController()
    {
        Rigidbody = GetComponent<Rigidbody>();

        instance = this;

        print("SetUp");
    }

    public static PlayerController getInstance()
    {
        if(instance != null)
        {
            return instance;
        } else
        {
            return null;
        }

     
    }
}
