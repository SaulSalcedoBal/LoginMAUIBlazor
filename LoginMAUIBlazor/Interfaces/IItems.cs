using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginMAUIBlazor.Models;

namespace LoginMAUIBlazor.Interfaces
{
    public interface IItems
    {
        Task<IEnumerable<TodoItem>> GetItems();
    }
}
