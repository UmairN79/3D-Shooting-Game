using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerMovementScript : MonoBehaviour
{

    PlayerInput playerInput;
    InputAction moveAction;

    [SerializeField] private Rigidbody body;
    [SerializeField] private float speed;
    [SerializeField] private float extraSpeed;
    [SerializeField] private float crouchSpeed;
    [SerializeField] private float crouchScale;
    [SerializeField] private float maxStamina;
    [SerializeField] private float playerStamina;
    [SerializeField] private float staminaRegen;
    [SerializeField] private float staminaDrain;
    private float normalYScale;
    private bool regenerating = false;
    private bool sprinting = true;

    Vector2 direction;
    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        normalYScale = transform.localScale.y;
    }

    void Update()
    {
        if (playerStamina < 0)
        {
            regenerating = true;
        }
        else if (playerStamina >= maxStamina)
        {
            playerStamina = maxStamina;
            regenerating = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.LeftShift) && playerStamina > 0 && regenerating == false)
        {
            transform.localScale = new Vector3(transform.localScale.x, normalYScale, transform.localScale.z);
            direction = moveAction.ReadValue<Vector2>();
            move = transform.right * direction.x + transform.forward * direction.y;
            transform.position += move * extraSpeed * Time.deltaTime;
            playerStamina -= staminaDrain * Time.deltaTime;
            OnSprint.Invoke();
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            direction = moveAction.ReadValue<Vector2>();
            move = transform.right * direction.x + transform.forward * direction.y;
            transform.localScale = new Vector3(transform.localScale.x, crouchScale, transform.localScale.z);
            body.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            transform.position += move * crouchSpeed * Time.deltaTime;
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, normalYScale, transform.localScale.z);
            direction = moveAction.ReadValue<Vector2>();
            move = transform.right * direction.x + transform.forward * direction.y;
            transform.position += move * speed * Time.deltaTime;
            if (playerStamina < maxStamina)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                OnSprint.Invoke();
            }
        }
    }

    public float RemainingStamina
    {
        get
        {
            return playerStamina / maxStamina;
        }
    }

    public UnityEvent OnSprint;
}
