using UnityEngine;

public class Crashed : MonoBehaviour
{
    [SerializeField] GameObject rails;
    public void Crash()
    {
        rails.SetActive(false);
    }
    public void Repair()
    {
        rails.SetActive(true);
    }
}