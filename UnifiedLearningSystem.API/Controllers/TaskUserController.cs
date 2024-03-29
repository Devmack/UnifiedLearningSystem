﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnifiedLearningSystem.Application.CQRS.TaskUser.Commands;
using UnifiedLearningSystem.Application.CQRS.TaskUser.Queries;
using UnifiedLearningSystem.Application.DTOs.TaskUser;
using UnifiedLearningSystem.Application.Shared.QueryHelper;

namespace UnifiedLearningSystem.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "student")]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskUserController : ControllerBase
    {
        private readonly IMediator mediatR;

        public TaskUserController(IMediator mediatR)
        {
            this.mediatR = mediatR;
        }

        [HttpGet]
        [Route("reviews/{id}")]
        public async Task<ActionResult> GetAllSolutionsOfUser(Guid id)
        {
            return Ok(await mediatR.Send(new GetAllSolutionsOfUserQuery(id)));
        }

        [HttpGet]
        [Route("reviews/{id}/reviews")]
        public async Task<ActionResult> GetAllSolutionsOfUserWithReviews(Guid id)
        {
            return Ok(await mediatR.Send(new GetAllSolutionsOfUserQuery(id, true)));
        }

        [HttpGet]
        [Route("reviews")]
        public async Task<ActionResult> GetAllSolutions([FromQuery] PageQuery queryPage)
        {
            return Ok(await mediatR.Send(new GetAllSolutionsQuery(queryPage)));
        }


        [HttpPost]
        [Route("userTask")]
        public async Task<ActionResult> CreateNewTask(TaskUserCreateDTO taskUserCreateDTO)
        {
            return Ok(await mediatR.Send(new SendSolutionToReviewCommand(taskUserCreateDTO)));
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("review")]
        public async Task<ActionResult> AddReview(Guid id, string reviewDescription)
        {
            return Ok(await mediatR.Send(new ReviewSolutionCommand(id, reviewDescription)));
        }
    }
}
