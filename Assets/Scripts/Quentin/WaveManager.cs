using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public List<Wave> listWave;
    private Wave currentWave;

    public bool pause = true;

    private int actualWaveNumber;

    public bool End = false;

    public MonsterManager _MonstreManager;


    // Start is called before the first frame update
    void Start()
    {
        currentWave = listWave[0];
        launchWave(currentWave);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWave.getFinish() && !pause && listWave.Count > 0)
        {
            listWave.RemoveAt(0);
            currentWave = listWave[0];
            launchWave(currentWave);
        }
        if (listWave.Count == 0)
        {
            End = true;
        }

        if (End && _MonstreManager.MonstersAlive.Count <= 0)
        {
            SceneManager.LoadScene("Victoire");
        }
    }

    public void launchWave(Wave wave)
    {
        if (listWave.Count > 0)
        {
            wave.setActivate(true);
            actualWaveNumber += 1;
        }
    }

    public void launchNextWave()
    {
        if (listWave.Count > 0)
        {
            listWave.RemoveAt(0);
            if (listWave.Count > 0)
            {
                currentWave = listWave[0];
                launchWave(currentWave);
            }
        }
    }

    public void setPause()
    {
        this.pause = !pause;
        if (pause == false)
        {
            launchWave(currentWave);
        }
    }

    public int getActualWaveNumber()
    {
        return actualWaveNumber;
    }
}
