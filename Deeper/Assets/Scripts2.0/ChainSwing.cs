using UnityEngine;
using UnityEngine.Tilemaps;

public class ChainSwing : MonoBehaviour
{
    public Tilemap tilemap;
    public float swingAmplitude = 0.1f;
    public float swingSpeed = 1.0f;

    private Vector3Int[] tilePositions;
    private Vector3[] initialPositions;

    void Start()
    {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        int tileCount = 0;
        foreach (var tile in allTiles)
        {
            if (tile != null)
                tileCount++;
        }

        tilePositions = new Vector3Int[tileCount];
        initialPositions = new Vector3[tileCount];

        int index = 0;
        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                if (tilemap.GetTile(pos) != null)
                {
                    tilePositions[index] = pos;
                    initialPositions[index] = tilemap.GetCellCenterWorld(pos);
                    index++;
                }
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < tilePositions.Length; i++)
        {
            Vector3 newPos = initialPositions[i];
            newPos.x += Mathf.Sin(Time.time * swingSpeed) * swingAmplitude;
            tilemap.SetTransformMatrix(tilePositions[i], Matrix4x4.TRS(newPos - tilemap.GetCellCenterWorld(tilePositions[i]), Quaternion.identity, Vector3.one));
        }
    }
}
