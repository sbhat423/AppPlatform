using Models.DTOs.SubComment;

namespace DataAccess.DataServices
{
    public interface ISubCommentService
    {
        Task Create(SubCommentDto subCommentDto);
        Task<IEnumerable<SubCommentDto>> List(int commentId);
        Task Delete(int subCommentId);
        Task<SubCommentDto> Update(int subCommentId, SubCommentDto subCommentDto);
    }
}
