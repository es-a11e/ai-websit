
using AutoMapper;
using BLL.IPersonReposatores;
using BLL.PersonReposatores;
using DAL.AppDbContext;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Helpers;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace PL.Controllers
{
    [Authorize]
    public class PersonalController : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonalController(IUnitOfWork unitOfWork,IMapper mapper)

        {
           
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var entits =_unitOfWork.PersonalReposatores.GetAll();
            var MappedEmployees = _mapper.Map<IEnumerable<Person>, IEnumerable<PersonsViewModel>>(entits);

            return View(MappedEmployees);
        }

       

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonsViewModel personVM)
        {
            if (personVM.Image is null)
            {
                TempData["Massage"] = "Please enter a photo :) ";
                return View(personVM);
                
            }
            
        if (ModelState.IsValid)
            {

                try
                {
                    personVM.ImageName = DocumentSettings.UploadFile(personVM.Image, "Chiledrens_Images");
                    var MappedPersons = _mapper.Map<PersonsViewModel, Person>(personVM);
                    _unitOfWork.PersonalReposatores.Add(MappedPersons);
                    int result = _unitOfWork.Complete();
                    if (result > 0)
                    {
                        TempData["Massage"] = " Success Created ";
                    }

                }
                catch
                {
                    TempData["Massage"] = "Please confirm the national ID number ";
                    return View(personVM);
                }




                //else
                //{
                //    TempData["Massage"] = "Feild Created ";
                //    return View(personVM);
                //}

                return RedirectToAction("Index"); 
            }
            return View(personVM);
             
        }


        public IActionResult Detielse(long? id , string ViewName = "Detielse")
        {

           var entite= _unitOfWork.PersonalReposatores.GetById(id.Value);

            var MappedPersons = _mapper.Map<Person,PersonsViewModel>(entite);

            return View(ViewName, MappedPersons);
        }

       
        
        public IActionResult Edit(long? id )
        {
            return Detielse(id , "Edit");
        }

        

        [HttpPost]
        public IActionResult Edit(PersonsViewModel personVM, [FromRoute] long id)
        {
            if (id != personVM.NationalPerson_Id)
            {
                return BadRequest();

            }
            if (ModelState.IsValid)
            {
                try
                {
                    

                    if (personVM.Image is not null)
                    {
                        if (personVM.ImageName is not null)
                        {
                            DocumentSettings.DeleteFile(personVM.ImageName, "Chiledrens_Images");
                        }
                        personVM.ImageName = DocumentSettings.UploadFile(personVM.Image, "Chiledrens_Images");
                    }
                    var MappedPersons = _mapper.Map< PersonsViewModel,Person>(personVM);
                    _unitOfWork.PersonalReposatores.Update(MappedPersons);
                    _unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
                catch(System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
         return View(personVM);
        }

        public IActionResult ReportedChildren()
        {



            var persons = _unitOfWork.PersonalReposatores.GetListOfMissing()
                                              .Select(person => _mapper.Map<PersonsViewModel>(person));

            return View(persons);
        }

        public IActionResult EditReportedChildren(long? id)
        {
            return Detielse(id, "EditReportedChildren");
        }


        [HttpPost]
        public IActionResult EditReportedChildren(PersonsViewModel personVM, [FromRoute] long id)
        {
            if (id != personVM.NationalPerson_Id)
            {
                return BadRequest();

            }


            if (ModelState.IsValid)
            {
                try
                {
                    if (personVM.Image is not null)
                    {
                        if (personVM.ImageName is not null)
                        {
                            DocumentSettings.DeleteFile(personVM.ImageName, "Chiledrens_Images");
                        }
                        personVM.ImageName = DocumentSettings.UploadFile(personVM.Image, "Chiledrens_Images");
                    }
                    var MappedPersons = _mapper.Map<PersonsViewModel, Person>(personVM);
                    _unitOfWork.PersonalReposatores.Update(MappedPersons);
                    _unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(personVM);


           
        }



        public IActionResult Delete(long? id)
        {
            
            return Detielse(id , "Delete");
        }
        [HttpPost]
        public IActionResult Delete(PersonsViewModel personVM, [FromRoute] long? id)
        {
            if ( id != personVM.NationalPerson_Id)
            {
                return BadRequest();
            }
            try
            {
                var MappedPersons = _mapper.Map<PersonsViewModel, Person>(personVM);
                _unitOfWork.PersonalReposatores.Delete(MappedPersons);
                var Result=  _unitOfWork.Complete();
                if (Result > 0 && personVM.ImageName is not null)
                {
                    DocumentSettings.DeleteFile(personVM.ImageName, "Chiledrens_Images");
                }
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(personVM);
            }
        
           
        }




        
        public IActionResult Search(long? SearchValue)
        {
            
            var entite = _unitOfWork.PersonalReposatores.GetById(SearchValue.Value);
            if (entite is null)
            {
                return NotFound();
            }
            var MappedPersons = _mapper.Map<Person, PersonsViewModel>(entite);
            return View(MappedPersons);
        }








    }



}
