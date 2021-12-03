using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ad : MonoBehaviour
{
    [SerializeField] protected string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] protected string _iOsAdUnitId = "Interstitial_iOS";

    protected string _adUnitId;


    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;
    }
}
