using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerDataAcess.Models
{
    public class Task
    {
        public string Description { get; set; }

        public int CompletionCriteria { get; set; }

        public int Id { get; set; }

        public int BundleId { get; set; }

        public int DifficultyLevel { get; set; }

        public bool Completed { get; set; }

        public Task(string description, int id, int difficultyLevel)
        {
            Description = description;
            Id = id;
            DifficultyLevel = difficultyLevel;
            Completed = false;
        }

        public Task()
        {
        }

        public void Update(Task task)
        {
            if (task != null)
            {
                this.Description = task.Description;
                this.Id = task.Id;
                this.DifficultyLevel = task.DifficultyLevel;
                this.Completed = task.Completed;
                PokerDataAcess.TaskDataAcess.Update(task);
            }

        }
        public void MarkAsCompleted(Task task)
        {
            if (task != null)
            {
                this.Completed = true;
                Update(task);
            }

        }

        public Task GetById(int id)
        {
           return  TaskDataAcess.Get(id);
        }

        public List<Task> GetByCriteria(string criteria)
        {
            return TaskDataAcess.Get(criteria);
        }

    }

}
