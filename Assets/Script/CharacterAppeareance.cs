
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterAppeareance : MonoBehaviour
{
    public GameObject Essentials;

    [SerializeField]
    PlayerPrefLooks playerLooksSO;

    public CharacterBodySlider slider;
    public float mouseSensitivity;

    public TextMeshProUGUI text;
    public AudioSource rustle;
    
    public GameObject[] Bodies;
    public GameObject[] Eyes;
    public GameObject[] Irises;
    public GameObject[] Hairs;
    public GameObject[] Beards;
    public GameObject[] Brows;
    public GameObject[] Ears;
    public GameObject[] Hats;
    public GameObject[] Noses;
    public GameObject[] Pants;
    public GameObject[] Shirts;
    public GameObject[] Shoes;
    public GameObject[] Teeths;

    public int bodyIndex = 0;
    public int eyesIndex = 0;
    public int irisIndex = 0;
    public int hairIndex = 0;
    public int beardIndex = 0;
    public int browIndex = 0;
    public int earIndex = 0;
    public int hatIndex = 0;
    public int noseIndex = 0;
    public int pantIndex = 0;
    public int shirtIndex = 0;
    public int shoeIndex = 0;
    public int teethIndex = 0;


    public GameObject armature;

    bool mouseDrag=false;
    float mouseReference;
    float mouseOffset;
    float charRotation;
    float screenFactor = 1;
    public bool isPlayableMode;



    // Start is called before the first frame update
    void Start()
    {
        HideAllParts();

        if (playerLooksSO.hasSaved)
        {
            LoadPlayerLooks();
        }
        else
        {
            RandomizeAppearance();
        }


        Essentials.SetActive(true);  
        

    }

    // Update is called once per frame
    
    void Update()
    {
        
        if (isPlayableMode)
        {
            screenFactor = -1;
        }
        else { screenFactor = 0.5f; }


        if (Input.GetMouseButtonDown(1) && Input.mousePosition.x < Screen.width*screenFactor)
        {
            mouseDrag = true;
            mouseReference = Input.mousePosition.x;
        }
        if (Input.GetMouseButtonUp(1))
        {
            mouseDrag=false;
        }
        


        if(mouseDrag)
        {
            RotateObject();
        }


        UpdateText();

    }

    void UpdateText()
    {
        //text.text = "mouseX = " + Input.mousePosition.x.ToString() + " | mouseY = " + Input.mousePosition.y.ToString();
    }

    public void PlaySound()
    {
        rustle.Play();
    }
    public void ShowCharacter()
    {
        PlaySound();
        HideAllParts();

        Bodies[bodyIndex].SetActive(true);
        Eyes[eyesIndex].SetActive(true);
        Irises[irisIndex].SetActive(true);
        Hairs[hairIndex].SetActive(true);
        Beards[beardIndex].SetActive(true);
        Brows[browIndex].SetActive(true);
        Ears[earIndex].SetActive(true);
        Hats[hatIndex].SetActive(true);
        Noses[noseIndex].SetActive(true);
        Pants[pantIndex].SetActive(true);
        Shirts[shirtIndex].SetActive(true);
        Shoes[shoeIndex].SetActive(true);
        Teeths[teethIndex].SetActive(true);
        

        //edge case for the mohawk
        
        
    }

    public void RandomizeAppearance()
    {
        bodyIndex   = Random.Range(0, Bodies.Length);
        eyesIndex   = Random.Range(0, Eyes.Length);
        irisIndex   = Random.Range(0,Irises.Length);
        hairIndex   = Random.Range(0,Hairs.Length);
        beardIndex  = Random.Range(0,Beards.Length);
        browIndex   = Random.Range(0,Brows.Length);
        earIndex    = Random.Range(0,Ears.Length);
        hatIndex    = Random.Range(0,Hats.Length);
        noseIndex   = Random.Range(0,Noses.Length);
        pantIndex   = Random.Range(0,Pants.Length);
        shirtIndex  = Random.Range(0,Shirts.Length);
        shoeIndex   = Random.Range(0,Shoes.Length);
        teethIndex  = Random.Range(0,Teeths.Length);

        if (hairIndex == 3) { hatIndex = 0; }

        if(slider is not null)
        {
            slider.UpdateSlider();
        }
        

        ShowCharacter();
            
    }

    public void HideAllParts()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
        armature.SetActive(true);
    }

    void RotateObject()
    {
        mouseOffset = Input.mousePosition.x - mouseReference;  //get the movement
        charRotation = mouseOffset * mouseSensitivity;  //apply sensitivity
        transform.Rotate(0,-charRotation,0); //apply rotation
        mouseReference = Input.mousePosition.x;

    }



    public void ChangeHair(float indexe)
    {
        int index = (int)indexe;
        Hairs[hairIndex].SetActive(false);
        hairIndex = index;
        Hairs[hairIndex].SetActive(true);

        if (hairIndex == 3) 
        {
            ChangeHat(0);
        }

        
        

    }

    public void ChangeHat(float indexe)
    {
        int index = (int)indexe;
        Hats[hatIndex].SetActive(false);


        if (hairIndex == 3)
        {
            hatIndex = 0;
            if (slider is not null) slider.UpdateSlider();  //the things i need to do for mohawak clipping.. smh
        }
        else
        {
            hatIndex = index;
        }

        Hats[hatIndex].SetActive(true);
    }

    public void ChangeTeeth(float indexe)
    {
        int index = (int)indexe;
        Teeths[teethIndex].SetActive(false);
        teethIndex= index;
        Teeths[teethIndex].SetActive(true);
    }
    public void ChangeBeard(float indexe)
    {
        int index = (int)indexe;
        Beards[beardIndex].SetActive(false);
        beardIndex = index;
        Beards[beardIndex].SetActive(true);
    }
    public void ChangeNose(float indexe)
    {
        int index = (int)indexe;
        Noses[noseIndex].SetActive(false);
        noseIndex = index;
        Noses[noseIndex].SetActive(true);
    }
    public void ChangeEar(float indexe)
    {
        int index = (int)indexe;
        Ears[earIndex].SetActive(false);
        earIndex = index;
        Ears[earIndex].SetActive(true);
    }
    public void ChangePants(float indexe)
    {
        int index = (int)indexe;
        Pants[pantIndex].SetActive(false);
        pantIndex = index;
        Pants[pantIndex].SetActive(true);
    }

    public void ChangeHeight(float indexe)
    {
        this.transform.localScale = new Vector3(indexe,indexe,indexe); 
    }

    public void ChangeEyes(float indexe)
    {
        int index = (int)(indexe);
        Eyes[eyesIndex].SetActive(false);
        eyesIndex = index;
        Eyes[index].SetActive(true);
    }
    public void ChangeShirt(float indexe)
    {
        int index = (int)(indexe);
        Shirts[shirtIndex].SetActive(false);
        shirtIndex = index;
        Shirts[index].SetActive(true);
    }
    public void ChangeShoes(float indexe)
    {
        int index = (int)(indexe);
        Shoes[shoeIndex].SetActive(false);
        shoeIndex = index;
        Shoes[index].SetActive(true);
    }


    public void LoadPlayerLooks()
    {
        bodyIndex =playerLooksSO.bodyIndex;
        eyesIndex = playerLooksSO.eyesIndex;
        irisIndex = playerLooksSO.irisIndex;
        hairIndex = playerLooksSO.hairIndex;
        beardIndex = playerLooksSO.beardIndex;
        browIndex = playerLooksSO.browIndex;
        earIndex = playerLooksSO.earIndex;
        hatIndex = playerLooksSO.hatIndex;
        noseIndex = playerLooksSO.noseIndex;
        pantIndex = playerLooksSO.pantIndex;
        shirtIndex = playerLooksSO.shirtIndex;
        shoeIndex = playerLooksSO.shoeIndex;
        teethIndex = playerLooksSO.teethIndex;
        ShowCharacter();
    }
    public void SavePlayerLooks()
    {
        playerLooksSO.bodyIndex = bodyIndex;
        playerLooksSO.eyesIndex = eyesIndex;
        playerLooksSO.irisIndex = irisIndex;
        playerLooksSO.hairIndex = hairIndex;
        playerLooksSO.beardIndex = beardIndex;
        playerLooksSO.browIndex = browIndex;
        playerLooksSO.earIndex = earIndex;
        playerLooksSO.hatIndex = hatIndex;
        playerLooksSO.noseIndex = noseIndex;
        playerLooksSO.pantIndex = pantIndex;
        playerLooksSO.shirtIndex = shirtIndex;
        playerLooksSO.shoeIndex = shoeIndex;
        playerLooksSO.teethIndex = teethIndex;
        playerLooksSO.hasSaved = true;

    }

    public void ContinuePressed()
    {
        SavePlayerLooks();

        SceneManager.LoadScene(1);
    }
}
