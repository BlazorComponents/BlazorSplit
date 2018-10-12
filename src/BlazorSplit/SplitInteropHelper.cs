using BlazorSplit.Components.Split;
using Microsoft.JSInterop;

namespace BlazorSplit
{
    public class SplitInteropHelper
    {
        private BaseSplitComponent splitComponent;

        public SplitInteropHelper(BaseSplitComponent splitComponent)
        {
            this.splitComponent = splitComponent;
        }

        [JSInvokable]
        public void OnDrag()
        {
            splitComponent.OnDragInvoke();
        }

        [JSInvokable]
        public void OnDragStart(float[] sizes)
        {
            splitComponent.OnDragStartInvoke(sizes);
        }

        [JSInvokable]
        public void OnDragEnd(float[] sizes)
        {
            splitComponent.OnDragEndInvoke(sizes);
        }
    }
}