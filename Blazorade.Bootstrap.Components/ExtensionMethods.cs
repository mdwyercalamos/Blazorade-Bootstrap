﻿using Blazorade.Bootstrap.Components.JSInterop;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazorade.Bootstrap.Components
{
    public static class ExtensionMethods
    {

        public static AlertInterop Alert(this IJSRuntime jsInterop)
        {
            return new AlertInterop(jsInterop);
        }

        public static CollapseInterop Collapse(this IJSRuntime jsInterop)
        {
            return new CollapseInterop(jsInterop);
        }

        /// <summary>
        /// Breaks the given input into lines.
        /// </summary>
        /// <param name="input">The input string to split up into lines.</param>
        /// <returns>Returns a collection where each line of text is a separate item.</returns>
        /// <remarks>
        /// If <paramref name="input"/> is <c>null</c>, an empty collection is returned.
        /// </remarks>
        public static IEnumerable<string> Lines(this string input)
        {
            foreach(var line in input?.Split(new[] { Environment.NewLine}, StringSplitOptions.None))
            {
                yield return line;
            }

            yield break;
        }

        public static async Task RegisterEventCallbackAsync(this IJSRuntime jsInterop, string id, string eventName, BootstrapComponentBase callbackTarget, string callbackMethodName, bool singleEvent = true, string[] callbackParameters = null)
        {
            await jsInterop.InvokeVoidAsync(JsFunctions.RegisterEventCallback, $"#{id}", eventName, DotNetObjectReference.Create(callbackTarget), callbackMethodName, singleEvent, callbackParameters);
        }

        public static ToastInterop Toast(this IJSRuntime jsInterop)
        {
            return new ToastInterop(jsInterop);
        }

    }
}
