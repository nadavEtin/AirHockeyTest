using System;
using System.Collections;
using Assets.Scripts.Utility;
using Events;
using GameCore.Json;
using UnityEngine;
using UnityEngine.Networking;
using VContainer;

namespace GameCore.ServerComs
{
    public class UWebRequest : MonoBehaviour, IUWebRequest
    {
        private EventBus _eventBus;
        
        [Inject]
        private void Construct(IJsonSerialization eventBus)
        {
            var json = eventBus;
        }
        
        public void GetRequest(string uri, Action<bool, string> onFinishCallback)
        {
            StartCoroutine(GetRequestEnum(uri, onFinishCallback));
        }

        private IEnumerator GetRequestEnum(string uri, Action<bool, string> onFinishCallback)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                yield return webRequest.SendWebRequest();
                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.Success:
                        //Invoke callback with the received data
                        onFinishCallback(true, webRequest.downloadHandler.text);
                        break;
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.ProtocolError:
                    case UnityWebRequest.Result.DataProcessingError:
                        //Error handling
                        _eventBus.Publish(GameplayEvent.Error, new ErrorEventParams(webRequest.error));
                        Debug.LogError("get request error: " + webRequest.error);
                        break;
                }
            }
        }
    }
}