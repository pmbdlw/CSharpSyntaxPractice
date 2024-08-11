using AutoMapper;
using CodeFirstLearning.Application.Commands;
using CodeFirstLearning.Application.Interfaces;
using CodeFirstLearning.Webapi.Models.CreatePost;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstLearning.Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public PostsController(IPostService postService, IMediator mediator,IMapper mapper)
    {
        _postService = postService;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetPostById(long id)
    {
        var post = await _postService.GetPostByIdAsync(id);
        if (post == null)
            return NotFound();
        var responsePost = _mapper.Map<ResponsePost>(post);
        return Ok(responsePost);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        var posts = await _postService.GetAllPostsAsync();
        return Ok(posts);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        // Get new post entity from database
        var post = await _mediator.Send(command);
        var responsePost = _mapper.Map<ResponsePost>(post);
        // then transfer post to response model.
        // await _postService.CreatePostAsync(post);
        return CreatedAtAction(nameof(GetPostById), new { id = post.PostId }, responsePost);
    }
}