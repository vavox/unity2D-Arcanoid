// Block component 
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    #region Fields
    [SerializeField]
    Sprite[] blockSprites = new Sprite[3];

    int scorePoints = 10;

    protected int spriteNum;

    protected AddPointsEvent addPointsEvent = new AddPointsEvent();
    #endregion

    #region Unity methods
    // Start is called on the frame when a script is enabled just before
    // any of the Update methods is called the first time.
    void Start()
    {
        EventManager.AddAddPointsInvoker(this);
        AddEffectBlockInvoker();

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteNum = Random.Range(0, blockSprites.Length);
        spriteRenderer.sprite = blockSprites[spriteNum];
    }
    
    // Destroys the block on collision with a ball
    virtual protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            addPointsEvent.Invoke(scorePoints);
            EventManager.RemoveAddPointsInvoker(this);
            Destroy(gameObject);
        }
    }
    #endregion

    #region Event methods
    // Adds the given listener for the AddPointsEvent
    public void AddAddPointsListener(UnityAction<int> listener)
    {
        addPointsEvent.AddListener(listener);
    }

    virtual protected void AddEffectBlockInvoker()
    {
    }
    #endregion
}
