using Microsoft.AspNetCore.Components.Forms;

namespace FarmBlazor.Core
{
    public class EditStateContext : IDisposable
    { 
        public bool IsDirty => EditFields.IsDirty;

        public event EventHandler<EditStateEventArgs>? EditStateChanged;

        private EditFieldCollection EditFields = new EditFieldCollection();

        protected EditContext? EditContext { get; private set; }

        public EditStateContext(EditContext editContext) => this.Load(editContext);
        public void Load(EditContext editContext)
        {
            this.EditContext = editContext;
            this.LoadEditState();
            // Wire up FieldChanged to the EditContext OnFieldChanged event
            this.EditContext.OnFieldChanged += this.FieldChanged;
        }

        private void LoadEditState()
            => this.GetEditFields();

        private void GetEditFields()
        {
            var model = this.EditContext!.Model;
            this.EditFields.Clear();
            if (model is not null)
            {
                var props = model.GetType().GetProperties();
                foreach (var prop in props)
                {
                    if (prop.CanWrite)
                    {
                        var value = prop.GetValue(model);
                        EditFields.AddField(model, prop.Name, value);
                    }
                }
            }
        }
        private void FieldChanged(object? sender, FieldChangedEventArgs e) => this.NotifyFieldChanged(e);

        public void NotifyFieldChanged(FieldChangedEventArgs e)
        {
            var wasDirty = EditFields.IsDirty;

            // Get the PropertyInfo object for the model property
            // Uses reflection to get property and value
            var prop = e.FieldIdentifier.Model.GetType().GetProperty(e.FieldIdentifier.FieldName);
            if (prop != null)
            {
                // Get the value for the property
                var value = prop.GetValue(e.FieldIdentifier.Model);

                // Sets the edit value in the EditField
                EditFields.SetField(e.FieldIdentifier.FieldName, value);

                // Invokes EditStateChanged if changed
                var isStateChange = (EditFields.IsDirty) != wasDirty;
                if (isStateChange)
                    this.NotifyEditStateChanged();
            }
        }

        public void NotifySaved()
        {
            var currentState = this.EditFields.IsDirty;
            this.LoadEditState();
            if (currentState)
                NotifyEditStateChanged();
        }

        private void NotifyEditStateChanged() => EditStateChanged?.Invoke(this, EditStateEventArgs.NewArgs(EditFields?.IsDirty ?? false));

        public void Dispose()
        {
            if (this.EditContext is not null)
                this.EditContext.OnFieldChanged += this.FieldChanged;
        }
    }
}
