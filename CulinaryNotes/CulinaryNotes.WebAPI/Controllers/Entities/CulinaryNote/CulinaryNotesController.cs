using AutoMapper;
using CulinaryNotes.BusinessLogic.CulinaryNotes;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryNotes.WebAPI.Controllers.Entities.CulinaryNote
{
    [ApiController]
    [Route("[controller]")]
    public class CulinaryNotesController : ControllerBase
    {
        private readonly ICulinaryNotesManager _culinaryNotesManager;
        private readonly ICulinaryNotesProvider _culinaryNotesProvider;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CulinaryNotesController(
            ICulinaryNotesManager culinaryNotesManager,
            ICulinaryNotesProvider culinaryNotesProvider,
            IMapper mapper,
            ILogger logger)
        {
            _culinaryNotesManager = culinaryNotesManager;
            _culinaryNotesProvider = culinaryNotesProvider;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllCulinaryNotes()
        {
            var culinaryNotes = _culinaryNotesProvider.GetCulinaryNotes();
            return Ok(new CulinaryNotesListResponse()
            {
                CulinaryNotes = culinaryNotes.ToList()
            });
        }

        [HttpGet]
        [Route("filter")]
        public IActionResult GetCulinaryNotes([FromQuery] CulinaryNotesFilter filter)
        {
            var culinaryNotes = _culinaryNotesProvider.GetCulinaryNotes(_mapper.Map<CulinaryNoteModelFilter>(filter));
            return Ok(new CulinaryNotesListResponse()
            {
                CulinaryNotes = culinaryNotes.ToList()
            });
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCulinaryNotesInfo([FromRoute] Guid id)
        {
            try
            {
                var culinaryNotes = _culinaryNotesProvider.GetCulinaryNoteInfo(id);
                return Ok(culinaryNotes);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateCulinaryNotes([FromBody] CreateCulinaryNoteRequest request)
        {
            try
            {
                var culinaryNotes = _culinaryNotesManager.CreateCulinaryNote(_mapper.Map<CreateCulinaryNoteModel>(request));
                return Ok(culinaryNotes);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateCulinaryNoteInfo([FromRoute] Guid id, UpdateCulinaryNoteRequest request)
        {
            try
            {
                var culinaryNotes = _culinaryNotesManager.UpdateCulinaryNote(id, _mapper.Map<UpdateCulinaryNoteModel>(request));
                return Ok(culinaryNotes);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCulinaryNote([FromRoute] Guid id)
        {
            try
            {
                _culinaryNotesManager.DeleteCulinaryNote(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
        }
    }
}
