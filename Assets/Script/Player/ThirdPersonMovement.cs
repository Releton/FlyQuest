using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 1.6f;
    public float sprintSpeedMultiplier = 1f;
    public float gravity = 9.81f;
    public float gravityMultiplier;
    public float turnSmoothTime = 0.1f;
    public Transform cam;
    float turnSmoothVelocity;
    Vector3 moveDir;
    bool isMoving = false;
    private void Update()
    {
        isMoving = false;
        if(GameManager.isAlive)
        {
            characterController.Move(new Vector3(0f, -gravity * gravityMultiplier * Time.deltaTime, 0f));
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if(direction.magnitude >= 0.1f && GameManager.isAlive && !Spawner.isQuestionZoomed)
        {
            isMoving = true;
            float targetAnlge = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAnlge, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            moveDir = Quaternion.Euler(0f, targetAnlge, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        if (isMoving && Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += transform.forward * Time.deltaTime * sprintSpeedMultiplier;
        }
    }
}
