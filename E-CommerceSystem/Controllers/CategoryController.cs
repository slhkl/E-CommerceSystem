﻿using Business.Business;
using Data.Dto;
using E_CommerceSystem.Validation;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceSystem.Controllers
{
    public class CategoryController : Controller
    {
        CategoryBusiness _categoryBusiness;

        public CategoryController()
        {
            _categoryBusiness = new CategoryBusiness();
        }

        public IActionResult Index()
        {
            return View(_categoryBusiness.Get());
        }

        [HttpGet, ActionName("Add")]
        public IActionResult PageContentForAdd()
        {
            return View();
        }

        [HttpPost, ActionName("Add")]
        public IActionResult AddCategoryToDatabase(CategoryDto category)
        {
            CategoryValidator.ValidateCategoryForAdd(_categoryBusiness, category, ModelState);

            if(ModelState.IsValid)
            {
                _categoryBusiness.Add(category);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet, ActionName("Update")]
        public IActionResult PageContentForUpdate(string id)
        {
            return View(_categoryBusiness.GetDto(id));
        }

        [HttpPost, ActionName("Update")]
        public IActionResult UpdateToDatabase(CategoryDto category)
        {
            _categoryBusiness.Update(category);
            return RedirectToAction("Index");
        }

        [HttpGet, ActionName("Delete")]
        public IActionResult PageContentDelete(string id)
        {
            return View(_categoryBusiness.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteFormDatabase(string id)
        {
            _categoryBusiness.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
