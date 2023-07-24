using UnityEngine;

namespace Puck
{
    public interface IPuckScript
    {
        Transform PuckTransform { get; }
    }
}