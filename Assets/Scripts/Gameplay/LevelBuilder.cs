using UnityEngine;
using UnityEngine.Events;

public class LevelBuilder : MonoBehaviour
{
    #region Fields
    [SerializeField]
    GameObject blockPrefab;

    [SerializeField]
    GameObject ballPrefab;

    [SerializeField]
    GameObject paddlePrefab;

    [SerializeField]
    GameObject bonusBlock;
    #endregion
    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        // Spawning paddle game object
        Instantiate(paddlePrefab);

        // Spawning ball game object
        Instantiate(ballPrefab);

        EventManager.AddLevelGeneratorListener(LevelGenerator);
        LevelGenerator();
    }
    #endregion

    #region Private methods
    // Calculating blocks per row number
    int blockPerRow(float blockWidth)
    {  
        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft; 
        return Random.Range(4, (int)(screenWidth/blockWidth));
    }

    // Getting left offset block position 
    float leftOffset(float blockWidth, int blockNumber)
    {
        float totalBlockWidth = blockWidth * blockNumber;
        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft; 
        float leftBlockOffset = ScreenUtils.ScreenLeft +
            (screenWidth - totalBlockWidth) / 2 +
            blockWidth / 2;
        return leftBlockOffset;
    }

    void PlaceBlock(Vector2 position)
    {
        float randomBlockType = Random.value;
        if (randomBlockType > 0.15f)
        {
            Instantiate(blockPrefab, position, Quaternion.identity);
        }
        else
        {
            Instantiate(bonusBlock, position, Quaternion.identity);
        }
    }

    void LevelGenerator()
    {
        // Getting block size
        BoxCollider2D blockCollider = blockPrefab.GetComponent<BoxCollider2D>();
        float blockHeight = blockCollider.size.y;
        float blockWidth = blockCollider.size.x;

        float topRowOffset = ScreenUtils.ScreenTop -
            (ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom) / 5 -
            blockHeight / 2;

        int rowNumber = Random.Range(3, 6);
        // add rows of blocks
        Vector2 currentPosition = new Vector2(0, topRowOffset);
        for (int row = 0; row < rowNumber; row++)
        {
            int blockNumber = blockPerRow(blockWidth);
            currentPosition.x = leftOffset(blockWidth, blockNumber);

            for (int column = 0; column < blockNumber; column++)
            {
                // Spawning blocks
                PlaceBlock(currentPosition);
                currentPosition.x += blockWidth;
            }

            // move to next row
            currentPosition.y += blockHeight;
        }
    }
    #endregion

    #region Event methods

    #endregion
}
