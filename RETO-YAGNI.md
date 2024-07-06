> Los animo hacer este ejercicio para que practique, donde van encontrar una historia de usuario y un código que lo resuelve la idea es refactorizar aplicando el principio **YAGNI**

[ :tv: Videos de CleanCode](https://www.youtube.com/watch?v=PGtzp_9IFb8&list=PLjU2Ord0op_MRkbfS2wc69N1G1_QAOIbW)  

# Historia de Usuario: Gestión Básica de Tareas
**Título:** Como usuario, quiero poder gestionar mis tareas para mantenerme organizado.

## Descripción:
Como usuario,
Quiero poder crear, leer, actualizar y eliminar tareas,
Para que pueda gestionar mis pendientes y mantenerme organizado.

## Criterios de Aceptación:

- Crear Tareas:

Dado que tengo una lista de tareas,
Cuando añado una nueva tarea con un título y una descripción,
Entonces la tarea debe aparecer en la lista de tareas.

- Leer Tareas:

Dado que tengo una lista de tareas,
Cuando solicito ver todas las tareas,
Entonces el sistema debe mostrar todas las tareas en la lista.

- Actualizar Tareas:

Dado que tengo una tarea existente,
Cuando actualizo el título o la descripción de la tarea,
Entonces la tarea debe reflejar los cambios realizados.

- Eliminar Tareas:

Dado que tengo una tarea existente,
Cuando elimino una tarea de la lista,
Entonces la tarea debe ser removida de la lista.

# Código del reto

```csharp
using System;
using System.Collections.Generic;

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> Tags { get; set; }
    public DateTime? Reminder { get; set; }

    public Task(int id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
        Tags = new List<string>();
    }

    public override string ToString()
    {
        string tags = Tags.Count > 0 ? string.Join(", ", Tags) : "No Tags";
        string reminder = Reminder.HasValue ? Reminder.Value.ToString("g") : "No Reminder";
        return $"Id: {Id}, Title: {Title}, Description: {Description}, Tags: {tags}, Reminder: {reminder}";
    }
}

public class TaskManager
{
    private List<Task> tasks = new List<Task>();
    private int nextId = 1;

    // Create
    public void AddTask(string title, string description)
    {
        var task = new Task(nextId++, title, description);
        tasks.Add(task);
    }

    // Read
    public Task GetTask(int id)
    {
        return tasks.Find(t => t.Id == id);
    }

    public List<Task> GetAllTasks()
    {
        return tasks;
    }

    // Update
    public bool UpdateTask(int id, string newTitle, string newDescription)
    {
        var task = GetTask(id);
        if (task != null)
        {
            task.Title = newTitle;
            task.Description = newDescription;
            return true;
        }
        return false;
    }

    // Add Tag
    public bool AddTagToTask(int id, string tag)
    {
        var task = GetTask(id);
        if (task != null)
        {
            task.Tags.Add(tag);
            return true;
        }
        return false;
    }

    // Set Reminder
    public bool SetReminderForTask(int id, DateTime reminder)
    {
        var task = GetTask(id);
        if (task != null)
        {
            task.Reminder = reminder;
            return true;
        }
        return false;
    }

    // Print all tasks
    public void PrintTasks()
    {
        foreach (var task in tasks)
        {
            Console.WriteLine(task);
        }
    }
}

public class Program
{
    public static void Main()
    {
        TaskManager taskManager = new TaskManager();
        
        // Create
        taskManager.AddTask("Buy groceries", "Milk, Bread, Cheese");
        taskManager.AddTask("Finish report", "Complete the financial report for Q2");

        // Add tags
        taskManager.AddTagToTask(1, "Shopping");
        taskManager.AddTagToTask(2, "Work");

        // Set reminders
        taskManager.SetReminderForTask(1, new DateTime(2024, 7, 10, 9, 0, 0));
        taskManager.SetReminderForTask(2, new DateTime(2024, 7, 15, 15, 0, 0));

        // Read
        Console.WriteLine("All tasks:");
        taskManager.PrintTasks();
        
        // Update
        Console.WriteLine("\nUpdating task 1...");
        taskManager.UpdateTask(1, "Buy groceries and snacks", "Milk, Bread, Cheese, Snacks");

        // Read updated task
        Console.WriteLine("\nTask 1 after update:");
        Console.WriteLine(taskManager.GetTask(1));

        // Read all tasks after deletion
        Console.WriteLine("\nAll tasks after deletion:");
        taskManager.PrintTasks();
    }
}
```
