using System;

namespace dotNetTodoReview.Models
{
    public class ToDoModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
