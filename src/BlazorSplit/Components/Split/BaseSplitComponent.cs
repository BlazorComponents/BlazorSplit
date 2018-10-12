using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorSplit.Models;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorSplit.Components.Split
{
    public abstract class BaseSplitComponent : BlazorComponent
    {
        private SplitInteropHelper interopHelper;

        protected BaseSplitComponent()
        {
            interopHelper = new SplitInteropHelper(this);
        }

        public string Id = "id_" + Guid.NewGuid().ToString();

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public SplitDirection Direction { get; set; } = SplitDirection.Horizontal;

        [Parameter]
        public float[] Sizes
        {
            get => _sizes;
            set => _sizes = value;
        }


        private bool firstRender = true;
        private float[] _sizes;


        [Parameter]
        public Action OnDrag { get; set; }

        [Parameter]
        public Action<float[]> OnDragStart { get; set; }

        [Parameter]
        public Action<float[]> OnDragEnd { get; set; }


        internal void OnDragInvoke()
        {
            this.OnDrag?.Invoke();
        }

        internal void OnDragStartInvoke(float[] sizes)
        {
            this._sizes = sizes;
            this.OnDragStart?.Invoke(sizes);
        }

        internal void OnDragEndInvoke(float[] sizes)
        {
            this._sizes = sizes;
            this.OnDragEnd?.Invoke(sizes);
        }


        protected override async Task OnAfterRenderAsync()
        {
            if (firstRender)
            {
                firstRender = false;
                await SplitInterop.InitAsync(new SplitInitRequest()
                {
                    Id = Id,
                    Options = new SplitOptions()
                    {
                        Direction = Direction.ToString().ToLower(),
                        Sizes = Sizes,
                    },
                }, interopHelper);
            }
        }
    }
}