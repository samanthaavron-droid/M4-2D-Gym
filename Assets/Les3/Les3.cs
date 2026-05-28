using UnityEngine;
using UnityEngine.Tilemaps;

public class Les3 : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    BoundsInt bounds;
    int width, height;
    int x0, y0;
    void Start()
    {
        bounds = tilemap.cellBounds;
        width = bounds.size.x;
        height = bounds.size.y;
        x0 = bounds.xMin;
        y0 = bounds.yMin;
    }
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldPosotion = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosotion.z = 0;

        Vector3Int CellPosition = tilemap.WorldToCell(worldPosotion);
        Debug.Log(CellPosition);

        for (int i = 0 + x0; i < bounds.size.x; i++)
        {
            for (int j = 0 + y0; j < bounds.size.y; j++)
            {
                Vector3Int pos = new Vector3Int(i, j, 0);

                tilemap.SetTileFlags(pos, TileFlags.None);
                tilemap.SetColor(pos, Color.white);
            }
        }

        tilemap.SetTileFlags(CellPosition, TileFlags.None);
        tilemap.SetColor(CellPosition, Color.red);
    }
}
