using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX =-1.66f;
    [SerializeField] float maxX = 17.66f;
    [SerializeField] float screenWidthInUnits = 15f;

    //cache the references
    GameSession theGameSession;
    Ball theBall;
    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
      
        Vector2 paddlePos = new Vector2(transform.position.x,transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX,maxX);
        transform.position = paddlePos;
      
        
       

    }
    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
            return mousePosInUnits;
        }
    }
}

