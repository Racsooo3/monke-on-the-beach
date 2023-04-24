using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    private Rigidbody rb;
    private Animator anim;
    public float walkSpeed;
    [SerializeField] float rotSpeed;
    [SerializeField] KeyCode turnLeft;
    [SerializeField] KeyCode turnRight;
    [SerializeField] KeyCode walkForward;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(walkForward))
        {
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            ChangeAnimationState(PLAYER_WALK);
        } else
        {
            ChangeAnimationState(PLAYER_IDLE);
        }

        if (Input.GetKey(turnRight)) 
        {
            transform.rotation *= Quaternion.Euler(0, rotSpeed * Time.deltaTime, 0);
        } else if (Input.GetKey(turnLeft))
        {
            transform.rotation *= Quaternion.Euler(0, -rotSpeed * Time.deltaTime, 0);
        }
    }

    const string PLAYER_WALK = "player_walk";
    const string PLAYER_IDLE = "player_idle";
    string currentState = PLAYER_IDLE;
    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        currentState = newState;
        anim.Play(newState);
    }
}
