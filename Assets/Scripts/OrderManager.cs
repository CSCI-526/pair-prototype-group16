using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Order
{
    public int circles; // num of circles
    public int squares; // num of squares

    public Order(int circles, int squares)
    {
        this.circles = circles;
        this.squares = squares;
    }

    public override string ToString()
    {
        return $"{circles} Circles, {squares} Squares";
    }
}

public class OrderManager : MonoBehaviour
{
    public Order[] orders; // all availble orders
    [SerializeField] private TMP_Text orderDisplay; // displayed order
    public Button[] orderButtons; // choose button
    public GameObject[] circles; // num of circles
    public GameObject[] squares; // num of squares
    public Button completeButton; // complete button
                                  
    public GameObject circlePrefab; 
    public GameObject squarePrefab; 
    private Order currentOrder; // current order
    private int currentCircles = 0; // num of circles
    private int currentSquares = 0; // num of squares

    private void Start()
    {
        // initialize
        orders = new Order[]
        {
            new Order(3, 2), // order 1: 3 circles, 2 squares
            new Order(3, 1)  // order 2: 3 circles, 1 squares
        };

        SelectOrder(0);
        // add click listeners
        for (int i = 0; i < orderButtons.Length; i++)
        {
            int index = i; // get index
            orderButtons[i].onClick.AddListener(() => SelectOrder(index));
        }

        // add listener for the complete button
        completeButton.onClick.AddListener(CheckOrderCompletion);
    }


    public void SelectOrder(int index)
    {
        if (index >= 0 && index < orders.Length)
        {
            currentOrder = orders[index];
            UpdateOrderDisplay();
        }
    }

    private void UpdateOrderDisplay()
    {
        if (orderDisplay != null)
        {
            orderDisplay.text = currentOrder.ToString();
        }
        else
        {
            Debug.LogError("orderDisplay not set");
        }
    }

    private void CountShapes()
    {
        currentCircles = 0;
        currentSquares = 0;

        
        GameObject[] activeCircles = GameObject.FindGameObjectsWithTag("Circle");
        currentCircles = activeCircles.Length; 

        
        GameObject[] activeSquares = GameObject.FindGameObjectsWithTag("Square");
        currentSquares = activeSquares.Length; 

        Debug.Log($"current circle number: {currentCircles}, current square number: {currentSquares}"); 
    }

    private void CheckOrderCompletion()
    {
        CountShapes(); // Count shapes when checking completion

        if (currentCircles == currentOrder.circles && currentSquares == currentOrder.squares)
        {
            Debug.Log("Complete order！");

        }
        else
        {
            Debug.Log("Not complete,plz try again!");
        }
    }
}