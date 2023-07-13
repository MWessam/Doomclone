using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileToWall : MonoBehaviour
{
    [SerializeField] GameObject _wall;
    [SerializeField] Tilemap _tilemap;
    [SerializeField] Transform _wallHolder;
    [SerializeField] int _tileHeight;           // For Walls
    [SerializeField] int _emptyTileHeight;      // For ceilings
    TileBase[] _tileBase;
    // Start is called before the first frame update
    void Start()
    {
        for (int x = _tilemap.cellBounds.xMin; x < _tilemap.cellBounds.xMax; x++)
        {
            for (int y = _tilemap.cellBounds.yMin; y < _tilemap.cellBounds.yMax; y++)
            {
                Tile tile = (Tile) _tilemap.GetTile(new Vector3Int(x, y, 0));
                if (tile != null)
                {
                    for (int height = _emptyTileHeight; height < _tileHeight + _emptyTileHeight; height++)
                    {
                        GameObject wall = Instantiate(_wall, new Vector3(x + _tilemap.tileAnchor.x + _tilemap.transform.position.x, (0.5f + height), y + _tilemap.tileAnchor.y + _tilemap.transform.position.z), transform.rotation, _wallHolder);
                        wall.GetComponent<MeshRenderer>().material.mainTexture = tile.sprite.texture;
                    }
                }
            }
        }
    }
}
