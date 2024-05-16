using BlogApp.Models.Auth;
using BlogApp.Models.Post;
using BlogApp.Services.Interfaces;
using BlogApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace BlogApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IValidationService _validationService;

        public PostController(IPostService postService, IValidationService validationService)
        {
            _postService = postService;
            _validationService = validationService;
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

        [HttpGet("posts-user")]
        public async Task<IActionResult> GetPostsUser()
        {
            try
            {
                var tokenJwt = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var userId = JwtTokenReader.ExtractUserIdFromToken(tokenJwt);

                var posts = await _postService.GetPostsUserAsync(userId);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar as postagens do usuário: {ex}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
        {
            try
            {
                var tokenJwt = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var userId = JwtTokenReader.ExtractUserIdFromToken(tokenJwt);

                var post = await _postService.CreatePostAsync(userId, request);

                return CreatedAtAction(nameof(GetPosts), new { id = post.Id }, post);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar a postagem: {ex}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditPost([FromBody] EditPostRequest request)
        {
            try
            {
                var tokenJwt = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                var post = await _postService.EditPostAsync(request);

                if (post == null)
                {
                    return NotFound();
                }

                if (!_validationService.ValidarUsuario(tokenJwt, post.UserId))
                    return Unauthorized();

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
                var tokenJwt = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var post = await _postService.GetPostByIdAsync(id);

                if (!_validationService.ValidarUsuario(tokenJwt, post.UserId))
                    return Unauthorized();

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
