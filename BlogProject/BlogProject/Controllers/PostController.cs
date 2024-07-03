using AutoMapper;
using BlogProject.Auth;
using BlogProject.DTOs;
using BlogProject.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    [UserAccess]
    public class PostController : Controller
    { 
        LabdBEntities1 db = new LabdBEntities1();


        public static Post Convert(PostDTO p)
        {
            return new Post
            {
                Pid = p.Pid,
                PostTitle = p.PostTitle,
                PostContent = p.PostContent,
                Uid = p.Uid,

            };
        }

        public static PostDTO Convert(Post pt)
        {
            return new PostDTO
            {
                Pid = pt.Pid,
                PostTitle = pt.PostTitle,
                PostContent = pt.PostContent,
                Uid = pt.Uid,
               
            };
        }

        public static List<PostDTO> Convert(List<Post> ps)
        {
            var list = new List<PostDTO>();
            foreach (var c in ps)
            {
                list.Add(Convert(c));
            }
            return list;
        }

        public static Comment Convert(CommentDTO c)
        {
            return new Comment
            {
                Cid = c.Cid,
                Pid = c.Pid,
                Uid = c.Uid,
                Comment1 = c.Comment1,

            };
        }

        public static CommentDTO Convert(Comment ct)
        {
            return new CommentDTO
            {
                Cid = ct.Cid,
                Pid = ct.Pid,
                Uid = ct.Uid,
                Comment1 = ct.Comment1,

            };
        }

        public static List<CommentDTO> Convert(List<Comment> cs)
        {
            var list = new List<CommentDTO>();
            foreach (var c in cs)
            {
                list.Add(Convert(c));
            }
            return list;
        }




        // GET: Post
        public ActionResult PostDetails()
        {
            var data = db.Posts.ToList();

            return View(Convert(data));
        }


        [HttpGet]

        public ActionResult AddPost()
        {
            return View(new PostDTO());
        }

        [HttpPost]
        public ActionResult AddPost(PostDTO posted)
        {
            if (ModelState.IsValid)
            {

                var post = Convert(posted);
                var user = (User)Session["User"];
                post.Uid = user.Uid;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("PostDetails");
            }

            return View(posted);
        }


        [HttpGet]

        public ActionResult EditPost(int id)
        {
            var exobj = db.Posts.Find(id);
            var data = Convert(exobj);

            return View(data);
        }

        [HttpPost]
        public ActionResult EditPost(PostDTO poster)
        {
            var exobj = db.Posts.Find(poster.Pid);

            exobj.Pid = poster.Pid;
            exobj.PostTitle = poster.PostTitle;
            exobj.PostContent = poster.PostContent;
            exobj.Uid = poster.Uid;

            db.SaveChanges();
            return RedirectToAction("PostDetails", "Post");
        }


        [HttpGet]

        public ActionResult Delete(int id)
        {
            var obj = db.Posts.Find(id);
            if (obj != null)
            {
   
                var postLikes = db.PostLikes.Where(pl => pl.Pid == id).ToList();
                db.PostLikes.RemoveRange(postLikes);

              
                var postTags = db.PostTags.Where(pt => pt.Pid == id).ToList();
                db.PostTags.RemoveRange(postTags);

        
                var comments = db.Comments.Where(c => c.Pid == id).ToList();
                db.Comments.RemoveRange(comments);

                
                db.Posts.Remove(obj);

              
                db.SaveChanges();

                return RedirectToAction("PostDetails", "Post");
            }

            return RedirectToAction("PostDetails", "Post");

        }

        [HttpPost]
        public ActionResult Search(string Search)
        {
            var data = (from p in db.Posts
                        where p.PostTitle.Contains(Search)
                        select p).ToList();

            var podata = Convert(data);
            

            return View("PostDetails", podata);



        }


        [HttpGet]

        public ActionResult Comments()
        {

            return View(new CommentDTO());
        }

        [HttpPost]

        public ActionResult Comments(int id, CommentDTO com)
        {
            if(ModelState.IsValid)
            {

                var comment = Convert(com);
                var user = (User)Session["User"];
                comment.Time = DateTime.Now;
                comment.Uid = user.Uid;
                comment.Pid = id;

                
                db.Comments.Add(comment);
                db.SaveChanges();

                return RedirectToAction("PostDetails");
            }

            return View(com);




        }




    }
}