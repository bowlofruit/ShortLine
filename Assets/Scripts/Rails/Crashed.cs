using UnityEngine;

public class Crashed : MonoBehaviour
{
    public void CrashOrRepair(bool canCrash, bool canRepair)
    {
        var mesh = gameObject;
        if (canCrash)
        {
            Destroy(this.gameObject);
        }
        if (canRepair)
        {
            Instantiate(mesh);
        }
    }

}