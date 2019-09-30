using BlazorNetCoreConf.Core.Entities;
using BlazorNetCoreConf.Core.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorNetCoreConf.Core.Components
{
    public class CardBase : ComponentBase
    {
        [Parameter]
        public Movie Movie { get; set; }

        [Parameter]
        public MovieService Service { get; set; }

        [Parameter]
        public Action OnUpdate { get; set; }

        protected async Task Delete()
        {
            await Service.Delete(this.Movie);
            OnUpdate?.Invoke();
        }

        protected async Task ChangeLikeStatus()
        {
            Movie.Liked = !Movie.Liked;
            await Service.Update(Movie);
            OnUpdate?.Invoke();
        }
    }
}
