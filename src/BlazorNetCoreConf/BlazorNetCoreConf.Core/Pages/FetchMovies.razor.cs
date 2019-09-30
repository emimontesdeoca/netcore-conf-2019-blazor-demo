using BlazorNetCoreConf.Core.Entities;
using BlazorNetCoreConf.Core.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorNetCoreConf.Core.Pages
{
    public class FetchMoviesBase : ComponentBase
    {
        [Parameter]
        public List<Movie> Movies { get; set; }

        [Inject]
        public MovieService MovieService { get; set; }

        protected void Reload()
        {
            Movies = Task.Run(async () => await MovieService.Get()).Result;
        }

        protected override async Task OnInitializedAsync() => Movies = await MovieService.Get();

    }
}
