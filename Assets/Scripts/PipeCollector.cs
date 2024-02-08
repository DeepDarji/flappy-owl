using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollector : MonoBehaviour
{
    private GameObject[] pipeHolders;
    private float distance = 1f;
    private float lastPipesX;
    private float pipeMin = -0.2f;
    private float pipeMax = 0.7f;

    private void Awake()
    {
        pipeHolders = GameObject.FindGameObjectsWithTag("PipeHolder");


        //Get postition and set position to random
        for (int i = 0; i < pipeHolders.Length; i++) { 
            Vector3 temp = pipeHolders[i].transform.position;   
            temp.y = Random.Range(pipeMin, pipeMax);
            pipeHolders[i].transform.position = temp;
        }

        lastPipesX = pipeHolders[0].transform.position.x;

        for (int i = 1; i < pipeHolders.Length; i++)
        {
            if(lastPipesX < pipeHolders[i].transform.position.x)
            {
                lastPipesX = pipeHolders[i].transform.position.x;

            }
        }

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        //check collide with pipeholder
        if(target.tag == "PipeHolder")
        {
            //if true get position
            Vector3 temp = target.transform.position;

            //set position
            temp.x = lastPipesX + distance;
            temp.y = Random.Range(pipeMin,pipeMax);

            //reassign position 
            target.transform.position = temp;

            //reassign back to variable
            lastPipesX = temp.x;
        }
    }

}
