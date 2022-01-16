using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/// <summary>
/// Manages the operation of the calculator
/// </summary>
public class CalculatorManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI display;
    [SerializeField]
    private Button btnNo9;
    [SerializeField]
    private Button btnNo8;
    [SerializeField]
    private Button btnNo7;
    [SerializeField]
    private Button btnNo6;
    [SerializeField]
    private Button btnNo5;
    [SerializeField]
    private Button btnNo4;
    [SerializeField]
    private Button btnNo3;
    [SerializeField]
    private Button btnNo2;
    [SerializeField]
    private Button btnNo1;
    [SerializeField]
    private Button btnNo0;
    [SerializeField]
    private Button btnPlus;
    [SerializeField]
    private Button btnMinus;
    [SerializeField]
    private Button btnEquals;

    private int firstVal = 0;
    private string selectedOp = "";

    private void Start()
    {
        // Make sure all possible buttons are populated
        if (!btnNo9 || !btnNo8 || !btnNo7 || !btnNo6 || !btnNo5 || !btnNo4 || !btnNo3 || !btnNo2 || !btnNo1 || !btnPlus || !btnMinus || !btnEquals)
        {
            Debug.Log("One or more calculator buttons not assigned.");
            Destroy(this);
        }

        // Make sure the text display is populated
        if (!display)
        {
            Debug.Log("Calculator display is not assigned.");
            Destroy(this);
        }

        // Add on-click listeners to all buttons to call their
        // appropriate functions
        btnNo0.onClick.AddListener(() => { PressNumButton(0); });
        btnNo1.onClick.AddListener(() => { PressNumButton(1); });
        btnNo2.onClick.AddListener(() => { PressNumButton(2); });
        btnNo3.onClick.AddListener(() => { PressNumButton(3); });
        btnNo4.onClick.AddListener(() => { PressNumButton(4); });
        btnNo5.onClick.AddListener(() => { PressNumButton(5); });
        btnNo6.onClick.AddListener(() => { PressNumButton(6); });
        btnNo7.onClick.AddListener(() => { PressNumButton(7); });
        btnNo8.onClick.AddListener(() => { PressNumButton(8); });
        btnNo9.onClick.AddListener(() => { PressNumButton(9); });
        btnPlus.onClick.AddListener(() => { PressOperatorButton("+"); });
        btnMinus.onClick.AddListener(() => { PressOperatorButton("-"); });
        btnEquals.onClick.AddListener(() => { PressOperatorButton("="); });
    }

    /// <summary>
    /// Handles a key press from a calculator numerical button.
    /// </summary>
    /// <param name="btn">Button value</param>
    private void PressNumButton(int btn)
    {
        Debug.Log(btn);
        if (display.text == "0") display.text = btn.ToString();
        else display.text += btn.ToString();
    }

    /// <summary>
    /// Handles a key press from an calculator operator button.
    /// </summary>
    /// <param name="op">Operator symbol</param>
    private void PressOperatorButton(string op)
    {
        Debug.Log(op);
        if (op == "=")
        {
            int curVal = Int32.Parse(display.text);
            int result = 0;
            if (selectedOp == "+") result = firstVal + curVal;
            else if (selectedOp == "-") result = firstVal - curVal;
            display.text = result.ToString();
        }
        else
        {
            firstVal = Int32.Parse(display.text);
            display.text = "0";
            selectedOp = op;
        }
    }
}
