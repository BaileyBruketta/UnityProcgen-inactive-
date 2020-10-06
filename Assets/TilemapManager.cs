using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TilemapManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Character;
    public GameObject TileToSpawn;
    public Vector3 ClosestZeroPoint;
    public Vector3 LastClosestZeroPoint;

    public Vector3[] TileLocations;
    public GameObject[] GeneratedTiles;
    public GameObject CameraObject;

    int RepeatTimer;
    void Start()
    {
        RepeatTimer = 10;
        TileLocations = new Vector3[121];
        GeneratedTiles = new GameObject[121];
    }

    // Update is called once per frame
    void Update()
    {
        RepeatTimer -= 1;
        TimerCheck();
        
    }

    void TimerCheck()
    {
        if (RepeatTimer < 3)
        {
            FindClosestZeroPoint();
        }
    }

    void FindClosestZeroPoint()
    {
        Vector3 PlayerLoc = Character.transform.localPosition;

        int XValue;int ZValue;
        int XMod;  int ZMod;
        int XInt = (int)PlayerLoc.x;
        int ZInt = (int)PlayerLoc.z;
        XMod = XInt % 10;
        ZMod = ZInt % 10;

        if (XMod > 0)
        {
            if (XMod < 5)
            {
                XInt = XInt - XMod;
            }
            else { int L = 10 - XMod; XInt += L; }
        }
        else
        {
            if (XMod > -4)
            {
                XInt = XInt - XMod;
            }else { int L = -10 - XMod; XInt -= L; }

        }


        if (ZMod > 0)
        {
            if (ZMod < 5)
            {
                ZInt = ZInt - ZMod;
            }
            else { int L = 10 - ZMod; ZInt += L; }
        }
        else
        {
            if (ZMod > -4)
            {
                ZInt = ZInt - ZMod;
            }
            else { int L = -10 - ZMod; ZInt -= L; }

        }

        Vector3 NewLoc = new Vector3(0, 0, 0);
        NewLoc.x = (float)XInt;
        NewLoc.z = (float)ZInt;
        LastClosestZeroPoint = ClosestZeroPoint;
        ClosestZeroPoint.Set(NewLoc.x,NewLoc.y,NewLoc.z);
        RepeatTimer = 10;
        CheckZeroPointDiscrepency();
        

    }
    void CheckZeroPointDiscrepency()
    {
        if(ClosestZeroPoint != LastClosestZeroPoint)
        {
            ClearAllTiles();
            DetermineTilesToGenerate();
        }
    }
    void ClearAllTiles()
    {
        for (int i = 0; i < 121; i++)
        {
            if (GeneratedTiles[i] != null)
            {
                Destroy(GeneratedTiles[i]);
            }
        }
    }
    void DetermineTilesToGenerate()
    {
        int TileNumber = 0; 
        for (int XV = -50; XV < 50; XV+=10)
        {
            for (int ZV = -50; ZV < 50; ZV+=10)
            {
                Vector3 TileToCheck = ClosestZeroPoint;
                TileToCheck.x += XV;
                TileToCheck.z += ZV;
                TileNumber += 1;
                GenerateTilesOnScreen(TileToCheck, TileNumber);
            }
        }
    }

    void GenerateTilesOnScreen(Vector3 TileToManipulate, int TileNumber)
    {
        GameObject newTile = Instantiate(TileToSpawn);
        newTile.transform.position = TileToManipulate;
        GeneratedTiles[TileNumber] = newTile;
        //TileLocations[TileNumber] = TileToManipulate;
    }

    void ConstructNewTile()
    {

    }

    void SeeIfTileExistsAtLocation()
    {

    }

    
}
