using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorSplit.Components.Split
{
    public abstract class BaseSplitAreaComponent : BlazorComponent
    {
        public string Id = "id_"+Guid.NewGuid().ToString();
        private float _size;

        [Parameter]
        public float Size
        {
            get => _size;
            set => _size = value;
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected override void OnAfterRender()
        {
        }
    }
}
