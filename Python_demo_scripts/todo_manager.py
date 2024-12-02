import os

TODO_FILE = "todo_list.txt"

# Load tasks file 
def load_tasks():
    if not os.path.exists(TODO_FILE):
        return []
    with open(TODO_FILE, "r") as file:
        tasks = [line.strip() for line in file.readlines()]
    return tasks

# Save tasks as file
def save_tasks(tasks):
    with open(TODO_FILE, "w") as file:
        for task in tasks:
            file.write(task + "\n")

# Show all task
def view_tasks(tasks):
    if not tasks:
        print("\nIngen opgaver endnu!")
    else:
        print("\nDine opgaver:")
        for idx, task in enumerate(tasks, start=1):
            print(f"{idx}. {task}")

# Create task
def add_task(tasks):
    task = input("Indtast en ny opgave: ").strip()
    if task:
        tasks.append(task)
        print(f"Opgave '{task}' er tilføjet!")

# Remove Task
def remove_task(tasks):
    view_tasks(tasks)
    try:
        task_num = int(input("\nIndtast nummeret på opgaven, du vil fjerne: "))
        if 1 <= task_num <= len(tasks):
            removed = tasks.pop(task_num - 1)
            print(f"Opgave '{removed}' er fjernet!")
        else:
            print("Ugyldigt nummer!")
    except ValueError:
        print("Indtast venligst et gyldigt nummer!")

# Mark a task as done
def mark_task_done(tasks):
    view_tasks(tasks)
    try:
        task_num = int(input("\nIndtast nummeret på opgaven, du vil markere som færdig: "))
        if 1 <= task_num <= len(tasks):
            tasks[task_num - 1] += " (færdig)"
            print(f"Opgave '{tasks[task_num - 1]}' er markeret som færdig!")
        else:
            print("Ugyldigt nummer!")
    except ValueError:
        print("Indtast venligst et gyldigt nummer!")

# Main menu
def main():
    tasks = load_tasks()
    while True:
        print("\nTo-Do List Manager")
        print("1. Vis opgaver")
        print("2. Tilføj opgave")
        print("3. Fjern opgave")
        print("4. Marker opgave som færdig")
        print("5. Afslut")
        choice = input("Vælg en mulighed: ").strip()

        if choice == "1":
            view_tasks(tasks)
        elif choice == "2":
            add_task(tasks)
        elif choice == "3":
            remove_task(tasks)
        elif choice == "4":
            mark_task_done(tasks)
        elif choice == "5":
            save_tasks(tasks)
            print("Farvel!")
            break
        else:
            print("Ugyldigt valg! Prøv igen.")

#Run program
if __name__ == "__main__":
    main()
