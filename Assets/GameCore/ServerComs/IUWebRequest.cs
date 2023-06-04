using System;

namespace GameCore.ServerComs
{
    public interface IUWebRequest
    {
        void GetRequest(string uri, Action<bool, string> onFinishCallback);
    }
}