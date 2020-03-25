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
        /// <summary>
        /// Instanta a clasei ServicePost, clasa ce expune metode de lucru cu EF pentru
        /// baza de date WCF.
        /// Exemplu de cod din aceasta clasa, ServicePost. Vedeti acces la context.
        /// public List<Post> GetAll()
        /// {
        /// List<Post> lp = new List<Post>();
        /// using (var context = new ModelPostBlogContainer())
        /// {
        /// lp = context.Posts.Include(p => p.Comments).ToList();
        /// }
        /// return lp;
        /// }
        /// </summary>
        //
        // In ctor configurez AutoMapper
        //
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
        // Interfata ILoadData
        public List<PostDTO> GetAllPosts()
        {
            var lp = API.GetAllPosts();
            // Constructie lista PostDTO
            List<PostDTO> lpDto = new List<PostDTO>();
            lpDto = iMapper.Map<List<Post>, List<PostDTO>>(lp);
            return lpDto;
            #region Comentariu
            /* Cam acest lucru face AutoMapper.
           Construieste DTO din obiectele din server (EF)
            foreach (var p in lp)
            {
            PostDTO pd = new PostDTO()
            {
            PostId = p.PostId,
           Title = p.Title
            };
            if (p.Comments.Count > 0)
            {
            foreach (var c in p.Comments)
           {
            //pd.Comments = new List<CommentDTO>();
           CommentDTO cd = new CommentDTO();
           cd.CommentId = c.CommentId;
           cd.CommentText = c.CommentText;
           //cd.PostId = c.PostId;
           //cd.PostPostId = c.PostPostId;
           pd.Comments.Add(cd);
            }
            }
            lpDto.Add(pd);
            }
            return lpDto;
            */
            #endregion
        }
        // IPost implementation methods
        public PostDTO GetPostById(int id)
        {
            Post post = API.GetPostById(id);
            // Reconstructie obiecte cunoscute in serviciu
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