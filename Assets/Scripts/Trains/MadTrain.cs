public class MadTrain : TrainPattern
{
    public override bool CanCrushed() => true;
    public override bool CanRepair() => false;
    public override bool LightTrafficBehaviour() => false;
    private void Awake() => SetParams(speed: 15, rotSpeed: 3);
}