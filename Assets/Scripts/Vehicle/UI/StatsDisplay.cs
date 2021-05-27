using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Vehicle.Stats;

namespace Vehicle.UI
{
    public class StatsDisplay : MonoBehaviour
    {
        static StatsDisplay _instance;
        public static StatsDisplay Instance
        {
            get
            {
                if(_instance == null) Debug.Log("StatsDisplay is null");
                return _instance;
            }
        }
        public VehicleStatsTracker car;
        public Text countdown;
        public Text cp;
        public Text time;
        // Start is called before the first frame update
        void Awake()
        {
            _instance = this;
        }

        // Update is called once per frame
        void Update()
        {
            if(car == null) return;
            cp.text =  car.currentCheckpoint.ToString();
            time.text = (Mathf.Round(car.totalTime * 100)/100).ToString();
        }

        public void Countdown(int countdownLength, VehicleStatsTracker car)
        {
            this.car = car;
            StartCoroutine(CountdownDisplay(countdownLength));
        }

        IEnumerator CountdownDisplay(int countdownLength)
        {
            countdown.gameObject.SetActive(true);
            for (int i = countdownLength; i > 0 ; i--)
            {
                countdown.text = i.ToString();
                yield return new WaitForSeconds(1);
            }
            countdown.text = "Go!";
            yield return new WaitForSeconds(1);
            countdown.gameObject.SetActive(false);
        }
    }
}
