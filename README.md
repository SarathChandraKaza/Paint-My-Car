# **Paint My Car**  
A gamified Unity project demonstrating the **Command Pattern** through a car painting system.  

---

## **What is the Command Pattern?**  
The **Command Pattern** is a **behavioral design pattern** that:  
- Encapsulates **requests as objects**.  
- Allows **queuing, logging, and undoing** actions.  
- Promotes **loose coupling** between sender and receiver.  

---

## **How This Project Implements It**
| Component        | Role |
|-----------------|------|
| **GameManager** | **Handles user input** and interacts with the Command Invoker. |
| **CommandInvoker** | **Stores and executes** commands, allowing undo functionality. |
| **ICommand** | Defines the structure for commands with `Execute()` and `Undo()`. |
| **BodyColourChanger** & **BonnetColourChanger** | **Commands** that modify car parts' colors. |

---

## **How It Works**
![Paint My Car](https://github.com/user-attachments/assets/f410acb1-168e-40dc-9af6-3838e8147aba)


### **1️⃣ User Presses a Button**  
The **player** interacts with **UI buttons** to change the car’s **body or bonnet color**.  

```csharp
private void UpdateBodyColour()
{
    commandInvoker.ExecuteCommand(bodyChanger);
}

private void UpdateBonnetColour()
{
    commandInvoker.ExecuteCommand(bonnetChanger);
}
```

---

### **2️⃣ Command Execution**  
Each button press **creates a command** that changes the color of the respective car part.  

```csharp
public class BodyColourChanger : MonoBehaviour, ICommand
{
    [SerializeField] Material bodyMaterial;
    [SerializeField] Color initialColour;
    [SerializeField] Color newColour;

    public void Execute()
    {
        Debug.Log("Changing body color to new color");
        bodyMaterial.color = newColour;
    }

    public void Undo()
    {
        Debug.Log("Reverting body color to initial color");
        bodyMaterial.color = initialColour;
    }
}
```

---

### **3️⃣ Undo System**  
The **CommandInvoker** maintains a **stack** of executed commands, allowing **undo functionality**.  

```csharp
public void UndoCommand()
{
    if(commandsStack.Count > 0)
    {
        var lastCommand = commandsStack.Pop();
        lastCommand.Undo();
    }
    else
    {
        Debug.LogError("No commands to undo");
    }
}
```

---

## **🛠Project Structure**
### **1️⃣ ICommand (Interface)**
Defines the contract for all **commands** (Execute & Undo).  

```csharp
public interface ICommand
{
    void Execute();
    void Undo();
}
```

---

### **2️⃣ CommandInvoker (Command Manager)**
- Stores **executed commands** in a **stack**.  
- Provides **undo functionality**.  

```csharp
public class CommandInvoker : MonoBehaviour
{
    private Stack<ICommand> commandsStack = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        commandsStack.Push(command);
    }

    public void UndoCommand()
    {
        if(commandsStack.Count > 0)
        {
            var lastCommand = commandsStack.Pop();
            lastCommand.Undo();
        }
        else
        {
            Debug.LogError("Stack is empty");
        }
    }
}
```

---

### **3️⃣ GameManager (User Input Handler)**
- Listens for **button presses** and **triggers commands**.  

```csharp
public class GameManager : MonoBehaviour
{
    [SerializeField] CommandInvoker commandInvoker;
    [SerializeField] Button changeBonnetColour;
    [SerializeField] Button changeBodyColour;
    [SerializeField] Button undoButton;

    [SerializeField] BodyColourChanger bodyChanger;
    [SerializeField] BonnetColourChanger bonnetChanger;

    private void Start()
    {
        changeBonnetColour.onClick.AddListener(UpdateBonnetColour);
        changeBodyColour.onClick.AddListener(UpdateBodyColour);
        undoButton.onClick.AddListener(UndoButtonPressed);
    }

    private void UndoButtonPressed()
    {
        commandInvoker.UndoCommand();
    }
}
```

---

### **4️⃣ Bonnet & Body Colour Changers (Commands)**
Each **command** encapsulates an action and its **undo counterpart**.  

```csharp
public class BonnetColourChanger : MonoBehaviour, ICommand
{
    [SerializeField] Material bonnetMaterial;
    [SerializeField] Color initialColour;
    [SerializeField] Color newColour;

    public void Execute()
    {
        Debug.Log("Changing bonnet color to new color");
        bonnetMaterial.color = newColour;
    }

    public void Undo()
    {
        Debug.Log("Reverting bonnet color to initial color");
        bonnetMaterial.color = initialColour;
    }
}
```

---

## **Code Flow**
### **1️⃣ User Clicks a Button**
The GameManager **triggers a command** via the **CommandInvoker**.  

### **2️⃣ Command Executes**
The **CommandInvoker** executes the **BodyColourChanger** or **BonnetColourChanger** command.  

### **3️⃣ Undo Functionality**
The **CommandInvoker** allows **undoing** the last color change.  

---

## **Need Help?**
If you have any **questions**, feel free to **open an issue**. 🚀
