using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Manages the questions for the maths puzzle.
/// </summary>
public class QuestionsManager : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI display;

    /// <summary>
    /// Number of questions to complete before the lift
    /// button code is revealed
    /// </summary>
    [SerializeField]
    private int noQuestions = 3;

    /// <summary>
    /// Current question number.
    /// </summary>
    private int currQuestion = 1;

    /// <summary>
    /// Stores the resultant button code
    /// </summary>
    private int buttonCode = 0;

    /// <summary>
    /// List of questions to be answered. These will be used for 
    /// text display.
    /// </summary>
    private List<string> questions;

    /// <summary>
    /// List of question answers. Attempts to complete the puzzle
    /// will be compared against this.
    /// </summary>
    private List<int> answers;

    private void Start()
    {
        // Make sure the text display is populated
        if (!display)
        {
            Debug.Log("Questions text is not assigned.");
            Destroy(this);
        }

        questions = new List<string>();
        answers = new List<int>();

        for (int i = 0; i < noQuestions; i++)
        {
            int val1 = Random.Range(30, 99);
            int val2 = Random.Range(1, 29);
            string op = "";
            int answer = 0;

            if (Random.Range(1, 10) < 5)
            {
                op = "+";
                answer = val1 + val2;
            }
            else
            {
                op = "-";
                answer = val1 - val2;
            }

            questions.Add(val1.ToString() + " " + op + " " + val2.ToString());
            answers.Add(answer);
            buttonCode += answer;
        }

        buttonCode = (int)Mathf.Ceil(buttonCode / 4);
        UpdateQuestionDisplay();
    }

    /// <summary>
    /// Updates the question display text question strings and
    /// strikeouts already complete questions.
    /// </summary>
    private void UpdateQuestionDisplay()
    {
        display.text = "Current tasks:";
        for (int i = 0; i < noQuestions; i++)
        {
            if (i < currQuestion - 1) display.text += "\n<s>" + questions[i] + "</s>";
            else display.text += "\n" + questions[i];
        }
    }

    /// <summary>
    /// Displays the button code.
    /// </summary>
    private void DisplayButtonCode()
    {
        display.text = "Button code:\n" + buttonCode.ToString();
    }

    /// <summary>
    /// Returns the button code to be entered in the lift.
    /// </summary>
    /// <returns>int</returns>
    public int GetButtonCode() { return buttonCode; }

    /// <summary>
    /// Returns the wanted question. 
    /// </summary>
    /// <param name="i">Questions list element index</param>
    /// <returns></returns>
    public string GetQuestion(int i) { return questions[i]; }

    /// <summary>
    /// Checks if a given answer value is correct for the current
    /// question.
    /// </summary>
    /// <param name="answer">Answer to check</param>
    /// <returns></returns>
    public bool CheckResult(int answer)
    {
        if (answers[currQuestion - 1] == answer)
        {
            currQuestion++;
            if (currQuestion <= noQuestions) UpdateQuestionDisplay();
            else DisplayButtonCode();
            return true;
        }
        return false;
    }
}
