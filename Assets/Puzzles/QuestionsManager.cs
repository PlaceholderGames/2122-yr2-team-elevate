using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the questions for the maths puzzle.
/// </summary>
public class QuestionsManager : MonoBehaviour
{
    /// <summary>
    /// Number of puzzles to complete before the lift
    /// button code is revealed
    /// </summary>
    [SerializeField]
    private int noPuzzles = 3;

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
        questions = new List<string>();
        answers = new List<int>();

        for (int i = 0; i < noPuzzles; i++)
        {
            int val1 = Random.Range(25, 50);
            int val2 = Random.Range(1, 25);
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
    /// Checks if a given answer value is correct for a given
    /// question.
    /// </summary>
    /// <param name="i">Answers list element index</param>
    /// <param name="answer">Answer to check</param>
    /// <returns></returns>
    public bool CheckResult(int i, int answer)
    {
        if (answers[i] == answer) return true;
        return false;
    }
}
