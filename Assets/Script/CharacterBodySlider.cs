using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBodySlider : MonoBehaviour
{
    public CharacterAppeareance character;

    public Slider hair;
    public Slider beard;
    public Slider ear;
    public Slider nose;
    public Slider teeth;
    public Slider pants;
    public Slider height;
    public Slider eyes;
    public Slider shirt;
    public Slider shoe;
    public Slider hat;


    // Start is called before the first frame update
    void Start()
    {
        hair.maxValue= character.Hairs.Length-1;
        beard.maxValue= character.Beards.Length-1;
        ear.maxValue= character.Ears.Length - 1;
        nose.maxValue= character.Noses.Length - 1;
        teeth.maxValue= character.Teeths.Length - 1;
        pants.maxValue= character.Pants.Length - 1;
        eyes.maxValue=character.Eyes.Length - 1;
        shirt.maxValue = character.Shirts.Length - 1;
        shoe.maxValue = character.Shoes.Length - 1;
        hat.maxValue = character.Hats.Length - 1;
        
    }

    // Update is called once per frame
    public void SliderChange(int index)
    {
        switch (index)
        {
            case 0:
                character.ChangeHair(hair.value); break;
            case 1:
                character.ChangeBeard(beard.value); break;
            case 2:
                character.ChangeEar(ear.value); break;
            case 3:
                character.ChangeNose(nose.value); break;
            case 4:
                character.ChangeTeeth(teeth.value); break;
            case 5:
                character.ChangePants(pants.value); break;
            case 6:
                character.ChangeHeight(height.value);break;
            case 7:
                character.ChangeEyes(eyes.value); break;
            case 8:
                character.ChangeShirt(shirt.value); break;
            case 9:
                character.ChangeShoes(shoe.value); break;
            case 10:
                character.ChangeHat(hat.value); break;
            default: break;

        }
        character.PlaySound();
    }

    public void UpdateSlider()
    {
        hair.value = character.hairIndex;
        beard.value = character.beardIndex;
        ear.value = character.earIndex;
        nose.value = character.noseIndex;
        teeth.value = character.teethIndex;
        pants.value = character.pantIndex;
        eyes.value = character.eyesIndex;
        shirt.value = character.shirtIndex;
        shoe.value = character.shoeIndex;
        hat.value = character.hatIndex;
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
