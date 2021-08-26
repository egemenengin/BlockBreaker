//Egemen Engin
//https://github.com/egemenengin

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    
    [SerializeField] Sprite[] hitSprites;
    //cached reference
    Level level;

    //state variables
    [SerializeField] int timesHit; // TODO serialized for onlye debug
    /// </summary>
    private void Start()
    {
        countBreakableBlocks();
    }

    private void countBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (gameObject.tag == "Breakable")
        {
           
                level.countBlocks();
            
          
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Breakable")
        {
            handleHit();
        }
        else
        {

        }

    }

    private void handleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length+1;
        if (timesHit == maxHits)
        {
            destroyBlock();
        }
        else
        {
            showNextHitSprite();
        }
    }

    private void showNextHitSprite()
    {
        int spriteIndex = timesHit-1;
        if (hitSprites.Length > 0 && hitSprites[spriteIndex]!= null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing ");
        }
    }

    private void destroyBlock()
    {
        playBlockDestroySFX();
        Destroy(gameObject, 0.1f);
        level.BlockDestroyed();
        TriggerSparklesVFX();

    }

    private void playBlockDestroySFX()
    {
        FindObjectOfType<GameSession>().addToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX,transform.position,transform.rotation);
        Destroy(sparkles, 1f);
    }
}
