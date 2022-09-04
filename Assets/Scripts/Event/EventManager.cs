using System.Collections.Generic;
using UnityEngine.Events;

public static class EventManager
{
    #region Fields
    static List<Ball> addDestroyBallInvokers = new List<Ball>();
    static List<UnityAction> addDestroyBallListeners = new List<UnityAction>();

    static List<Block> addPointsInvokers = new List<Block>();
    static List<UnityAction<int>> addPointsListeners = new List<UnityAction<int>>();

    static List<EffectBlock> addSpeedUpInvokers = new List<EffectBlock>();
    static List<UnityAction<float>> addSpeedUpListeners = new List<UnityAction<float>>();

    static List<GameplayManager> addLevelGeneratorInvokers = new List<GameplayManager>();
    static List<UnityAction> addLevelGeneratorListeners = new List<UnityAction>();
    
    static List<GameplayManager> addResetBallInvokers = new List<GameplayManager>();
    static List <UnityAction> addResetBallListeners = new List<UnityAction>();
    #endregion

    #region Destroy Ball
    // Adds the given script as a Destroy Ball Invoker
    public static void AddDestroyBallInvoker(Ball invoker)
    {
        addDestroyBallInvokers.Add(invoker);
        foreach(UnityAction listener in addDestroyBallListeners)
        {
            invoker.AddDestroyBallListener(listener);
        }    
    }

    public static void AddDestroyBallListener(UnityAction listener)
    {
        addDestroyBallListeners.Add(listener);
        foreach(Ball invoker in addDestroyBallInvokers)
        {
            invoker.AddDestroyBallListener(listener);
        }
    }

    // Remove the given script as a ball died invoker
    public static void RemoveDestroyBallInvoker(Ball invoker)
    {
        // remove invoker from list
        addDestroyBallInvokers.Remove(invoker);
    }

    #endregion

    #region Add Points 
    public static void AddAddPointsInvoker(Block invoker)
    {
        addPointsInvokers.Add(invoker);
        foreach(UnityAction<int> listener in addPointsListeners)
        {
            invoker.AddAddPointsListener(listener);
        }
    }

    public static void AddAddPointsListener(UnityAction<int> listener)
    {
        addPointsListeners.Add(listener);
        foreach(Block invoker in addPointsInvokers)
        {
            invoker.AddAddPointsListener(listener);
        }
    }


    public static void RemoveAddPointsInvoker(Block invoker)
    {
        addPointsInvokers.Remove(invoker);
    }
    #endregion

    #region SpeedUp
    public static void AddSpeedUpInvoker(EffectBlock invoker)
    {
        addSpeedUpInvokers.Add(invoker);
        foreach(UnityAction<float> listener in addSpeedUpListeners)
        {
            invoker.AddSpeedUpListener(listener);
        }
    }
    public static void AddSpeedUpListener(UnityAction<float> listener)
    {
        addSpeedUpListeners.Add(listener);
        foreach(EffectBlock invoker in addSpeedUpInvokers)
        {
            invoker.AddSpeedUpListener(listener);
        }
    }

    public static void RemoveSpeedUpInvoker(EffectBlock invoker)
    {
        addSpeedUpInvokers.Remove(invoker);
    }
    #endregion

    #region Level Generator
    public static void AddLevelGeneratorInvoker(GameplayManager invoker)
    {
        addLevelGeneratorInvokers.Add(invoker);
        foreach(UnityAction listener in addLevelGeneratorListeners)
        {
            invoker.AddLevelGeneratorListener(listener);
        }
    }

    public static void AddLevelGeneratorListener(UnityAction listener)
    {
        addLevelGeneratorListeners.Add(listener);
        foreach(GameplayManager invoker in addLevelGeneratorInvokers)
        {
            invoker.AddLevelGeneratorListener(listener);
        }
    }

    public static void RemoveLevelGeneratorInvoker(GameplayManager invoker)
    {
        addLevelGeneratorInvokers.Remove(invoker);
    }
    #endregion

    #region Reset Ball
    public static void AddResetBallInvoker(GameplayManager invoker)
    {
        addResetBallInvokers.Add(invoker);
        foreach(UnityAction listener in addResetBallListeners)
        {
            invoker.AddResetBallListener(listener);
        }
    }

    public static void AddResetBallListener(UnityAction listener)
    {
        addResetBallListeners.Add(listener);
        foreach(GameplayManager invoker in addResetBallInvokers)
        {
            invoker.AddResetBallListener(listener);
        }
    }

    public static void RemoveResetBallInvoker(GameplayManager invoker)
    {
        addResetBallInvokers.Remove(invoker);
    }
    #endregion
}
