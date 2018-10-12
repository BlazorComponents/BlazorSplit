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
        public static async Task InitAsync(SplitInteropHelper interopHelper, string id, string[] elements,
            SplitOptions options, SplitInitOptions initOptions)
        {
            await JSRuntime.Current.InvokeAsync<object>(
                "blazorSplit.init",
                new DotNetObjectRef(interopHelper),
                id,
                elements,
                options,
                initOptions
            );
        }
    }
}