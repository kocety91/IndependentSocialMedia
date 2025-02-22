﻿namespace IndependentSocialApp.Web.Controllers
{
    using System.Threading.Tasks;

    using IndependentSocialApp.Services.Data;
    using IndependentSocialApp.Web.Infrastructure.Extensions;
    using IndependentSocialApp.Web.Infrastructure.NloggerExtentions;
    using IndependentSocialApp.Web.ViewModels.Likes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static IndependentSocialApp.Common.NloggerMessages;

    public class LikesController : ApiController
    {
        private readonly ILikesService likesService;
        private readonly INloggerManager nlog;

        public LikesController(
            ILikesService likesService,
            INloggerManager nlog)
        {
            this.likesService = likesService;
            this.nlog = nlog;
        }

        [HttpPost]
        [Route("createlikepost")]
        public async Task<ActionResult> CreateLikePost(LikeRequestModel model)
        {
            var userId = this.User.GetId();

            await this.likesService.CreatePostLikeAsync(model, userId);

            this.nlog.LogInfo(string.Format(SuccesfullyCreated, this.RouteData.Values["action"].ToString()));

            return this.StatusCode(201);
        }

        [HttpPost]
        [Route("createunlikepost")]
        public async Task<ActionResult> CreateUnlikePost(LikeRequestModel model)
        {
            var userId = this.User.GetId();

            await this.likesService.CreatePostUnlikeAsync(model, userId);

            this.nlog.LogInfo(string.Format(SuccesfullyUnlikedPost));

            return this.StatusCode(201);
        }

        [HttpPost]
        [Route("createlikecomment")]
        public async Task<ActionResult> CreateLikeComment(LikeRequestModel model)
        {
            var userId = this.User.GetId();

            await this.likesService.CreateCommentLikeAsync(model, userId);

            this.nlog.LogInfo(string.Format(SuccesfullyCreated, this.RouteData.Values["action"].ToString()));

            return this.StatusCode(201);
        }

        [HttpPost]
        [Route("createunlikecomment")]
        public async Task<ActionResult> CreateUnlikeComment(LikeRequestModel model)
        {
            var userId = this.User.GetId();

            await this.likesService.CreateCommentUnlikeAsync(model, userId);

            this.nlog.LogInfo(string.Format(SuccesfullyUnlikedComment));

            return this.StatusCode(201);
        }
    }
}
