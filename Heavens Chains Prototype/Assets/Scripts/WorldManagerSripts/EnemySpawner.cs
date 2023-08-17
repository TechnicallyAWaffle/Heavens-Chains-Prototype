using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using BehaviorTree;

public class EnemySpawner : MonoBehaviour
{
    private Object[] levelEnemies;
    //Hardcoded to prelude for now
    private string levelEnemiesFolder = "Entities/Enemies/" + "PreludeEnemies";
    public GameObject player;
    private GameObject previousEnemy;
    //private float radius = 5;
    private List<int> squadRanks = new List<int>{1, 2, 2, 3, 3};

    //Hardcoded for now. Will grab enemy data from sibling script in WorldManager in the future
    //public String layerEnemies = "PreludeEnemies";
    // Start is called before the first frame update
    void Start()
    {
        levelEnemies = Resources.LoadAll(levelEnemiesFolder, typeof(GameObject));
        //StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame

    //Will take a couple of parameters in the future to determine who to spawn and whatnot, including level as one of the primary ones
    //Currently ONLY loops through the list of enemies in the layer one time and spawns each one ONCE 
    
    /*
    IEnumerator SpawnEnemies()
    {
        int index = 0;
        Vector3 origin = player.transform.position;
        foreach (GameObject enemy in levelEnemies)
        {
            List <BehaviorTreeBase> squad = new List<BehaviorTreeBase>();
            for (int i=1;i<=5;i++)
            {
                //Replace with better identifier other than enemy name. Probably custom tag? Or just another script with all enemy properties.
                Vector3 randomEnemyPosition = origin + Random.insideUnitSphere * radius;
                string scriptName = enemy.name + "BT";
                GameObject currentEnemy = Instantiate(enemy, randomEnemyPosition, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
                if (scriptName == "GuardianAngelBT")
                {
                    squad.Add(currentEnemy.GetComponent<GuardianAngelBT>());
                }
                currentEnemy.GetComponent<GuardianAngelBT>().ConfigureEnemy(enemy.name, ref squad, squadRanks[index]);
                index++;
            }
        }

    }
    */
}
