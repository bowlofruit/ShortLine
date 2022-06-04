using UnityEngine;

public class TimeSpawner : MonoBehaviour
{
    [SerializeField] float _spawnTimer;

    private void Update()
    {
        if (_spawnTimer > 0)
        {
            _spawnTimer -= Time.deltaTime;
        }
        else
        {
            if(gameObject.GetComponent<SimpleTrain>() != null)
            {
                this.gameObject.GetComponent<SimpleTrain>().enabled = true;
            }

            if (gameObject.GetComponent<MadTrain>() != null)
            {
                this.gameObject.GetComponent<MadTrain>().enabled = true;
            }

            if (gameObject.GetComponent<ServerTrain>() != null)
            {
                this.gameObject.GetComponent<ServerTrain>().enabled = true;
            }
        }
    }
}
