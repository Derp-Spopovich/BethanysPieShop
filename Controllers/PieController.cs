using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        //dependency injection
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        //constructor, injects in the controller cause specify it in the startup
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            //injecting, so we have access in our model
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }
       
        public ViewResult List()
        {
            //call piesListViewModel and only use it in this method
            PiesListViewModel piesListViewModel = new PiesListViewModel();

            piesListViewModel.Pies = _pieRepository.AllPies;
            piesListViewModel.CurrentCategory = "Cheese cakes";

            return View(piesListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }

        //we need an action method, needs to be public
        //this is an action method, we specified list to pass the data by a list
        //public ViewResult List()
        //{
        //    return View(_pieRepository.AllPies);
        //}
    }
}
