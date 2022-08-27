using Services;
using UnityEngine;

public class BootApp : MonoBehaviour
{
    private void Awake()
    {
        ServiceResolver.InitServices();
    }
}
