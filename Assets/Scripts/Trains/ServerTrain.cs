public class ServerTrain : TrainPattern
{
    public override bool CanCrushed() => false;
    public override bool CanRepair() => true;
    public override bool LightTrafficBehaviour() => true;
    private void Awake() => SetParams(speed: 12, rotSpeed: 3);
}