using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField]
    string _androidGameId;
    [SerializeField]
    string _iOsGameId;
    [SerializeField]
    bool _testMode = true;
    [SerializeField]
    bool _enablePerPlacementMode = true;
    
    string _gameId;

    public static AdManager instance;

    void Awake()
    {
        instance = this;
        InitializeAds();
    }

    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOsGameId : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads initialization failed: {error.ToString()} -{message}");
    }
}

