using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DirtyForm
{
    public class CreateUserComponentBase : ComponentBase
    {
        [Inject] public IJSRuntime JsRuntime { get; set; }
        protected UserViewModel UserViewModel { get; set; } = new UserViewModel();
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected async void FormSubmitted()
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure You want to Submit Form?"); // Confirm
            if (confirmed)
            {

            }
            else
            {
                await JsRuntime.InvokeVoidAsync("Alert", "Cancel");
            }
        }
    }
}
