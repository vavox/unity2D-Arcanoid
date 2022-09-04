using UnityEngine;

// Provides screen utilities
public static class ScreenUtils
{
    #region Fields
    // saved to support resolution changes
    static int screenWidth;
    static int screenHeight;

    // cached for efficient boundary checking
    static float screenLeft;
    static float screenRight;
    static float screenTop;
    static float screenBottom;
    #endregion

    #region Properties
    // Gets the left edge of the screen in world coordinates
    public static float ScreenLeft
    {
        get
        {
            CheckScreenSizeChanged();
            return screenLeft;
        }
    }

    // Gets the right edge of the screen in world coordinates
    public static float ScreenRight
    {
        get
        {
            CheckScreenSizeChanged();
            return screenRight;
        }
    }

    // Gets the top edge of the screen in world coordinates
    public static float ScreenTop
    {
        get
        {
            CheckScreenSizeChanged();
            return screenTop;
        }
    }

    // Gets the bottom edge of the screen in world coordinates
    public static float ScreenBottom
    {
        get 
        {
            CheckScreenSizeChanged();
            return screenBottom; 
        }
    }
    #endregion

    #region Methods
    // Initializes the screen utilities
    public static void Initialize()
    {
        // save to support resolution changes
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        // save screen edges in world coordinates
        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(
            screenWidth, screenHeight, screenZ);
        Vector3 lowerLeftCornerWorld =
            Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld =
            Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
        screenLeft = lowerLeftCornerWorld.x;
        screenRight = upperRightCornerWorld.x;
        screenTop = upperRightCornerWorld.y;
        screenBottom = lowerLeftCornerWorld.y;
    }

    // Checks for screen size change
    static void CheckScreenSizeChanged()
    {
        if (screenWidth != Screen.width ||
            screenHeight != Screen.height)
        {
            Initialize();
        }
    }
    #endregion
}
