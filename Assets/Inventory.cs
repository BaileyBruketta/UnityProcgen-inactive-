using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<int> ID;
    public List<bool> isStackable;
    public List<int> numberOfItems;
    public List<bool> isFood;
    public List<bool> isWeapon;
    public List<bool> isMedicine;
    public List<bool> isMisc;
    public List<float> WeightList;

    public string PlayerName;

    //for UI ------------------------------
    public RectTransform content = null;
    public List<string> itemNames = null;
    public List<Sprite> itemImages = null;
    public Transform SpawnPoint = null;
    public GameObject item = null;
    //end UI --------------------------------
    public GameObject[] ItemSlots;

    // Start is called before the first frame update
    void Start()
    {
        //ID            = new int[20];
        //isStackable   = new bool[20];
        //numberOfItems = new int[20];
        ///isFood        = new bool[20];
        //isWeapon      = new bool[20];
        //isMedicine    = new bool[20];
        //isMisc        = new bool[20];
        PullInventoryFromText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddItem(int ItemID)
    {
        string ItemStats = GetItemDefaults(ItemID);
        string[] split = ItemStats.Split(',');

        numberOfItems.Add(1);

        ID.Add(ItemID);
        isStackable.Add(bool.Parse(split[2]));
    
        isWeapon.Add(bool.Parse(split[4]));
        isMedicine.Add(bool.Parse(split[5]));
        isMisc.Add(bool.Parse(split[7]));
        isFood.Add(bool.Parse(split[3]));
        WeightList.Add(float.Parse(split[8]));
    }

    string GetItemDefaults(int id)
    {
        string retval = "";

        string Path = "Assets/Data" + PlayerName + "/ItemTypes.txt";
        string[] lines = File.ReadAllLines(Path);

        //find item numbers
        for (int i = 0; i < lines.Length; i++)
        {
            string[] split = lines[i].Split(',');
            if (int.Parse(split[0]) == id)
            {
                retval = lines[i];
            }

        }

        return retval;
    }

    void TestUI()
    {
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

    void PullInventoryFromText()
    {
        string Path = "SaveFiles/" + PlayerName + "/inventory.txt";
        //StreamReader reader = new StreamReader(Path);

        //reader.Close();
        string[] lines = File.ReadAllLines(Path);

        for (int i = 0; i < ID.Count; i++)
        {
            if (i < lines.Length)
            {
                if (lines[i] != null)
                {
                    string[] split = lines[i].Split(',');
                    //ID[i] = int.Parse(split[0]);
                    //ID[i] = int.Parse(string.Concat(split[0].Where(c => !char.IsWhiteSpace(c))));
                    ID.Add(int.Parse(string.Concat(split[0].Where(c => !char.IsWhiteSpace(c)))));
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
    public void RenderMedicine()
    {
        for (int i = 0; i < ItemSlots.Length; i++)
        {
            Destroy(ItemSlots[i]);
        }

        int ItemsOfAppropriateType = 0;
        for (int i = 0; i < ID.Count; i++)
        {
            if(isMedicine[i] == true)
            {
                ItemsOfAppropriateType += 1;
            }
        }

        ItemSlots = new GameObject[ItemsOfAppropriateType];
        content.sizeDelta = new Vector2(0, ItemsOfAppropriateType * 60);
        for (int i = 0; i < ItemsOfAppropriateType; i++)
        {
            float spawnY = (i * 60) - 120;
            Vector3 pos = new Vector3(SpawnPoint.position.x, -spawnY, SpawnPoint.position.z);
            GameObject SpawnedItem = Instantiate(item, pos, SpawnPoint.rotation);
            SpawnedItem.transform.SetParent(SpawnPoint, false);
            ItemDetails itemDetails = SpawnedItem.GetComponent<ItemDetails>();
            itemDetails.text.text = itemNames[i];
            itemDetails.image.sprite = itemImages[i];
            ItemSlots[i] = SpawnedItem;
        }
    }
    void RenderMisc()
    {

    }
    void CraftingPress()
    {

    }
}
