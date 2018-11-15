using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Build : MonoBehaviour{
    [SerializeField]   
    private GameObject prefab;
    [SerializeField]
    private Node node;
    [SerializeField]
    private GameObject NodesFolder;
    public List<Vector3> WorldPositions { get; set; }
    public List<Vector3> GridPositions { get; set; }
    public List<Node> Nodes { get; set; }
    [SerializeField]
    private CameraMovement cameraMovement;
    private float spriteSize = 0;

    /*
    private void OnMouseDown()
    {
        
        // left click - get info from selected tile
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;

            // convert mouse click's position to Grid position
            Tilemap gridLayout = GetComponent<Tilemap>();
            Vector3Int cellPosition = gridLayout.WorldToCell(pz);
            Vector3 wp = gridLayout.CellToWorld(cellPosition);
            float spriteSize = ((Tile)gridLayout.GetTile(cellPosition)).sprite.bounds.size.x;
            Vector3 finalWp = new Vector3(wp.x + spriteSize/2, wp.y + spriteSize/2);
            // set selectedUnit to clicked location on grid
            Instantiate(prefab, finalWp, transform.rotation);

            //Debug.Log("initial wp: " + pz);
            //Debug.Log("cell pos: " + cellPosition);
            //Debug.Log("final wp: " + wp);
        }
        
    }
    */
    public void Start()
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        tilemap.CompressBounds();
        WorldPositions = new List<Vector3>();
        GridPositions = new List<Vector3>();
        Nodes = new List<Node>();

        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 place = tilemap.CellToWorld(localPlace);
            if (tilemap.HasTile(localPlace))
            {
                Tile tile = tilemap.GetTile(localPlace) as Tile;
                spriteSize = tile.sprite.bounds.size.x;
                Vector3 newPos = new Vector3(place.x + spriteSize / 2, place.y + spriteSize / 2);
                WorldPositions.Add(newPos);
                GridPositions.Add(localPlace);
                Nodes.Add(Instantiate(node, newPos, Quaternion.identity));
                Nodes[Nodes.Count-1].transform.parent = NodesFolder.transform;
                //Debug.Log(localPlace);
                //Debug.Log(newPos);
                //Instantiate(prefab, newPos, transform.rotation);
            }
        }
        //Debug.Log(worldPositions[tilemap.cellBounds.size.x-1]);
        //cameraMovement.SetLimit(new Vector3(worldPositions[tilemap.cellBounds.size.x - 1].x + spriteSize, worldPositions[tilemap.cellBounds.size.x - 1].y - spriteSize));
    }
}
