using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using AutoMapper;
using AutoMapper.Configuration;
using ObjectsDTO;
using PostComment;
using PostComment.APIStatic;

namespace ObjectsDTO
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServicePostComment : IPostComment
    {
        MapperConfiguration config;
        IMapper iMapper;
        public ServicePostComment()
        {
            // Configurare AutoMapper
            config = new MapperConfiguration(
            cfg => {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<Comment, CommentDTO>();
            });
            iMapper = config.CreateMapper();
        }
        public void Cleanup()
        {
            Cleanup();
        }
        public List<PostDTO> GetAllPosts()
        {
            var lp = API.GetAllPosts();
            List<PostDTO> lpDto = new List<PostDTO>();
            lpDto = iMapper.Map<List<Post>, List<PostDTO>>(lp);
            return lpDto;
        }
        public PostDTO GetPostById(int id)
        {
            Post post = API.GetPostById(id);
            PostDTO postDTO = iMapper.Map<Post, PostDTO>(post);
            return postDTO;
        }
        public bool SubmitPost(PostDTO postDTO)
        {
            Post post = new Post();
            post = iMapper.Map<PostDTO, Post>(postDTO);
            return API.AddPost(post);
        }
        public PostDTO UpdatePost(PostDTO newPost)
        {
            Post post = iMapper.Map<PostDTO, Post>(newPost);
            post = API.UpdatePost(post);
            PostDTO postDTO = iMapper.Map<Post, PostDTO>(post);
            return postDTO;
        }
        public int DeletePost(int postId)
        {
            return API.DeletePost(postId);
        }

        public CommentDTO GetCommentById(int id)
        {
            Comment comment = API.GetCommentById(id);
            CommentDTO commentDTO = iMapper.Map<Comment, CommentDTO>(comment);
            return commentDTO;
        }
        public bool SubmitComment(CommentDTO commentDTO)
        {
            Comment comment = iMapper.Map<CommentDTO, Comment>(commentDTO);
            return API.AddComment(comment);
        }
        public CommentDTO UpdateComment(CommentDTO newCommentDTO)
        {
            Comment newComment = iMapper.Map<CommentDTO, Comment>(newCommentDTO);
            Comment comment = API.UpdateComment(newComment);
            CommentDTO comm = iMapper.Map<Comment, CommentDTO>(comment);
            return comm;
        }
        List<PostDTO> ILoadData.GetAllPostsAndRelatedComments()
        {
            return GetAllPosts();
        }
    }
}