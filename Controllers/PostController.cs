using BlogApp.Models.Auth;
using BlogApp.Models.Post;
using BlogApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BlogApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            try
            {
                var posts = await _postService.GetPostsAsync();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar as postagens: {ex}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
        {
            try
            {
                var post = await _postService.CreatePostAsync(request.UserId, request.Title, request.Content);
                return CreatedAtAction(nameof(GetPosts), new { id = post.Id }, post);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar a postagem: {ex}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPost(int id, [FromBody] EditPostRequest request)
        {
            try
            {
                var post = await _postService.EditPostAsync(id, request.Title, request.Content);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao editar a postagem: {ex}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _postService.DeletePostAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir a postagem: {ex}");
            }
        }
    }
}
