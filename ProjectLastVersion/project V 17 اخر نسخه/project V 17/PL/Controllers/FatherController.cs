using AutoMapper;
using BLL.IPersonReposatores;
using BLL.PersonReposatores;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Helpers;
using PL.Models;
using System.Collections.Generic;

namespace PL.Controllers
{
    [Authorize]
    public class FatherController : Controller
    {
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FatherController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            
            var entity= _unitOfWork.FatherReposatories.GetAll();
            var MapperFather = _mapper.Map<IEnumerable<Father>, IEnumerable<FatherViewModel>>(entity);
           _unitOfWork.Complete();
            return View(MapperFather);
        }


        public IActionResult Create() { 
        return View();
        
        
        }

        [HttpPost]
        public IActionResult Create(FatherViewModel fatherVM)
        {

            if (fatherVM.Image is null)
            {
                TempData["Massage"] = "Please enter a photo :) ";
                return View(fatherVM);
            }
            fatherVM.ImageName= DocumentSettings.UploadFile(fatherVM.Image, "Fathers_Images");
            var MapperFather = _mapper.Map<FatherViewModel,Father>(fatherVM);    
            _unitOfWork.FatherReposatories.Add(MapperFather);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
            //return RedirectToRoute(new { controller = "Personal", action = "Index" });
        }
       
        public IActionResult Detielse(long? id , string ViewName= nameof(Detielse))
        {

            
            if (id.HasValue)
            {
                var entite = _unitOfWork.FatherReposatories.GetById(id.Value);
                var MapperFather = _mapper.Map<Father, FatherViewModel>(entite);
                _unitOfWork.Complete();
                 return View(ViewName, MapperFather);
            }
            return NotFound();
        }
        public IActionResult Edit(long? id)
        {
            return Detielse(id ,nameof(Edit));
        }

        [HttpPost]
        public IActionResult Edit(FatherViewModel fatherVM , [FromRoute] long id)
        {
            if (id != fatherVM.National_Father_Id)
            {
                return BadRequest();
            }

            if (fatherVM.Image is not null)
            {
                if (fatherVM.ImageName is not null)
                {
                    DocumentSettings.DeleteFile(fatherVM.ImageName, "Fathers_Images");
                }
                fatherVM.ImageName = DocumentSettings.UploadFile(fatherVM.Image, "Fathers_Images");
            }
            var MapperFather = _mapper.Map<FatherViewModel, Father>(fatherVM);
            _unitOfWork.FatherReposatories.Update(MapperFather);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(long? id)
        {
            return Detielse(id, nameof(Delete));
        }



        [HttpPost]
        public IActionResult Delete(FatherViewModel fatherVM)
        {
            var MapperFather = _mapper.Map<FatherViewModel, Father>(fatherVM);
            _unitOfWork.FatherReposatories.Delete(MapperFather);
            var Result = _unitOfWork.Complete();
            if (Result > 0 && fatherVM.ImageName is not null)
            {
                DocumentSettings.DeleteFile(fatherVM.ImageName, "Fathers_Images");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
