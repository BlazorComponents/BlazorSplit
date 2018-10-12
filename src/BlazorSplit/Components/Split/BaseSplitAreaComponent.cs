using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.RenderTree;

namespace BlazorSplit.Components.Split
{
    public abstract class BaseSplitAreaComponent : BlazorComponent
    {
        [Parameter]
        public float Size
        {
            get => _size;
            set => _size = value;
        }

        [Parameter]
        public int? MinSize { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        


        public string Id = "id_" + Guid.NewGuid().ToString();

        private float _size;
        internal BaseSplitComponent parentSplit;

        protected override void OnAfterRender()
        {
        }
    }
}