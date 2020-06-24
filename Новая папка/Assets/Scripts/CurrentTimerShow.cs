using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentTimerShow : MonoBehaviour {
    public ScenarioController scenarioController;
    public Text time;
    public GameObject panel;
	void Update () {
        /*ScenarioPart scenarioPart = scenarioController.scenario.scenario[scenarioController.scenario.currentPosition].scenarioParts[0];
        if (scenarioPart.interactingType == ScenarioPart.InteractingType.Wait)
        {
            panel.SetActive(true);
            int timer = Mathf.RoundToInt(scenarioPart.floatValues[0]);
            time.text = timer.ToString();
        }
        else
            panel.SetActive(false);*/
	}
}
