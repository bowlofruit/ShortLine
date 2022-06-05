using UnityEngine;

class Swap : MonoBehaviour
{
    [SerializeField] GameObject[] _straight;
    [SerializeField] GameObject[] _corner;
    [SerializeField] GameObject[] _back;
    [SerializeField] bool _turn;

    private void OnMouseDown()
    {
        switch (_turn)
        {
            case false:
                _turn = true;
                gameObject.transform.Rotate(0, -35, 0);
                break;
            default:
                _turn = false;
                gameObject.transform.Rotate(0, 35, 0);
                break;
        }

    }

    public void RoadSwitch(Vector3 position, ref GameObject[] waypoints, ref int currentPoint)
    {
        currentPoint = 0;
        Vector3 direction = position - transform.position;
        if (Vector3.Dot(transform.forward, direction) > 0)
        {
            waypoints = _back;
        }
        if (Vector3.Dot(transform.forward, direction) < 0)
        {
            waypoints = _turn ? _corner : _straight;
        }
    }
}