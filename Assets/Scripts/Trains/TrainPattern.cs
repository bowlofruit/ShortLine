using UnityEngine;

public abstract class TrainPattern : MonoBehaviour
{
    private float speed, rotSpeed;
    [SerializeField] protected GameObject[] waypoints;
    [SerializeField] protected int currentWP;
    [SerializeField] protected GameObject _model;
    [SerializeField] protected GameObject _color;

    public abstract bool CanCrushed();
    public abstract bool CanRepair();
    public abstract bool LightTrafficBehaviour();
    protected void SetParams(float speed, float rotSpeed)
    {
        this.speed = speed;
        this.rotSpeed = rotSpeed;
    }

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
        MonoBehaviour mono = other.GetComponent<MonoBehaviour>();

        if (other.gameObject.CompareTag("Train"))
        {
            Destroy(this.gameObject);
            TrainCounter._allTrains -= 1;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            Finished(other);
        }
        if (mono is Swap swap)
        {
            swap.RoadSwitch(transform.position, ref waypoints, ref currentWP);
        }

        if (LightTrafficBehaviour() && mono is TrafficLightSwitcher light)
        {
            light.FallTrafficLighter(this, ref waypoints, ref _model);
        }        
        if (mono is Crashed crasher)
        {
            if (CanCrushed())
            {
                crasher.Crash();
            }
            if (CanRepair())
            {
                crasher.Repair();
            }            
            if (CanCrushed() || CanRepair())
            {
                Destroy(this.gameObject);
                TrainCounter._allTrains -= 1;
            }            
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
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rotSpeed * Time.deltaTime);
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}