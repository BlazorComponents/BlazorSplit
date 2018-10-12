using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorSplit.Models;
using Microsoft.JSInterop;

namespace BlazorSplit
{
    public static class SplitInterop
    {
        public static async Task<SplitInitResponse> InitAsync(SplitInitRequest request,
            SplitInteropHelper interopHelper)
        {
            return await JSRuntime.Current.InvokeAsync<SplitInitResponse>(
                "blazorSplit.init",
                request,
                new DotNetObjectRef(interopHelper));
        }
    }
}