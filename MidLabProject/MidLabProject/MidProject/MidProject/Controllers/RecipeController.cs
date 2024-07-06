using MidProject.Auth;
using MidProject.DTOs;
using MidProject.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MidProject.Controllers
{
    [UserAccess]
    public class RecipeController : Controller
    {
        MiddBEntities db = new MiddBEntities();

        public static Recipe Convert(RecipeDTO r)
        {
            return new Recipe
            {
                Rid = r.Rid,
                RecipeTitle = r.RecipeTitle,
                RecipeIngridient = r.RecipeIngridient,
                RecipeInstructions = r.RecipeInstructions,
                RecipePostTime = r.RecipePostTime,
                Uid = r.Uid,
            };
        }

        public static RecipeDTO Convert(Recipe rt)
        {
            return new RecipeDTO
            {
                Rid = rt.Rid,
                RecipeTitle = rt.RecipeTitle,
                RecipeIngridient = rt.RecipeIngridient,
                RecipeInstructions = rt.RecipeInstructions,
                RecipePostTime = rt.RecipePostTime,
                Uid = rt.Uid,
            };
        }

        public static List<RecipeDTO> Convert(List<Recipe> rs)
        {
            var list = new List<RecipeDTO>();
            foreach (var c in rs)
            {
                list.Add(Convert(c));
            }
            return list;
        }

        public static RecipeRating Convert(RecipeRatingDTO rr)
        {
            return new RecipeRating
            {
             
                RTid = rr.RTid,
                Uid=rr.Uid,
                Rid = rr.Rid,
                RecipeRating1 = rr.RecipeRating1

            };
        }

        public static RecipeRatingDTO Convert(RecipeRating rrt)
        {
            return new RecipeRatingDTO
            {
                RTid = rrt.RTid,
                Uid = rrt.Uid,
                Rid = rrt.Rid,
                RecipeRating1 = rrt.RecipeRating1

            };
        }

        public static List<RecipeRatingDTO> Convert(List<RecipeRating> rrs)
        {
            var list = new List<RecipeRatingDTO>();
            foreach (var c in rrs)
            {
                list.Add(Convert(c));
            }
            return list;
        }

        public ActionResult RecipeDetails()
        {
            var data = db.Recipes.ToList();

            return View(Convert(data));
        }


        [HttpGet]

        public ActionResult AddRecipe()
        {
            return View(new RecipeDTO());
        }

        [HttpPost]
        public ActionResult AddRecipe(RecipeDTO recipes)
        {
            if (ModelState.IsValid)
            {

                var recipe = Convert(recipes);
                var user = (User)Session["User"];
                recipe.Uid = user.Uid;
                recipe.RecipePostTime = DateTime.Now;
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("RecipeDetails");
            }

            return View(recipes);
        }

        [HttpGet]

        public ActionResult EditRecipe(int id)
        {
            var exobj = db.Recipes.Find(id);
            var data = Convert(exobj);

            return View(data);
        }

        [HttpPost]
        public ActionResult EditRecipe(RecipeDTO recip)
        {
            var exobj = db.Recipes.Find(recip.Rid);

            exobj.Rid = recip.Rid;
            exobj.RecipeTitle = recip.RecipeTitle;
            exobj.RecipeIngridient = recip.RecipeIngridient;
            exobj.RecipeInstructions = recip.RecipeInstructions;
            exobj.RecipePostTime = recip.RecipePostTime;
            exobj.Uid = recip.Uid;

            db.SaveChanges();
            return RedirectToAction("RecipeDetails", "Recipe");
        }

        [HttpGet]

        public ActionResult DeleteRecipe(int id)
        {
            var obj = db.Recipes.Find(id);
            if (obj != null)
            {

                var reciperater = db.RecipeRatings.Where(rl => rl.Rid == id).ToList();
                db.RecipeRatings.RemoveRange(reciperater);

                db.Recipes.Remove(obj);


                db.SaveChanges();

                return RedirectToAction("RecipeDetails", "Recipe");
            }

            return RedirectToAction("RecipeDetails", "Recipe");

        }

        [HttpPost]
        public ActionResult Search(string Search)
        {
            var data = (from r in db.Recipes
                        where r.RecipeTitle.Contains(Search) || r.RecipeIngridient.Contains(Search)
                        select r).ToList();

            var podata = Convert(data);


            return View("RecipeDetails", podata);



        }

        [HttpGet]

        public ActionResult RecipeRating()
        {

            return View(new RecipeRatingDTO());
        }

        [HttpPost]

        public ActionResult RecipeRating(int id, RecipeRatingDTO rrm)
        {
            if (ModelState.IsValid)
            {

                var rating = Convert(rrm);
                var user = (User)Session["User"];
                rating.Uid = user.Uid;
                rating.Rid = id;
                


                db.RecipeRatings.Add(rating);
                db.SaveChanges();

                return RedirectToAction("RecipeDetails");
            }

            return View(rrm);




        }



    }
}