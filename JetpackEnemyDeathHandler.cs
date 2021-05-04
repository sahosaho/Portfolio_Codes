using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
   public float deathSpawnTime;
    public Enemy_AI enemyAi;
    public GameObject enemyPrefab;
    public Vector3 enemyCurrentPos;
    public Vector3 offset;
  
    void Start()
    {

        enemyAi = GameObject.Find("Enemy").GetComponent<Enemy_AI>();
       

      
    }

    // Update is called once per frame
    void Update()
    {
        enemyCurrentPos = enemyAi.gameObject.transform.position;
      


        if(enemyAi.gameObject == null)
        {
           enemyAi = GameObject.Find("Enemy").GetComponent<Enemy_AI>(); 
        }
        


    

        
       if(enemyAi.isDead == true)
        {
           
            StartCoroutine("EnemyInitialize");
            enemyAi.isDead = false;
        }





    }

    IEnumerator EnemyInitialize()
    {
         enemyAi.enemyAnimator.GetComponent<Animator>().SetBool("tapPermission", true);
        yield return new WaitForSeconds(deathSpawnTime  );
        enemyAi.enemyJetpackFuel = 1;
        enemyAi.gameObject.SetActive(true);
        enemyAi.transform.position = enemyCurrentPos + offset;
    }


}
