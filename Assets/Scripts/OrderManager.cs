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
    public Order currentOrder; // current order
    public int currentCircles = 0; // num of circles
    public int currentSquares = 0; // num of squares
    public bool isCleared = false;

    public void Start()
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

    public void UpdateOrderDisplay()
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

    public void CountShapes()
    {
        currentCircles = 0;
        currentSquares = 0;


        GameObject[] activeCircles = GameObject.FindGameObjectsWithTag("Circle");
        currentCircles = activeCircles.Length;


        GameObject[] activeSquares = GameObject.FindGameObjectsWithTag("Square");
        currentSquares = activeSquares.Length;

        Debug.Log($"current circle number: {currentCircles}, current square number: {currentSquares}");
    }

    public void CheckOrderCompletion()
{
    CountShapes(); // Count shapes when checking completion

    if (currentCircles == currentOrder.circles && currentSquares == currentOrder.squares)
    {
        Debug.Log("Complete order！");
        RemoveShapes(currentOrder.circles, currentOrder.squares);
        HideCompletedOrderButton(currentOrder);
        SelectNextOrder();
        isCleared = true;

        // Disable the button for the current order
        DisableOrderButton();
    }
    else
    {
        Debug.Log("Not complete, please try again!");
    }
}

public void DisableOrderButton()
{
    // Find the index of the current order
    for (int i = 0; i < orders.Length; i++)
    {
        if (orders[i] == currentOrder)
        {
            // Disable the button for the completed order
            orderButtons[i].interactable = false;
            break;
        }
    }
}

    public void RemoveShapes(int circlesToRemove, int squaresToRemove)
    {

        GameObject[] activeCircles = GameObject.FindGameObjectsWithTag("Circle");
        for (int i = 0; i < circlesToRemove && i < activeCircles.Length; i++)
        {
            Destroy(activeCircles[i]); //  delete obj
        }

        GameObject[] activeSquares = GameObject.FindGameObjectsWithTag("Square");
        for (int i = 0; i < squaresToRemove && i < activeSquares.Length; i++)
        {
            Destroy(activeSquares[i]); // delete obj
        }

    }

private void HideCompletedOrderButton(Order currentOrder)
    {
        for (int i = 0; i < orders.Length; i++)
        {
            if (orders[i].circles == currentOrder.circles && orders[i].squares == currentOrder.squares)
            {
                orderButtons[i].gameObject.SetActive(false); 


                if (orderDisplay != null)
                {
                    orderDisplay.text = ""; 
                }
                break;
            }
        }
    }
    private void SelectNextOrder()
    {
        for (int i = 0; i < orders.Length; i++)
        {

            if (orderButtons[i].gameObject.activeSelf) 
            {
                SelectOrder(i); 
                orderButtons[i].onClick.Invoke(); 
                break; 
            }
        }
    }

}