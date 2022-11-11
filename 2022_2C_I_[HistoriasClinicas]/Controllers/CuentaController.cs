﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2022_2C_I__HistoriasClinicas_.Data;

namespace _2022_2C_I__HistoriasClinicas_.Controllers
{
    public class CuentaController : Controller
    {
        private readonly HistoriasClinicasContext _context;

        public CuentaController(HistoriasClinicasContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            var m = _context.Medicos.Where(a => a.email == email).Where(a => a.password == password);
            Medico med;
            try {  med = m.First(); }  catch(Exception e) { med = null; }
            if (med == null) 
            {
                var p = _context.Pacientes.Where(a => a.email == email).Where(a => a.password == password);
                Paciente pac;
                  try { pac = p.First(); } catch (Exception e) { pac = null; }
                if (pac == null)
                { return View(m); }
                else
                {
                    UsuarioLog.UsuarioLogueado =  pac;
                    return Redirect("/Medicos"); }
            }
            else {
                UsuarioLog.UsuarioLogueado = med;
                return Redirect("/paciente"); }
        }

        public IActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrar(IFormCollection form)
        {
            string valor = form["Rol"].ToString();
            if ( valor == "Paciente") {
               return Redirect("/Paciente/create");
            } else
            {
                return Redirect("RegistrarMedico");
            }
        }

        public IActionResult RegistrarMedico()
        {
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarMedico([Bind("MedicoId,Matricula,Especialidad,nombreDeUsuario,email,password,apellido,dni,telefono,direccion")] Medico medico)
        {
            medico.FechaAlta = DateTime.Now;
            try {
                if (ModelState.IsValid)
                {
                    _context.Add(medico);
                    await _context.SaveChangesAsync();
                    return Redirect("/Medicos/index");
                }
                return View(medico);
            } catch(Exception e) {
                return View(medico);
            }
            
        }
    }
}