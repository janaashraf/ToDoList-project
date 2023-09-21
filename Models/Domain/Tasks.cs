namespace ToDo.Models.Domain
{
    public class Tasks
    {
        public int TaskId { get; set; }
        public string? taskContent { get; set; }
        public bool taskStatus { get; set; }
    }
}
