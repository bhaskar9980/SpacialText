using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    [SerializeField] private GameObject FocusedGameObject;
    [SerializeField] private TextMeshPro FocusedGameObjectTMP;
    [SerializeField] private Material FocusedGameObjectBaseMaterial;
    private Material FocusedGameObjectHighlightMaterial;
    private bool isOutlineSet = false;
    public TouchScreenKeyboard keyboard;
    private string keyboardText;

    private Color color = new(1, 1, 1, 1);

    public void assignCurrentTextObject(GameObject gameObject)
    {
        FocusedGameObject = gameObject;
        FocusedGameObjectTMP = gameObject.GetComponent<TextMeshPro>();
        FocusedGameObjectBaseMaterial = FocusedGameObjectTMP.fontSharedMaterial;
        FocusedGameObjectHighlightMaterial = new Material(FocusedGameObjectBaseMaterial);
        FocusedGameObjectHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 1.0f);
    }

    public void ChangeFont(TMP_FontAsset asset)
    {
        FocusedGameObjectTMP.font = asset;
        FocusedGameObjectTMP.UpdateFontAsset();
        FocusedGameObjectBaseMaterial = FocusedGameObjectTMP.fontSharedMaterial;
        FocusedGameObjectHighlightMaterial = new Material(FocusedGameObjectBaseMaterial);
        FocusedGameObjectHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 1.0f);

        if (isOutlineSet)
        {
            color.a = 0f;
            string[] keywords = { "GLOW_ON" };
            FocusedGameObjectHighlightMaterial.shaderKeywords = keywords;
            FocusedGameObjectHighlightMaterial.SetColor(ShaderUtilities.ID_FaceColor, color);
            FocusedGameObjectHighlightMaterial.SetColor(ShaderUtilities.ID_GlowColor, new Color32(191, 0, 113, 180));
            FocusedGameObjectHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowInner, 0.09f);
            FocusedGameObjectHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowOuter, 0.12f);
            FocusedGameObjectTMP.fontSharedMaterial = FocusedGameObjectHighlightMaterial;
        }
    }

    public void OpenSystemKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
    }

    private void Update()
    {
        if (keyboard != null)
        {
            keyboardText = keyboard.text;
            FocusedGameObjectTMP.text = keyboardText;
        }
    }

    public void DuplicateText()
    {
        Instantiate(FocusedGameObject, FocusedGameObject.transform.position, Quaternion.identity);
    }

    public void DeleteText()
    {
        Destroy(FocusedGameObject);
    }

    public void UpdateRedColor(SliderEventData eventData)
    {
        color.r = eventData.NewValue;
        if (!isOutlineSet)
            FocusedGameObjectTMP.color = color;
        else
        {
            color.a = 0.5f;
            FocusedGameObjectTMP.fontSharedMaterial.SetColor(ShaderUtilities.ID_GlowColor, color);
            FocusedGameObjectHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowInner, 0.09f);
            FocusedGameObjectHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowOuter, 0.12f);
        }
    }

    public void UpdateGreenColor(SliderEventData eventData)
    {
        color.g = eventData.NewValue;
        if (!isOutlineSet)
            FocusedGameObjectTMP.color = color;
        else
        {
            color.a = 0.5f;
            FocusedGameObjectTMP.fontSharedMaterial.SetColor(ShaderUtilities.ID_GlowColor, color);
            FocusedGameObjectHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowInner, 0.09f);
            FocusedGameObjectHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowOuter, 0.12f);
        }
    }

    public void UpdateBlueColor(SliderEventData eventData)
    {
        color.b = eventData.NewValue;
        if (!isOutlineSet)
            FocusedGameObjectTMP.color = color;
        else
        {
            color.a = 0.5f;
            FocusedGameObjectTMP.fontSharedMaterial.SetColor(ShaderUtilities.ID_GlowColor, color);
            FocusedGameObjectHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowInner, 0.09f);
            FocusedGameObjectHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowOuter, 0.12f);
        }
    }

    public void ChangeTextOutline()
    {
        if (!isOutlineSet)
        {
            color.a = 0f;
            string[] keywords = { "GLOW_ON" };
            FocusedGameObjectHighlightMaterial.shaderKeywords = keywords;
            FocusedGameObjectHighlightMaterial.SetColor(ShaderUtilities.ID_FaceColor, color);
            FocusedGameObjectHighlightMaterial.SetColor(ShaderUtilities.ID_GlowColor, new Color32(191, 0, 113, 180));
            FocusedGameObjectHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowInner, 0.09f);
            FocusedGameObjectHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowOuter, 0.12f);
            FocusedGameObjectTMP.fontSharedMaterial = FocusedGameObjectHighlightMaterial;
        }
        else
        {
            color.a = 1f;
            FocusedGameObjectTMP.fontSharedMaterial = FocusedGameObjectBaseMaterial;
        }
        FocusedGameObjectTMP.UpdateMeshPadding();
        isOutlineSet = !isOutlineSet;
    }
}