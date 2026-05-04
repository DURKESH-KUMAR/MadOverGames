using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour
{
    [Header("Screens")]
    public List<GameObject> screens;

    [Header("UI")]
    public Text titleText;

    [Header("Animation")]
    public float fadeDuration = 0.3f;

    private int currentIndex = 2; // Default = Home
    private bool isTransitioning = false;

    void Start()
    {
        InitializeScreens();
        UpdateTitle(currentIndex);
    }

    // Initialize all screens properly
    void InitializeScreens()
    {
        for (int i = 0; i < screens.Count; i++)
        {
            CanvasGroup cg = screens[i].GetComponent<CanvasGroup>();

            if (i == currentIndex)
            {
                screens[i].SetActive(true);
                cg.alpha = 1f;
                cg.interactable = true;
                cg.blocksRaycasts = true;
            }
            else
            {
                screens[i].SetActive(false);
                cg.alpha = 0f;
                cg.interactable = false;
                cg.blocksRaycasts = false;
            }
        }
    }

    // Button Click Entry
    public void OnButtonClick(int index)
    {
        if (isTransitioning || index == currentIndex)
            return;

        StartCoroutine(SwitchScreen(index));
    }

    // Screen Transition
    IEnumerator SwitchScreen(int newIndex)
    {
        isTransitioning = true;

        GameObject currentScreen = screens[currentIndex];
        GameObject nextScreen = screens[newIndex];

        CanvasGroup currentCG = currentScreen.GetComponent<CanvasGroup>();
        CanvasGroup nextCG = nextScreen.GetComponent<CanvasGroup>();

        // Fade OUT current
        yield return StartCoroutine(Fade(currentCG, 1f, 0f));

        currentScreen.SetActive(false);
        currentCG.interactable = false;
        currentCG.blocksRaycasts = false;

        // Activate next
        nextScreen.SetActive(true);
        nextCG.interactable = true;
        nextCG.blocksRaycasts = true;

        // Fade IN next
        yield return StartCoroutine(Fade(nextCG, 0f, 1f));

        currentIndex = newIndex;
        UpdateTitle(newIndex);

        isTransitioning = false;
    }

    // Fade Function
    IEnumerator Fade(CanvasGroup cg, float start, float end)
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            cg.alpha = Mathf.Lerp(start, end, time / fadeDuration);
            yield return null;
        }

        cg.alpha = end;
    }

    // Title Update
    void UpdateTitle(int index)
    {
        switch (index)
        {
            case 0: titleText.text = "Store"; break;
            case 1: titleText.text = "Star"; break;
            case 2: titleText.text = "Home"; break;
            case 3: titleText.text = "Group"; break;
            case 4: titleText.text = "Settings"; break;
        }
    }
}