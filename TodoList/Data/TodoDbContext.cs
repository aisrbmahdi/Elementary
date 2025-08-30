using System;
using Microsoft.EntityFrameworkCore;

using TodoList.Models;


namespace TodoList.Data
{
    public class TodoDbContext(DbContextOptions<TodoDbContext>options):DbContext(options) 
    {
        public DbSet<ToDoItem>ToDoItems => Set<ToDoItem>();
    }
}
