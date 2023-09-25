using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.Models;
using SmartEdu.Repository;
using SmartEdu.UnitOfWork;
using Serilog;
using System.Linq.Expressions;

namespace SmartEdu.Controllers
{
    [Controller]
    public class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly string _entityName;
        private readonly IGenericRepository<TEntity> _entityRepository;

        public BaseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _entityName = typeof(TEntity).Name;
            _entityRepository = (GenericRepository<TEntity>)_unitOfWork.GetType().GetProperty($"{_entityName}Repository").GetValue(_unitOfWork, null);
        }

        protected async Task<IActionResult> Count(Func<TEntity, bool> filter = null)
        {
            var serverResponse = new ServerResponse<object>();
            var count = _entityRepository.Count(filter);
            serverResponse.Data = count;
            return Ok(serverResponse);
        }

        protected async Task<IActionResult> GetAll<TDTO>(RequestParams requestParams, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, List<string> includeProperties = null)
        {
            var serverResponse = new ServerResponse<IEnumerable<TDTO>>();
            var entities = await _entityRepository.GetAll(requestParams, filter, orderBy, includeProperties);
            var entitiesDTO = entities.Select(e => _mapper.Map<TDTO>(e));
            serverResponse.Data = entitiesDTO;
            return Ok(serverResponse);
        }

        protected async Task<IActionResult> GetSingle<TDTO>(Expression<Func<TEntity, bool>> filter, List<string> includeProperties = null)
        {
            var serverResponse = new ServerResponse<object>();
            var entity = await _entityRepository.GetSingle(filter, includeProperties);

            if (entity is null)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "The resource you looking for is not found.";
                return NotFound(serverResponse);
            }

            var entityDTO = _mapper.Map<TDTO>(entity);
            serverResponse.Data = entityDTO;
            return Ok(serverResponse);

        }

        protected async Task<IActionResult> Add<TDTO>(TDTO addEntityDTO, string routeName)
        {
            var serverResponse = new ServerResponse<object>();
            if (!ModelState.IsValid)
            {
                Log.Error($"Invalid POST attempt in the {nameof(Add)} method");
                serverResponse.Succeeded = false;
                serverResponse.Message = "Submitted data is invalid. Please check the error and try again.";
                serverResponse.Data = ModelState;
                return BadRequest(serverResponse);
            }

            var entity = _mapper.Map<TEntity>(addEntityDTO);

            await _entityRepository.Add(entity);
            await _unitOfWork.Save();

            serverResponse.Data = entity;
            return Ok(serverResponse);

        }

        protected async Task<IActionResult> AddRange<TDTO>(IEnumerable<TDTO> addEntitiesDTO)
        {
            var serverResponse = new ServerResponse<object>();
            if (!ModelState.IsValid)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Submitted data is invalid. Please check the error and try again.";
                serverResponse.Data = ModelState;
                Log.Error($"Invalid POST attempt in the {nameof(AddRange)} method.");
                return BadRequest(serverResponse);
            }

            var entities = addEntitiesDTO.Select(e => _mapper.Map<TEntity>(e));

            await _entityRepository.AddRange(entities);
            await _unitOfWork.Save();

            serverResponse.Data = entities;
            return Ok(serverResponse);
        }

        protected async Task<IActionResult> Update<TDTO>(Expression<Func<TEntity, bool>> filter, TDTO updateEntityDTO)
        {
            var serverResponse = new ServerResponse<object>();

            if (!ModelState.IsValid)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Submitted data is invalid. Please check the error and try again.";
                serverResponse.Data = ModelState;
                Log.Error($"Invalid UPDATE attempt in the {nameof(Update)} method");
                return BadRequest(serverResponse);
            }


            var entity = await _entityRepository.GetSingle(filter);

            if (entity is null)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "The entity you want to update is not existing.";
                Log.Error($"Invalid UPDATE attempt in the {nameof(Update)} method");
                return NotFound(serverResponse);
            }

            _mapper.Map(updateEntityDTO, entity);
            _entityRepository.Update(entity);

            await _unitOfWork.Save();

            serverResponse.Data = entity;

            return Ok(serverResponse);

        }

        protected async Task<IActionResult> Delete([FromBody] Expression<Func<TEntity, bool>> filter, [FromRoute] object id)
        {
            var serverResponse = new ServerResponse<object>();
            var entity = await _entityRepository.GetSingle(filter);

            if (entity is null)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "The entity you want to delete is not existing.";
                Log.Error($"Invalid DELETE attempt in the {nameof(Delete)} method");
                return BadRequest(serverResponse);
            }

            await _entityRepository.Delete(id);

            await _unitOfWork.Save();
            serverResponse.Message = "The entity has been successfully deleted.";
            return Ok(serverResponse);

        }
    }
}
