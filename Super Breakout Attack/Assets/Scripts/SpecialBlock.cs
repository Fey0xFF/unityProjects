using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialBlock : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockExplodeVFX;
    [SerializeField] Sprite[] hitSprites;

    // Cached References
    Level level;
    GameStatus gameStatus;

    // State Variables
    [SerializeField] int timesHit; //TODO only serialized for debugging


    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        if (tag == "Breakable")
        {
            level.AddBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(4);
        if (tag == "Breakable")
        {
            HandleHit();
            ShowNextHitSprite();
        }

    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array. " + gameObject.name);
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        TriggerSoundFX();
        level.RemoveBlock();
        gameStatus.IncreaseScore();
        TriggerExplodeVFX();
        Destroy(gameObject);
        
    }

    private void TriggerSoundFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerExplodeVFX()
    {
        GameObject explode = Instantiate(blockExplodeVFX, transform.position, transform.rotation);
        Destroy(explode, 1f);
    }
}
