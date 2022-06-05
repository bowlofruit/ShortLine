using UnityEngine;

public class TrainPattern : MonoBehaviour
{
    protected float _speed;
    protected float _rotSpeed;
    [SerializeField] protected bool _canCrushed;
    [SerializeField] protected bool _canFixed;
    protected bool _finished;
    [SerializeField] protected GameObject[] waypoints;
    [SerializeField] protected int currentWP;
    [SerializeField] protected GameObject _model;
    [SerializeField] protected GameObject _color;


    private void OnTriggerEnter(Collider other)
    {
        Triggers(other);
    }

    private void Update()
    {
        ProcessTracker();
    }

    protected void Triggers(Collider other)
    {
        if (other.gameObject.CompareTag("Switch"))
        {
            other.GetComponent<Swap>().RoadSwitch(this.gameObject.GetComponent<Collider>(), ref waypoints, ref currentWP);
        }
        if (other.gameObject.CompareTag("Lighter"))
        {
            other.GetComponent<TrafficLightSwitcher>().FallTrafficLighter(this.gameObject.GetComponent<Collider>(), ref waypoints, _canCrushed, _canFixed, ref _model);
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            Finished(other);
        }
        if (other.gameObject.CompareTag("Crusher"))
        {
            other.GetComponent<Crashed>().CrashOrRepair(_canCrushed, _canFixed);
            Destroy(this.gameObject);
            TrainCounter._allTrains -= 1;
        }
        if (other.gameObject.CompareTag("Train"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            TrainCounter._allTrains -= 1;
        }
    }

    private void Finished(Collider other)
    {
        TrainCounter._allTrains -= 1;
        if (other.name == _color.name || _color.name == "White" || _color.name == "Black")
        {
            TrainCounter._rightTrains += 1;
        }
        Destroy(this.gameObject);
    }

    protected void ProcessTracker()
    {
        if (Vector3.Distance(this.transform.position, waypoints[currentWP].transform.position) < 3)
            currentWP++;

        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWP].transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, _rotSpeed * Time.deltaTime);
        this.transform.Translate(0, 0, _speed * Time.deltaTime);
    }
}