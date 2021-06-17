using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlatformScript : MonoBehaviour
{
    public JumpScript jumpSc;
    private Renderer rend;
    private int score;
   
    IEnumerator Start()
    {  
        rend = GetComponent<Renderer>();
        rend.material.color = Color.green;
        score = 0;
        yield return StartCoroutine(PlatformColor());
      
    }

    IEnumerator PlatformColor()
    {
        while (true)
        {
            float timeToJump = 1f;
            float changeColorToRed = Random.Range(1f, 5f);
            float changeColorToGreen = 0.3f;
            yield return new WaitForSeconds(changeColorToRed);
            
            if (!jumpSc.isGrounded)
            {
                Debug.Log("You lost! Your score is:" + score);
                score = 0;
                new WaitForSeconds(1);
            }
            else
            {
                rend.material.color = Color.red;
            }
            
            yield return new WaitForSeconds(timeToJump);
            
            if (jumpSc.isGrounded)
            {
                Debug.Log("You lost! Your score is:" + score);
                score = 0;  
            }
            else
            {
                score++;
            }
            yield return new WaitForSeconds(changeColorToGreen);
            rend.material.color = Color.green;
        }
    }
}
