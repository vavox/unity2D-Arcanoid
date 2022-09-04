// Bonus block component
using UnityEngine;
using UnityEngine.Events;

public class EffectBlock : Block
{
    #region Fields
    const int BonusPoints = 100;
    const float SpeedBonus = 1.5f;

    [SerializeField]
    GameObject ballPrefab;

    SpeedUpEvent speedUpEvent = new SpeedUpEvent();
    #endregion

    #region Unity methods

    // Destroys the block on collision with a ball
    override protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            switch(spriteNum)
            {
                case 0: // Bonus Points Block
                    addPointsEvent.Invoke(BonusPoints);
                    Destroy(gameObject);
                    break;
                case 1: // Speed Up Ball Block
                    addPointsEvent.Invoke(BonusPoints/2);
                    speedUpEvent.Invoke(SpeedBonus);
                    EventManager.RemoveSpeedUpInvoker(this);
                    Destroy(gameObject);
                    break;
                case 2: // Add Ball Block
                    Instantiate(ballPrefab);
                    Destroy(gameObject);
                    break;
                default:
                    break;                    
            } 
        }
    }
    #endregion

    #region Event methods
    public void AddSpeedUpListener(UnityAction<float> listener)
    {
        speedUpEvent.AddListener(listener);
    }

    protected override void AddEffectBlockInvoker()
    {
        EventManager.AddSpeedUpInvoker(this);
    }
    #endregion
}
