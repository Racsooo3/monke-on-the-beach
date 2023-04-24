using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class GrabBall : MonoBehaviour
{

    /// <summary>
    /// When the player touches the ball, it grabs the ball.
    /// When another player touches this player, it releases the ball.
    /// </summary>

    [SerializeField] private Transform target;
    [SerializeField] private Rig rig;
    private PlayerMovementScript playerMovement;

    [SerializeField] private GameObject releasePar;
    const float HEIGHT_OF_BALL = 18f;
    const float HEIGHT_OF_PARTICLE = HEIGHT_OF_BALL * 0.8f;
    const float WEIGHT_AFTER_GRAB = 0.36f;
    const float SPEED_LOWERING_FACTOR = 4f;

    public bool ballIsGrabbed { get; private set; }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovementScript>();
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Debug.Log("touch player");
            Release();
        }

        if (coll.gameObject.CompareTag("Ball"))
        {
            Debug.Log("touch ball");
            Grab(coll.gameObject);
        }
    }

    GameObject ball;
    void Release()
    {
        if (ball == null) return;
        Debug.Log("release");
        Instantiate(releasePar, transform.position + new Vector3(0, HEIGHT_OF_PARTICLE, 0), Quaternion.identity);

        ballIsGrabbed = false;

        playerMovement.walkSpeed += SPEED_LOWERING_FACTOR;

        Rigidbody ball_rb = ball.GetComponent<Rigidbody>();
        ball_rb.isKinematic = false;
        float force = 5f;
        ball_rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        ball = null;
        rig.weight = 0f;
    }

    void Grab(GameObject ball)
    {
        Debug.Log("grab");

        ballIsGrabbed = true;

        playerMovement.walkSpeed -= SPEED_LOWERING_FACTOR;

        this.ball = ball;
        ball.GetComponent<Rigidbody>().isKinematic = true;
        rig.weight = WEIGHT_AFTER_GRAB;
    }

    void PlaceBallOnHead()
    {
        if (ball == null) return;
        ball.transform.position = transform.position + new Vector3(0, HEIGHT_OF_BALL, 0);
        target.position = ball.transform.position;
    }

    private void FixedUpdate()
    {
        PlaceBallOnHead();
    }
}
