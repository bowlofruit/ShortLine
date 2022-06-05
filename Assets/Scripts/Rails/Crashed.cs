using UnityEngine;

public class Crashed : MonoBehaviour
{
    [SerializeField] GameObject rails;
    public void CrashOrRepair(bool canCrash, bool canRepair)
    {
        if (canCrash)
        {
            rails.SetActive(false);
        }
        if (canRepair)
        {
            rails.SetActive(true);
        }
    }

}