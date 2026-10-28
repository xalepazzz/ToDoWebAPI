using BusienessLayer.DTO;
using BusienessLayer.Entities;

namespace back.Mapping
{
    public static class ToDoDtoMapping
    {
        public static ToDoDto ToDto (this ToDo toDo)
        {
            return new ToDoDto 
            {
                Id = toDo.Id,
                Title = toDo.Title,
                Description = toDo.Description,
                StartTime = toDo.StartTime,
                CreateTime = toDo.CreateTime,
                EndTime = toDo.EndTime
            };
        }

        public static async Task<List<ToDoDto>> ToDtoList(this List<ToDo> toDoList)
        {
            return toDoList.Select(t => t.ToDto()).ToList();
        }
    }
}
