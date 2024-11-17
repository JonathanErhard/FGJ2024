using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region singleton region
    public static PlayerController Instance { get; private set; }
    public PlayerController()
    {
        Instance = this;
    }
    #endregion

    public BaseControlls Controlls { get; set; }
    public Rigidbody Rigidbody { get; set; }
    public Collider Collider { get; set; }

    [SerializeField] GameObject PlayerModel;

    [SerializeField] Animator animator;


    [SerializeField] 
    public int MovementSpeed { get; private set; } = 20;
    [SerializeField] 
    public float MaxHealth { get; private set; } = 60;
    [SerializeField]
    public float Health { get; private set; } = 60;

    [SerializeField] public bool IsInBase { get; set; }

    private Vector3 LastDirection;

    private void Awake()
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

        if(!IsInBase)
        {
            if(!DrainHealth())
            {
                GameOver();
            }
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

    public void UpgradeSpeed(int amount = 10)
    {
        MovementSpeed += amount;
    }

    public void UpgradeHealth(int amount = 10)
    {
        MaxHealth += amount;
    }

    private void ToggleBuildMenu()
    {
        print("Toggle build menu");
    }

    private bool DrainHealth()
    {
        Health -= 1 * Time.deltaTime;

        if(Health <= 0)
        {
            return false;
        }

        return true;
    }

    private void GameOver()
    {
        Destroy(gameObject);
    }

    private void SetUpController()
    {
        Rigidbody = GetComponent<Rigidbody>();

        Health = MaxHealth;
        IsInBase = true;

        print("SetUp");
    }


    public static float GetDistanceToTrans(Transform trans)
    {
        return Instance == null ? float.MaxValue :
            Vector3.Distance(Instance.transform.position, trans.position);
    }
}
