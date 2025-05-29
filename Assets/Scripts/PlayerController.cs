using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Controls controls;
    public Vector2 input;
    public float playerSpeed;
    public float rotationSpeed;
    public float turboFuel;
    CharacterController characterController;
    Vector3 velocity;
    private float clampedX;
    private bool turbo;
    private bool aturbo;
    private float speed;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        aturbo = true;
    }

    void Update()
    {
        GetInputs();
        PlayerMove(true);
        MainMenu.Instance.UpdateTurboFuel(turboFuel);
    }

    public void PlayerMove(bool move)
    {
        if (!GameManager.Instance.IsGameActive) return;

        speed = playerSpeed;
        if (turbo && aturbo)
        {
            if (turboFuel > 0)
            {
                speed = playerSpeed * 1.6f;
                turboFuel -= Time.deltaTime;
            }
            else
            {
                speed = playerSpeed;
                aturbo = false;
            }
        }
        else
        {
            if (turboFuel < 2)
            {
                turboFuel += Time.deltaTime / 4.5f;
            } else
            {
                aturbo = true;
            }
        }

        if (move)
        {
            // Рух літака вперед
            characterController.Move(transform.forward * speed * Time.deltaTime);

            // Контрольований рух літака в сторони
            velocity = rotationSpeed * Time.deltaTime * (transform.right * input.x);
            clampedX = Mathf.Clamp(transform.position.x, -10f, 10f);
            if (transform.position.x == clampedX)
            {
                characterController.Move(velocity);
            }
            else
            {
                characterController.Move(new Vector3(clampedX - transform.position.x, 0f, 0f));
            }
        }
        else
        {
            velocity = Vector3.zero;
        }
    }

    void GetInputs()
    {
        if (Input.GetKey(controls.right))
        {
            input.x = 1;
        }
        if (Input.GetKey(controls.left))
        {
            if (Input.GetKey(controls.right))
            {
                input.x = 0;
            }
            else
            {
                input.x = -1;
            }
        }
        if (!Input.GetKey(controls.right) && !Input.GetKey(controls.left))
        {
            input.x = 0;
        }
        if (Input.GetKey(controls.turbo))
        {
            turbo = true;
        }
        if (!Input.GetKey(controls.turbo))
        {
            turbo = false;
        }
    }
 
}

