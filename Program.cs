using System;
using System.Collections.Generic;
using System.IO;
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
                            EditTodo(todos, path);
                            break;
                        case 4:
                            DeleteTodo(todos, path);
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
            int newId = todos.Count > 0 ? todos[todos.Count - 1].Id + 1 : 1;

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

        static void EditTodo(List<Todo> todos, string path)
        {
            System.Console.Write("O'zgartirmoqchi bo'lgan todo ID sini kiriting: ");
            int editID = int.Parse(Console.ReadLine()!);

            Todo? todoToEdit = todos.Find(todo => todo.Id == editID);

            if (todoToEdit != null)
            {
                System.Console.WriteLine($"Eski sarlavha: {todoToEdit.Title}");
                System.Console.Write("Yangi sarlavhani kiriting: ");
                string newTitle = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(newTitle))
                {
                    todoToEdit.Title = newTitle;
                }

                System.Console.Write($"Hozirgi holati: {(todoToEdit.Completed ? "Bajarilgan" : "Bajarilmagan")}. Holatini almashtirishni xohlaysizmi? (ha/yo'q): ");
                string changeStatus = Console.ReadLine()!.ToLower();
                if (changeStatus == "ha")
                {
                    todoToEdit.Completed = !todoToEdit.Completed;
                }

                File.WriteAllText(path, JsonSerializer.Serialize(todos, new JsonSerializerOptions { WriteIndented = true }));
                System.Console.WriteLine("Todo o'zgartirildi");
            }
            else
            {
                System.Console.WriteLine("Todo topilmadi!");
            }
        }

        static void DeleteTodo(List<Todo> todos, string path)
        {
            System.Console.Write("O'chirmoqchi bo'lgan todo ID sini kiriting: ");
            int deleteID = int.Parse(Console.ReadLine()!);

            Todo? todoToRemove = todos.Find(todo => todo.Id == deleteID);

            if (todoToRemove != null)
            {
                todos.Remove(todoToRemove);
                File.WriteAllText(path, JsonSerializer.Serialize(todos, new JsonSerializerOptions { WriteIndented = true }));
                System.Console.WriteLine("Todo muvaffaqiyatli o'chirildi!");
            }
            else
            {
                System.Console.WriteLine("Todo topilmadi!");
            }
        }

        static void SearchTodo(List<Todo> todos)
        {
            System.Console.Write("Todo nomini kiriting: ");
            string searchTitle = Console.ReadLine()!.ToLower();

            var searchResults = todos.FindAll(todo => todo.Title.ToLower().Contains(searchTitle));

            if (searchResults.Count > 0)
            {
                System.Console.WriteLine("Natijalar:");
                foreach (var todo in searchResults)
                {
                    System.Console.WriteLine($" - {todo.Title}");
                }
            }
            else
            {
                System.Console.WriteLine("Hech narsa topilmadi.");
            }
        }
    }

}
