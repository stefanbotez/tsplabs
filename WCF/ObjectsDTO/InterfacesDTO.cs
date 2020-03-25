using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsDTO
{
    [ServiceContract]
    public interface IPost
    {
        [OperationContract]
        void Cleanup();
        [OperationContract]
        PostDTO GetPostById(int id);
        // Insert, Update, Delete Post
        [OperationContract]
        bool SubmitPost(PostDTO post);
        [OperationContract]
        PostDTO UpdatePost(PostDTO newPost);
        [OperationContract]
        int DeletePost(int postId);
        [OperationContract]
        List<PostDTO> GetAllPosts();
    }
    [ServiceContract]
    public interface IComment
    {
        // Insert, Update, Delete Comment
        [OperationContract]
        CommentDTO GetCommentById(int id);
        [OperationContract]
        bool SubmitComment(CommentDTO comment);
        [OperationContract]
        CommentDTO UpdateComment(CommentDTO newComment);
    }
    [ServiceContract]
    public interface ILoadData
    {
        [OperationContract]
        List<PostDTO> GetAllPostsAndRelatedComments();
    }
    [ServiceContract]
    public interface IPostComment : IPost, IComment, ILoadData
    { }

}
