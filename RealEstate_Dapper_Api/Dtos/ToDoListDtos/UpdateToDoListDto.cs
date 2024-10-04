namespace RealEstate_Dapper_Api.Dtos.ToDoListDtos
{
    public class UpdateToDoListDto
    {
        public int TodoListID { get; set; }
        public string Description { get; set; }
        public bool ToDoListStatus { get; set; }
    }
}
