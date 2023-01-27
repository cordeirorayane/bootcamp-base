using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;
using AutoMapper;

namespace Tarefas.Web.Controllers
{
    public class TarefaController : Controller
    {
        private readonly TarefaDAO _tarefaDAO;
        private readonly ITarefaDAO _tarefaDAO;
        private readonly IMapper _mapper;

        public TarefaController(ITarefaDAO tarefaDAO)
        {
            _tarefaDAO = tarefaDAO;

        }

        public TarefaController(ITarefaDAO tarefaDAO)
        {
            _tarefaDAO = tarefaDAO;

        }

        public interface ITarefaDAO
        {
            void Atualizar(TarefaDTO tarefa);
            List<TarefaDTO> Consultar();
            TarefaDTO Consultar(int id);
            void Criar(TarefaDTO tarefa);
            void Excluir(int id);
        }

        public TarefaController(ITarefaDAO tarefaDAO, IMapper mapper)
        {
            _tarefaDAO = tarefaDAO; 
            _mapper = mapper;
        }
        
        public IActionResult Details(int id)
        {
           var tarefa = _mapper.Map<TarefaViewModel>(tarefaDTO);

           return View(tarefa);
        }

        public IActionResult Index()
        {
            var listaDeTarefasDTO = _tarefaDAO.Consultar();

            foreach (var tarefaDTO in listaDeTarefasDTO)
            {
                listaDeTarefas.Add(_mapper.Map<TarefaViewModel>(tarefaDTO));

            }
            return View (listaDeTarefas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TarefaViewModel tarefa)
        {
            if(!ModelState.IsValid)
            { return View();}

           var tarefaDTO = _mapper.Map<TarefaDTO>(tarefaViewModel);
            _tarefaDAO.Criar(tarefaDTO);

            return View();
        }
        [HttpPost]
        public IActionResult Update (TarefaViewModel tarefa)
        {
            if(!ModelState.IsValid)
            { 
                return View();
            }

            var tarefaDTO = _mapper.Map<TarefaDTO>(tarefa);
            
            _tarefaDAO.Atualizar(tarefaDTO);

            return View();
        }
        public IActionResult Update(int id)
        {
            var tarefaDTO = _tarefaDAO.Consultar(id);

            var tarefaViewModel = _mapper.Map<TarefaViewModel>(tarefaDTO);
            
            return View(tarefaViewModel);
        }
        public IActionResult Delete(int id)
        {
            _tarefaDAO.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}