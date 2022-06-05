using UnityEngine;

public class TrafficLightSwitcher : MonoBehaviour
{
    private Color _currentColor;
    [SerializeField] GameObject[] _point1, _point2;
    [SerializeField] bool _trainRun;

    private void Start()
    {
        _currentColor = Color.green;
        GetComponent<Renderer>().material.color = _currentColor;
        _trainRun = true;
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && _currentColor == Color.red)
        {
            _currentColor = Color.green;
            _trainRun = true;
        }
        else if (Input.GetMouseButtonDown(0) && _currentColor == Color.green)
        {
            _currentColor = Color.red;
            _trainRun = false;
        }
        GetComponent<Renderer>().material.color = _currentColor;
    }

    public void FallTrafficLighter(TrainPattern train, ref GameObject[] waypoints, ref GameObject model)
    {
        if (_trainRun) return;
        Vector3 direction = train.transform.position - transform.position;
        if (Vector3.Dot(transform.forward, direction) > 0)
        {
            train.transform.Rotate(0, 180, 0);
            waypoints = _point1;
            model.transform.Rotate(0, 180, 0);
        }
        if (Vector3.Dot(transform.forward, direction) < 0)
        {
            train.transform.Rotate(0, 180, 0);
            waypoints = _point2;
            model.transform.Rotate(0, 180, 0);
        }
    }
}
