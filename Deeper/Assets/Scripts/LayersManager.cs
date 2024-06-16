using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LayersManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> levels;
    private int currentLevelIndex = 0;

    [SerializeField]
    private int currentLayerMask;
    [SerializeField]
    private int otherLayerMask;

    [SerializeField]
    private SpriteRenderer player;

    [SerializeField]
    private GameObject depthPanel;

    private void Start()
    {
        levels[0].layer = currentLayerMask;
        levels[0].GetComponent<TilemapRenderer>().sortingOrder = levels.Count * 3;
        foreach (Transform child in levels[0].transform)
        {
            child.gameObject.layer = currentLayerMask;
            SpriteRenderer sprite;
            if (sprite = child.GetComponent<SpriteRenderer>())
            {
                sprite.sortingOrder = levels.Count * 3 - 1;
            }
            else
            {
                TilemapRenderer tilemap;
                if (tilemap = child.GetComponent<TilemapRenderer>())
                {
                    tilemap.sortingOrder = levels.Count * 3 - 1;
                }
            }
        }
        for (int i = 1; i < levels.Count; i++)
        {
            levels[i].layer = otherLayerMask;
            levels[i].GetComponent<TilemapRenderer>().sortingOrder = levels.Count * 3 - 3 * i;
            foreach (Transform child in levels[i].transform)
            {
                child.gameObject.layer = otherLayerMask;
                SpriteRenderer sprite;
                if (sprite = child.GetComponent<SpriteRenderer>())
                {
                    sprite.sortingOrder = levels.Count * 3 - (3 * i + 1);
                }
                else
                {
                    TilemapRenderer tilemap;
                    if (tilemap = child.GetComponent<TilemapRenderer>())
                    {
                        tilemap.sortingOrder = levels.Count * 3 - (3 * i + 1);
                    }
                }
            }
            GameObject panel = GameObject.Instantiate(depthPanel, player.transform);

            panel.GetComponent<SpriteRenderer>().sortingOrder = levels.Count * 3 - (3 * i - 1);
        }
    }

    public void NextLevel()
    {
        levels[currentLevelIndex].layer = otherLayerMask;
        foreach (Transform child in levels[currentLevelIndex].transform)
        {
            child.gameObject.layer = otherLayerMask;
        }
        currentLevelIndex++;
        levels[currentLevelIndex].layer = currentLayerMask;
        foreach (Transform child in levels[currentLevelIndex].transform)
        {
            child.gameObject.layer = currentLayerMask;
        }
        player.sortingOrder = levels.Count * 3 - currentLevelIndex * 3;

        player.gameObject.transform.localScale *= 1 - currentLevelIndex * 0.1f;
        player.GetComponentInParent<BoxCollider2D>().size *= 1 - currentLevelIndex * 0.1f;
        GetComponentInParent<Player>().OnNextLevel(currentLevelIndex);
    }
}
