using OfcPim.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace OfcPim.Controllers
{
    
    public class HomeController : Controller 
    {

        public ActionResult SucessSolict()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(EBRX_CLIENTE cliente)
        {
            if (ModelState.IsValid)
            {
                using (BDPIMEntities useracss = new BDPIMEntities())
                {
                    var v = useracss.EBRX_CLIENTE.Where(a => a.CPF_STR_CLI.Equals(cliente.CPF_STR_CLI) && a.SENH_ACC.Equals(cliente.SENH_ACC)).FirstOrDefault();
                    if(v!= null)
                    {
                        Session["usuarioLogadoID"] = v.CLI_INT_ID.ToString();
                        Session["nomeUsuarioLogado"] = v.NOME_STR_CLI.ToString();
                        Session["cpfCliente"] = v.CPF_STR_CLI.ToString();
                        Session["emailCliente"] = v.EMAIL_STR_CLI.ToString();
                        Session["dataNascCliente"] = v.DT_NASC_CLI.ToString();
                        


                        return RedirectToAction("CarteiraDigital", "Home", new { clientId = v.CLI_INT_ID});

                    }
                    else
                    {
                        TempData["FailMessage"] = "CPF ou Senha incorretos";
                        return RedirectToAction("Login");
                    }
                     
                }
            }
            return View(cliente);
        }


        public ActionResult Dashboard(long? id)
        {

            return View();
        }


        public ActionResult Service()
        {
            return View();
        }

        public ActionResult BankAccountCreate()
        {
            
            using (var db = new BDPIMEntities())
            {

                var instiBancaria = db.INSTI_BANCO.Select(b => new
                {
                    InstiCod = b.BANCO_INT_ID,
                    InstiName = b.NOME_STR_BANK,
                    InstiCnpj = b.CNPJ_STR_BANK,
                }).ToList();
                ViewBag.InstiBancarias = new SelectList(instiBancaria, "InstiCod", "InstiName");
           }
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BankAccountCreate(EBRX_BANCO_CONTA _contaBancaria)
        {
            try
            {

                using (BDPIMEntities contxt = new BDPIMEntities())
                {
                    contxt.EBRX_BANCO_CONTA.Add(_contaBancaria);
                    contxt.SaveChanges();
                    ModelState.Clear();
                    _contaBancaria = null;
                    ViewBag.Message = "Conta Bancária registrada com sucesso.";
                    
                    return RedirectToAction("SucessSolict", "Home");
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return View(_contaBancaria);
            }
            
        }



        public ActionResult SolicitaAtendmnt()
        {
            using(var dbSolict = new BDPIMEntities())
            {
                var tipoSolict = dbSolict.EBRX_SOLICT.Select(sol => new
                {
                    SOLICTCOD = sol.COD_INT_SOL,
                    SOLDESC = sol.DESC_NOM_SOL,
                }).ToList();
                ViewBag.TipoSolicitacao = new SelectList(tipoSolict, "SOLICTCOD", "SOLDESC");
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SolicitaAtendmnt(EBRX_CLIENT_SOLICIT _novaSolict)
        {
            try
            {
                using(BDPIMEntities contextSolicit = new BDPIMEntities())
                {
                    contextSolicit.EBRX_CLIENT_SOLICIT.Add(_novaSolict);
                    contextSolicit.SaveChanges();
                    ModelState.Clear();
                    _novaSolict = null;
                    
                    return RedirectToAction("SucessSolict", "Home");
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return View(_novaSolict);
            }

        }

        public ActionResult MinhaConta(long? id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MinhaConta()
        {
            return View(); 

        }

        public ActionResult CarteiraDigital()
        {

            return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CarteiraDigital(EBRX_CARTEIRA _carteiraInformacoes)
        {
           
            return View(_carteiraInformacoes);

        }

        public ActionResult Registro()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(EBRX_CLIENTE _usuario)
        {

            if (ModelState.IsValid)
            {
                using (BDPIMEntities dc = new BDPIMEntities())
                {
                    //Aqui deveríamos verificar se o usuário já esta registrado
                    dc.EBRX_CLIENTE.Add(_usuario);
                    dc.SaveChanges();
                    ModelState.Clear();
                    _usuario = null;

                    TempData["userCriado"] = "SUCESSO!! Seja bem-vindo a EBRAX, pode efetuar seu login utilizando seu CPF e sua Senha ";


                    return RedirectToAction("SucessCad", "Home", new {  });
                }
            }
            return View(_usuario);
        }
        public ActionResult SucessCad()
        {


            return View();
        }
    }
}

