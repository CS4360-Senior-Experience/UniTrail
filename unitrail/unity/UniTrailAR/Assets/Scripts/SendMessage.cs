using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlutterUnityIntegration;

public class SendMessage : MonoBehaviour
{   //comment
    public void PrintMessage(){
        UnityMessageManager.Instance.SendMessageToFlutter("We're all getting coffee");
    }
}
