public class SimpleTrain : TrainPattern
{
    public override bool CanCrushed() => false;
    public override bool CanRepair() => false;
    public override bool LightTrafficBehaviour() => true;
    private void Awake() => SetParams(speed: 10, rotSpeed: 2);
}