public class MadTrain : TrainPattern
{
    protected float Speed { get => _speed; set => _speed = value; }
    protected float RotSpeed { get => _rotSpeed; set => _rotSpeed = value; }
    protected bool CanCrushed { get => _canCrushed; set => _canCrushed = value; }
    protected bool CanFixed { get => _canFixed; set => _canFixed = value; }

    private void Awake()
    {
        Speed = 15;
        RotSpeed = 3;
        CanCrushed = true;
        CanFixed = false;
    }
}
