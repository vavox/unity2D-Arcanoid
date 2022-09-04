// Ball component
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    #region Fields
    float ballRadius;
    float currentSpeed;
    float speedBonus = 0;
    float initialBallSpeed;
    const float MaxSpeed = 10f;

    DestroyBallEvent destroyBallEvent = new DestroyBallEvent();
    #endregion

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D ballRb2d = GetComponent<Rigidbody2D>();
        CircleCollider2D ballCollider = GetComponent<CircleCollider2D>();

        ballRb2d.AddForce(BallImpulse(), ForceMode2D.Impulse);

        ballRadius = ballCollider.radius;

        EventManager.AddDestroyBallInvoker(this);
        EventManager.AddSpeedUpListener(SpeedBonus);
        EventManager.AddResetBallListener(ResetBall);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Paddle"))
        {
            AudioManager.Play(AudioClipName.BallHit);
        }
    }

    // Destroying ball object when reaching lower game bound
    void OnBecameInvisible()
    {
        destroyBallEvent.Invoke();
        DestroyBall();
    }
    #endregion

    #region Private methods
    // Initializing ball velocity and direction
    Vector2 BallImpulse()
    {
        // Setting random speed
        gameObject.transform.position = new Vector3(0, 0, 0);
        initialBallSpeed = Random.Range(5, 7);
        Vector2 impulseVector = new Vector2(initialBallSpeed * Mathf.Cos(90 * Mathf.Deg2Rad), 
                                    initialBallSpeed * Mathf.Sin(-90 * Mathf.Deg2Rad));
        return impulseVector;
    }

    void DestroyBall()
    {
        EventManager.RemoveDestroyBallInvoker(this);
        Destroy(gameObject);
    }

    float GetCurrentSpeed()
    {
        currentSpeed = initialBallSpeed + speedBonus;
        if(currentSpeed >= MaxSpeed)
        {
            return MaxSpeed;
        }
        else
        {
            return currentSpeed;
        }
    }
    #endregion

    #region Public methods

    // Setting ball velocity and direction
    public void SetDirection(Vector2 direction)
    {
        Rigidbody2D ballRb2d = GetComponent<Rigidbody2D>();
        ballRb2d.velocity = direction * (GetCurrentSpeed());
    }

    public void SpeedBonus(float bonus)
    {
        speedBonus += bonus;
    }

    public void ResetBall()
    {
        Rigidbody2D ballRb2d = GetComponent<Rigidbody2D>();
        ballRb2d.velocity = BallImpulse();
        speedBonus = 0;
    }
    #endregion

    #region Event methods
    public void AddDestroyBallListener(UnityAction listener)
    {
        destroyBallEvent.AddListener(listener);
    }
    #endregion
}
