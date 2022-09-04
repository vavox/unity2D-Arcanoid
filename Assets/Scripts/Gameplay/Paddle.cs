// Paddle component
using UnityEngine;

public class Paddle : MonoBehaviour
{
    #region Fields
    Rigidbody2D paddleRb2d;

    float paddleSpeed = 15f;

    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    float halfWidth;
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        paddleRb2d = GetComponent<Rigidbody2D>();
        BoxCollider2D collider2D = gameObject.GetComponent<BoxCollider2D>();

        // Half collider width
        halfWidth = collider2D.size.x / 2;
    }

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        paddleMovement();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))// && TopCollision(collision))
        {
            // Calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                collision.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // Setting ball direction
            Ball ballComponent = collision.gameObject.GetComponent<Ball>();
            ballComponent.SetDirection(direction); 

             AudioManager.Play(AudioClipName.PaddleHit);
        }
    }
    #endregion

    #region Private methods
    // Paddle movement method
    void paddleMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        Vector2 position = paddleRb2d.position;
        position.x += Time.deltaTime * horizontalMovement * paddleSpeed; 
        position.x = PaddleWallCollider(position.x);
        paddleRb2d.MovePosition(position);
    }

    // Checking ball colliding with left and right screen borders
    float PaddleWallCollider(float x)
    {
        // clamp left and right edges
        if (x - halfWidth < ScreenUtils.ScreenLeft)
        {
            x = ScreenUtils.ScreenLeft + halfWidth;
        }
        else if (x + halfWidth > ScreenUtils.ScreenRight)
        {
            x = ScreenUtils.ScreenRight - halfWidth;
        }
        return x;
    }
    #endregion
}
