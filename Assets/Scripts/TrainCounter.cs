using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainCounter : MonoBehaviour
{
    public Text _allTrainsText;
    public Text _rightTrainsText;
    public static int _allTrains;
    public static int _rightTrains;

    private void Start()
    {
        _allTrains = 6;
        _rightTrains = 0;
    }

    private void Update()
    {
        _allTrainsText.text = $"Trains left: {_allTrains}";
        _rightTrainsText.text = $"Right station: {_rightTrains}";
    }
}
