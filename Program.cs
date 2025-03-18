using System;
using System.Text.Json;

namespace SerializeWays
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"todos.json";
            List<Todo> todos = new();
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                todos = JsonSerializer.Deserialize<List<Todo>>(json) ?? new List<Todo>();
                System.Console.WriteLine("Tanlang: ");
                System.Console.WriteLine("1 . Todolarni chiqarish");
                System.Console.WriteLine("2 . Yangi todo qo'shish");
                System.Console.WriteLine("3 . Todolarni o'zgartirish");
                System.Console.WriteLine("4 . Todolarni o'chirish");
                System.Console.WriteLine("5 . Title bo'yicha qidirish");

                int choice = int.Parse(Console.ReadLine()!);
                if (choice > 0)
                {
                    switch (choice)
                    {
                        case 1:
                            GetUsersTodo(todos);
                            break;
                        case 2:
                            AddNewTodo(todos, path);
                            break;
                        case 3:
                            EditTodo(todos);
                            break;
                        case 4:
                            DelateTodo(todos,path);
                            break;
                        case 5:
                            SearchTodo(todos);
                            break;
                           
                    }
                }
            }



        }

        static void GetUsersTodo(List<Todo> todos)
        {
            System.Console.Write("Userning ID sini kiriting: ");
            int userId = int.Parse(Console.ReadLine()!);

            System.Console.WriteLine("Bajarilgan Todolar");
            foreach (var todo in todos)
            {
                if (todo.UserID == userId && todo.Completed)
                {
                    System.Console.WriteLine($" - {todo.Title}");
                }

            }

            System.Console.WriteLine("Bajarilmagan Todolar");
            foreach (var todo in todos)
            {
                if (todo.UserID == userId && !todo.Completed)
                {
                    System.Console.WriteLine($" - {todo.Title}");
                }

            }
        }

        static void AddNewTodo(List<Todo> todos, string path)
        {
            System.Console.Write("User ID sini kiriting : ");
            int userId = int.Parse(Console.ReadLine()!);
            System.Console.Write("Taskni Kiriting: ");
            string newTitle = Console.ReadLine()!;
            int newId = 1;

            if (todos.Count > 0)
            {
                newId = todos[todos.Count - 1].Id + 1;
            }

            Todo newTodo = new Todo
            {
                UserID = userId,
                Id = newId,
                Title = newTitle,
                Completed = false
            };

            todos.Add(newTodo);
            File.WriteAllText(path, JsonSerializer.Serialize(todos, new JsonSerializerOptions { WriteIndented = true }));
        }

        static void EditTodo(List<Todo> todos)
        {

        }

        static void DelateTodo(List<Todo> todos , string path)
        {
            System.Console.Write("User Id sini kiriting: ");
            int deleteID = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < todos.Count; i++)
            {
                if (todos[i].Id == deleteID)
                {
                    todos.RemoveAt(i);
                    break;
                }
            }

            File.WriteAllText(path, JsonSerializer.Serialize(todos, new JsonSerializerOptions { WriteIndented = true }));
        }

        static void SearchTodo(List<Todo> todos)
        {
            System.Console.Write("Todo nomini kiriting: ");

            string searchTitle = Console.ReadLine()!.ToLower();
            List<Todo> searchResult = new List<Todo>();
            foreach(var todo in todos)
            {
                if(todo.Title.ToLower().Contains(searchTitle))
                {
                    searchResult.Add(todo);
                }
            }

            foreach(var todo in searchResult)
            {
                System.Console.WriteLine(todo.Title);
            }

        }

    }
}
