using UnityEngine;
using System.Collections;

public class FluidController : MonoBehaviour {
    public MeshRenderer[] fluids;
    public Material blue;
    public Material yellow;
    public int[] patientsStates;
    public ScenarioController scenarioController;
    int state = 0;
	void Start () {
        patientsStates = new int[3];
	}
	
	// Update is called once per frame
	void Update () {
  /*      switch (state)
        {
            case 0:
                if (scenarioController.scenario.currentPosition>=194)
                {
                    foreach (MeshRenderer mr in fluids)
                        mr.material = blue;
                    state++;
                }
                break;
            case 1:
                if (scenarioController.scenario.currentPosition >= 623)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        patientsStates[i] = Random.Range(0, 4);
                        for (int j = 0; j < patientsStates[i]; j++)
                            fluids[i * 3 + j].material = yellow;
                    }
                    state++;
                    for (int j = 0; j < 3; j++)
                        fluids[9 + j].material = yellow;
                }
            break;
        }*/
	}
}
