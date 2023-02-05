using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{

    [Header("Tutorial Text")]
    public TextMeshProUGUI introText;
    public TextMeshProUGUI rootieControls;
    public TextMeshProUGUI twootieControls;
    public TextMeshProUGUI bothControls;
    public TextMeshProUGUI visualCuesTitle;
    public TextMeshProUGUI visualCuesIncDec;
    public TextMeshProUGUI visualCuesGlow;
    public TextMeshProUGUI objective;
    public TextMeshProUGUI skip;

    public int tutorialStage = 0;

    private void Start()
    {
        introText.gameObject.SetActive(true);
        rootieControls.gameObject.SetActive(false);
        twootieControls.gameObject.SetActive(false);
        bothControls.gameObject.SetActive(false);
        visualCuesTitle.gameObject.SetActive(false);
        visualCuesIncDec.gameObject.SetActive(false);
        visualCuesGlow.gameObject.SetActive(false);
        objective.gameObject.SetActive(false);
        skip.gameObject.SetActive(false);
    }

    public void Sequence()
    {
        if (tutorialStage == 1)
            IntroDone();
        else if (tutorialStage == 2)
            ControlsDone();
        else if (tutorialStage == 3)
            VisualCuesIncDecDone();
        else if (tutorialStage == 4)
            VisualCuesGlowDone();
        else if (tutorialStage == 5)
            TutorialDone();
    }



    private void IntroDone()
    {
        introText.gameObject.SetActive(false);
        rootieControls.gameObject.SetActive(true);
        twootieControls.gameObject.SetActive(true);
        bothControls.gameObject.SetActive(true);
        skip.gameObject.SetActive(true);
    }

    private void ControlsDone()
    {
        rootieControls.gameObject.SetActive(false);
        twootieControls.gameObject.SetActive(false);
        bothControls.gameObject.SetActive(false);
        visualCuesTitle.gameObject.SetActive(true);
        visualCuesIncDec.gameObject.SetActive(true);

    }

    private void VisualCuesIncDecDone()
    {
        visualCuesIncDec.gameObject.SetActive(false);
        visualCuesGlow.gameObject.SetActive(true);
    }

    private void VisualCuesGlowDone()
    {
        visualCuesTitle.gameObject.SetActive(false);
        visualCuesGlow.gameObject.SetActive(false);
        objective.gameObject.SetActive(true);
    }

    private void TutorialDone()
    {
        introText.gameObject.SetActive(false);
        rootieControls.gameObject.SetActive(false);
        twootieControls.gameObject.SetActive(false);
        bothControls.gameObject.SetActive(false);
        visualCuesTitle.gameObject.SetActive(false);
        visualCuesIncDec.gameObject.SetActive(false);
        visualCuesGlow.gameObject.SetActive(false);
        objective.gameObject.SetActive(false);
        skip.gameObject.SetActive(false);

        tutorialStage = 100; // end
    }


}
