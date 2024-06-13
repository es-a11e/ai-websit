using AutoMapper;
using BLL.IPersonReposatores;
using BLL.PersonReposatores;
using DAL.AppDbContext;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PL.Helpers;
using PL.Models;

namespace PL.Controllers
{
    [Authorize]
    public class MotherController : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MotherController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var entity = _unitOfWork.MotherReposatores.GetAll();

            return View(entity);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MotherViewModel motherVM)
        {
            if (motherVM.Image is null)
            {
                TempData["Massage"] = "Please enter a photo :) ";
                return View(motherVM);

            }
            if (motherVM.Image is null)
            {
                return View(motherVM);
            }
            motherVM.ImageName= DocumentSettings.UploadFile(motherVM.Image, "Mother_Images");
            var MapperMother=_mapper.Map<MotherViewModel,Mother>(motherVM);
            _unitOfWork.MotherReposatores.Add(MapperMother);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(long? id, string ViewName = nameof(Details))
        {

            if (id.HasValue)
            {
                
                var entite = _unitOfWork.MotherReposatores.GetById(id.Value);
                var MapperMother= _mapper.Map<Mother,MotherViewModel>(entite);
                _unitOfWork.Complete();

                return View(ViewName, MapperMother);
            }
            return NotFound();
        }

        public IActionResult Edit(long? id ) 
        {

            return Details(id,nameof(Edit));
        }

        [HttpPost]
        public IActionResult Edit(MotherViewModel motherVM)
        {
            if (motherVM.Image is not null)
            {
                if (motherVM.ImageName is not null)
                {
                    DocumentSettings.DeleteFile(motherVM.ImageName, "Mother_Images");
                }
                motherVM.ImageName = DocumentSettings.UploadFile(motherVM.Image, "Mother_Images");
            }
            var MapperMother = _mapper.Map<MotherViewModel, Mother>(motherVM);
            _unitOfWork.MotherReposatores.Update(MapperMother);
            _unitOfWork.Complete();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(long? id)
        {
            return Details(id, nameof(Delete));
        }


        [HttpPost]
        public IActionResult Delete(MotherViewModel motherVM)
        {
            var MapperMother = _mapper.Map<MotherViewModel, Mother>(motherVM);
            _unitOfWork.MotherReposatores.Delete(MapperMother);
            var Result = _unitOfWork.Complete();
            if (Result > 0 && motherVM.ImageName is not null)
            {
                DocumentSettings.DeleteFile(motherVM.ImageName, "Mother_Images");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
