using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int[] ID;
    public bool[] isStackable;
    public int[] numberOfItems;
    public bool[] isConsumable;
    public bool[] isWeapon;

    public string PlayerName;

    //for UI ------------------------------
    public RectTransform content = null;
    public string[] itemNames = null;
    public Sprite[] itemImages = null;
    public Transform SpawnPoint = null;
    public GameObject item = null;
    //end UI --------------------------------

    // Start is called before the first frame update
    void Start()
    {
        ID            = new int[20];
        isStackable   = new bool[20];
        numberOfItems = new int[20];
        isConsumable  = new bool[20];
        isWeapon      = new bool[20];
        PullInventoryFromText();

        //UI ----------------------------------------------------------------------------------
        content.sizeDelta = new Vector2(0, 20 * 60);
        for (int i = 0; i < 20; i++)
        {
            float spawnY = (i * 60) - 120;
            Vector3 pos = new Vector3(SpawnPoint.position.x, -spawnY, SpawnPoint.position.z);
            GameObject SpawnedItem = Instantiate(item, pos, SpawnPoint.rotation);
            SpawnedItem.transform.SetParent(SpawnPoint, false);
            ItemDetails itemDetails = SpawnedItem.GetComponent<ItemDetails>();
            itemDetails.text.text = itemNames[i];
            itemDetails.image.sprite = itemImages[i];

        }
        //end UI -----------------------------------------------------------------------------
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PullInventoryFromText()
    {
        string Path = "SaveFiles/" + PlayerName + "/inventory.txt";
        //StreamReader reader = new StreamReader(Path);

        //reader.Close();
        string[] lines = File.ReadAllLines(Path);

        for (int i = 0; i < ID.Length; i++)
        {
            if (i < lines.Length)
            {
                if (lines[i] != null)
                {
                    string[] split = lines[i].Split(',');
                    //ID[i] = int.Parse(split[0]);
                    ID[i] = int.Parse(string.Concat(split[0].Where(c => !char.IsWhiteSpace(c))));
                }
            }
            else
            {
                ID[i] = 551;
            }
        }
    }

    void RenderWeapons()
    {

    }
    void RenderFood()
    {

    }
    void RenderArmor()
    {

    }
    void RenderMedicine()
    {

    }
    void RenderMisc()
    {

    }
    void CraftingPress()
    {

    }
}
