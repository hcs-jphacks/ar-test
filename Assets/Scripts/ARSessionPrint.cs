using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ARSessionPrint : MonoBehaviour
{

    [SerializeField]
    private Text targetText;

    // フレーム毎に呼ばれる
    void Update()
    {
        if (ARSession.state == ARSessionState.CheckingAvailability)
        {
            targetText.text = "CheckingAvailability";
            print("session>>>CheckingAvailability");
        }
        else if (ARSession.state == ARSessionState.Ready)
        {
            targetText.text = "Ready";
            print("session>>>Ready");
        }
        else if (ARSession.state == ARSessionState.SessionInitializing)
        {
            targetText.text = "SessionInitializing";
            print("session>>>SessionInitializing");
        }
        else if (ARSession.state == ARSessionState.SessionTracking)
        {
            targetText.text = "SessionTracking";
            print("session>>>SessionTracking");
        }
        else if (ARSession.state == ARSessionState.Installing)
        {
            targetText.text = "Installing";
            print("session>>>Installing");
        }
        else if (ARSession.state == ARSessionState.NeedsInstall)
        {
            targetText.text = "NeedsInstall";
            print("session>>>NeedsInstall");
        }
        else if (ARSession.state == ARSessionState.Unsupported)
        {
            targetText.text = "Unsupported";
            print("session>>>Unsupported");
        }
        else if (ARSession.state == ARSessionState.None)
        {
            targetText.text = "None";
            print("session>>>None");
        }
    }
}
