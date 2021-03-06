﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazorade.Bootstrap.Components
{
    public partial class HeadingContent
    {

        [Parameter]
        public string AnchorId { get; set; }

        [Parameter]
        public string HeadingId { get; set; }

        [Parameter]
        public bool IsAnchor { get; set; }


        protected async Task ContentOnMouseOver(MouseEventArgs e)
        {
            await this.JsInterop.InvokeVoidAsync(JsFunctions.Show, this.AnchorId);
        }

        protected async Task ContentOnMouseOut(MouseEventArgs e)
        {
            await this.JsInterop.InvokeVoidAsync(JsFunctions.Hide, this.AnchorId);
        }

        protected override void OnParametersSet()
        {
            this.Id = $"{this.HeadingId}-content";
            this.AnchorId = $"{this.HeadingId}-anchor";

            base.OnParametersSet();
        }
    }
}
