using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerDataAcess.Models
{
    public class Bundle
    {
        public Bundle(string description, string name, List<Task> tasks, int id, int completionCriteria, bool completed)
        {
            Description = description;
            Name = name;
            Tasks = tasks;
            Id = id;
            CompletionCriteria = completionCriteria;
            Completed = completed;
        }

        public Bundle()
        {
        }

        public string Description { get; set; }

        public string Name { get; set; }

        public List<Task> Tasks { get; set; }

        public int Id { get; set; }

        public int CompletionCriteria { get; set; }

        public bool Completed { get; set; }

        public void Update(Bundle bundle)
        {
            if (bundle != null)
            {
                this.Description = bundle.Description;
                this.Name = bundle.Name;
                this.CompletionCriteria = bundle.CompletionCriteria;
                this.Tasks = bundle.Tasks;
                this.Id = bundle.Id;
                this.Completed = bundle.Completed;
                BundlesDataAcess.Update(bundle);
            }

        }

        public void MarkAsCompleted(Bundle bundle)
        {
            if (bundle != null)
            {
                this.Completed = true;
                Update(bundle);
            }

        }

        public Bundle GetById(int id)
        {
            return BundlesDataAcess.Get(id);
        }

        public List<Bundle> GetByCriteria(string criteria)
        {
            return BundlesDataAcess.Get(criteria);
        }
    }
}
