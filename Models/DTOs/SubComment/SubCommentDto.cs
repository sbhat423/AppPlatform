namespace Models.DTOs.SubComment
{
    public class SubCommentDto
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string Content { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
