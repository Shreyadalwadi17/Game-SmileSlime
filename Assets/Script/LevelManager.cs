using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> lvlprefebs;
    public GameObject currentlvl;
    public GameObject parent;
    public int lvlCount = 0;
    private GameObject store;

    private void Awake()
    {
        currentlvl = lvlprefebs[0];
        OnLoadLvel();
    }

    public void OnLoadLvel()
    {
        if (store != null)
        {
            Destroy(store);
        }
        store = Instantiate(lvlprefebs[lvlCount], parent.transform);
    }
    public void ChangeLevel()
    {
        lvlCount += 1;
        OnLoadLvel();
      
    }
  
}
