using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorSplit.Core;
using BlazorSplit.Models;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.RenderTree;

namespace BlazorSplit.Components.Split
{
    public abstract class BaseSplitComponent : BlazorComponent
    {
        [Parameter]
        public SplitDirection Direction { get; set; } = SplitDirection.Horizontal;

        [Parameter]
        public int MinSize { get; set; }

        [Parameter]
        public bool ExpanedToMin { get; set; } = false;

        [Parameter]
        public int GutterSize { get; set; } = 10;

        [Parameter]
        public SplitGutterAlign GutterAlign { get; set; } = SplitGutterAlign.Center;

        [Parameter]
        public int SnapOffset { get; set; } = 30;

        [Parameter]
        public int DragInterval { get; set; } = 1;

        [Parameter]
        public string Cursor { get; set; } = null;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public Action OnDrag { get; set; }

        [Parameter]
        public Action<float[]> OnDragStart { get; set; }

        [Parameter]
        public Action<float[]> OnDragEnd { get; set; }


        public string Id = "id_" + Guid.NewGuid().ToString();

        private SplitInteropHelper interopHelper;
        private BaseSplitAreaComponent[] areas;

        protected BaseSplitComponent()
        {
            interopHelper = new SplitInteropHelper(this);
        }

        private bool firstRender = true;


        internal void OnDragInvoke()
        {
            this.OnDrag?.Invoke();
        }

        internal void OnDragStartInvoke(float[] sizes)
        {
            this.OnDragStart?.Invoke(sizes);
        }

        internal void OnDragEndInvoke(float[] sizes)
        {
            this.OnDragEnd?.Invoke(sizes);
        }


        protected override async Task OnAfterRenderAsync()
        {
            this.areas = _builder
                .GetFrames()
                .Where(i => i.FrameType == RenderTreeFrameType.Component && i.Component is BaseSplitAreaComponent)
                .Select(i => i.Component).Cast<BaseSplitAreaComponent>()
                .Pipe(i => { i.parentSplit = this; })
                .ToArray();
            if (firstRender)
            {
                firstRender = false;
                await SplitInterop.InitAsync(
                    interopHelper,
                    Id,
                    areas.Select(i => "#" + i.Id).ToArray(),
                    new SplitOptions()
                    {
                        Direction = Direction.ToString().ToLower(),
                        Sizes = areas.All(i => Math.Abs(i.Size) > float.Epsilon)
                            ? areas.Select(i => i.Size).ToArray()
                            : null,
                        MinSize = areas.Select(i => i.MinSize ?? MinSize).ToArray(),
                        ExpanedToMin = ExpanedToMin,
                        GutterSize = GutterSize,
                        GutterAlign = GutterAlign.ToString(),
                        SnapOffset = SnapOffset,
                        DragInterval = DragInterval,
                        Cursor = Cursor,
                    },
                    new SplitInitOptions()
                    {
                        OnDrag = OnDrag != null,
                        OnDragEnd = OnDragEnd != null,
                        OnDragStart = OnDragStart != null,
                    }
                );
            }
        }

        private RenderTreeBuilder _builder;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            this._builder = builder;
        }
    }
}